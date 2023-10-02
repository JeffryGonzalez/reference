using Alba;
using Alba.Security;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.PostgreSql;

namespace BugTrackerApi.ContractTests.Fixtures;
public abstract class BaseAlbaFixture : IAsyncLifetime
{
    //private readonly string PG_IMAGE = "postgres:15.2-bullseye";
    private readonly string PG_IMAGE = "jeffrygonzalez/pg-thing:v2";
    private readonly PostgreSqlContainer _pgContainer;

    protected BaseAlbaFixture()
    {
        _pgContainer = new PostgreSqlBuilder()
            .WithUsername("postgres")
            .WithPassword("password")
            .WithImage(PG_IMAGE)
            .Build();
           
    }
    public IAlbaHost AlbaHost = null!;
    public async Task DisposeAsync()
    {
        await AlbaHost.DisposeAsync();
        await _pgContainer.DisposeAsync().AsTask();
        Environment.SetEnvironmentVariable("ConnectionStrings__bugs", null);
    }

    public async Task InitializeAsync()
    {
        
        await _pgContainer.StartAsync();
        Environment.SetEnvironmentVariable("ConnectionStrings__bugs", _pgContainer.GetConnectionString());
        AlbaHost = await Alba.AlbaHost.For<Program>(builder => builder.ConfigureServices(services => RegisterServices(services)), GetStub());
    }

    protected abstract void RegisterServices(IServiceCollection services);
    protected virtual AuthenticationStub GetStub()
    {
        return new AuthenticationStub();
    }
}
