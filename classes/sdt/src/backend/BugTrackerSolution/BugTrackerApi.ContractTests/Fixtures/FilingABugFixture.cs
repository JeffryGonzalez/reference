using Alba.Security;
using BugTrackerApi.Services;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace BugTrackerApi.ContractTests.Fixtures;

public class FilingABugFixture : BaseAlbaFixture
{
    public static DateTimeOffset AssumedTime = new(new DateTime(1969, 4, 20, 23, 59, 59), TimeSpan.FromHours(-4));

    protected override void RegisterServices(IServiceCollection services)
    {
        ISystemTime fakeClock = Substitute.For<ISystemTime>();
        fakeClock.GetCurrent().Returns(AssumedTime);


        services.AddSingleton<ISystemTime>(fakeClock);
    }

    protected override AuthenticationStub GetStub()
    {
        return base.GetStub().WithName("carl");
    }
}