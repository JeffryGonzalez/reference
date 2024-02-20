using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace OtDemo;

public class WeatherMetrics : IDisposable
{
    internal const string ActivitySourceName = "WxForecast";
    internal const string MeterName = "WxMeters";

    private Counter<int> WxRequested { get; }
    private Histogram<double> WxDistributions { get; }

    private readonly Meter meter;

    public WeatherMetrics()
    {

        string? version = typeof(WeatherMetrics).Assembly.GetName().Version?.ToString();
        this.ActivitySource = new ActivitySource(ActivitySourceName, version);

        meter = new Meter(MeterName, version);

        WxRequested = meter.CreateCounter<int>("wx.requested", "Times", "Number of times weather was requested");

        WxDistributions = meter.CreateHistogram<double>("wx.temp.distributions", "Temperature", "The Temperatures");
        


    }
    public ActivitySource ActivitySource { get; }



    public void IncrementWxRequested()
    {
        WxRequested.Add(1);
    }

    public void SetWxDistributions(params double[] temps)
    {
        foreach (var temp in temps)
        {
            WxDistributions.Record(temp);
        }
    }

    public void Dispose()
    {
        this.ActivitySource.Dispose();
        this.meter.Dispose();
    }
}
