# Alba Testing
# Using Alba For Testing

#alba #testing #services

## Dotnet 6

In the API Project, add this to the `.csproj` file:

```xml
	<ItemGroup>
		<InternalsVisibleTo Include="TestProject1" />
	</ItemGroup>
```

## "Standalone" Test

```csharp
public class UnitTest1
{
    [Fact]
    public async Task Test1()
    {
        await using var host = await AlbaHost.For<global::Program>(x =>
        {
            x.ConfigureServices((context, services) =>
            {
                //services.AddSingleton<IService, ServiceA>();
            });
        });


        await host.Scenario(_ =>
        {
            _.Get.Url("/");
            _.StatusCodeShouldBe(404);
        });
    }
}
```

## Using A Test Fixture

### Fixture

```csharp


using Alba;
using System.Globalization;

namespace TestProject1;
public class WebAppFixture : IAsyncLifetime
{
    public IAlbaHost AlbaHost = null!;

    public async Task InitializeAsync()
    {
        AlbaHost = await Alba.AlbaHost.For<global::Program>(builder =>
        {
            // Configure all the things
        });
    }

    public async Task DisposeAsync()
    {
        await AlbaHost.DisposeAsync();
    }
}
```

### The Test Class

```csharp
public  class Anothertest : IClassFixture<WebAppFixture>
{
    private readonly IAlbaHost _albaHost;

	public Anothertest(WebAppFixture fixture)
	{
		_albaHost = fixture.AlbaHost;
	}

	[Fact]
    public async Task HasDoc()
	{
        await _albaHost.Scenario(_ =>
        {
            _.Get.Url("/docs");
            _.StatusCodeShouldBe(200);
        });
    }
}
```


### Various Docs and Stuff

[Sending and Checking Json | Alba (jasperfx.github.io)](https://jasperfx.github.io/alba/scenarios/json.html)


### I like this Helper

```csharp

[Fact]
public async Task post_and_expect_response()
{
    using var system = AlbaHost.ForStartup<WebApp.Startup>();
    var request = new OperationRequest
    {
        Type = OperationType.Multiply,
        One = 3,
        Two = 4
    };

    var result = await system.PostJson(request, "/math")
        .Receive<OperationResult>();
        
    result.Answer.ShouldBe(12);
    result.Method.ShouldBe("POST");
}
```


