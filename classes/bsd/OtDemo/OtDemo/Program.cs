using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OtDemo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenTelemetry()
    .ConfigureResource(b => b.AddService("weather-api"))
    .WithTracing(b => {
        b.AddAspNetCoreInstrumentation().AddConsoleExporter().AddZipkinExporter().AddHttpClientInstrumentation();
        b.AddSource(WeatherMetrics.ActivitySourceName)
        .SetSampler(new AlwaysOnSampler());
    })
    .WithMetrics(opts =>
    {
        opts.AddMeter(WeatherMetrics.MeterName);
        opts.AddPrometheusExporter();
        opts.AddHttpClientInstrumentation();
        opts.AddRuntimeInstrumentation();
        opts.AddAspNetCoreInstrumentation();
        opts.AddView(instrumentName: "wx.temp.distributions", new ExplicitBucketHistogramConfiguration { Boundaries = new double[] { -20, -10, 0, 10, 20, 30, 40, 50, 55 } });

    });
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<WeatherMetrics>();
builder.Services.AddHttpClient();

builder.Logging.ClearProviders();
builder.Logging.AddOpenTelemetry(options =>
{
    var resourceBuilder = ResourceBuilder.CreateDefault();
    resourceBuilder.AddService("weather-api");
    options.SetResourceBuilder(resourceBuilder);

    options.AddOtlpExporter(oltpOptions =>
    {
        oltpOptions.Endpoint = new Uri("http://localhost:9411"); // Zipkin
    });
    options.AddConsoleExporter(); // So we can see it too.
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", async (WeatherMetrics meters, HttpClient client) =>
{
    using var scope = app.Logger.BeginScope("{Id}", Guid.NewGuid().ToString("N"));


    var res = await client.GetStringAsync("https://www.google.com");
    WeatherForecast[] forecast = [];
    using (var activity = meters.ActivitySource.StartActivity("getting forecast"))
    {

        forecast = Enumerable.Range(1, 5).Select(index =>
           new WeatherForecast
           (
               DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
               Random.Shared.Next(-20, 55),
               summaries[Random.Shared.Next(summaries.Length)]
           ))
           .ToArray();
    }
    meters.IncrementWxRequested();
    var dist = forecast.Select(f => (double)f.TemperatureC).ToArray();
    meters.SetWxDistributions(dist);
    app.Logger.LogInformation("Weather Forecast Created {count} {forecasts}", forecast.Length, forecast);
    if(forecast.Count(f => f.Summary == "Freezing") > 0)
    {
        var ex = new BadHttpRequestException("Too Cold. You Don't Want to Know");
        app.Logger.LogCritical("Too Many Cold Days {ex}", ex);
        throw ex;
    }
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapPrometheusScrapingEndpoint();
app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
