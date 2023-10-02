using Alba;
using BugTrackerApi.ContractTests.Fixtures;
using BugTrackerApi.Models;

using Microsoft.Net.Http.Headers;

namespace BugTrackerApi.ContractTests.BugReports;
[Collection("happy path")]
public class FilingABug 

{
    private readonly IAlbaHost _host;

    public FilingABug(FilingABugFixture fixture)
    {
        _host = fixture.AlbaHost;
    }
    [Theory]
    [MemberData(nameof(GetSamples))]
    public async Task FilingAValidBugReport(BugReportCreateRequest request, BugReportCreateResponse expectedResponse)
    {

        var response = await _host.Scenario(api =>
        {
            api.Post.Json(request).ToUrl("/catalog/super-app/bugs");
            api.StatusCodeShouldBe(201);
            api.Header(HeaderNames.Location).ShouldHaveOneNonNullValue();

        });

        var body = response.ReadAsJson<BugReportCreateResponse>();
        Assert.NotNull(body);
        Assert.Equal(expectedResponse, body);
        string? header = response.Context.Response.Headers.Location.First();


        var lookupResponse = await _host.Scenario(api =>
        {
            api.Get.Url("/catalog/super-app/bugs/" + expectedResponse.Id);
            api.StatusCodeShouldBeOk();
        });

        var body2 = response.ReadAsJson<BugReportCreateResponse>();
        Assert.NotNull(body2);
        Assert.Equal(body, body2);
    }

    public static IEnumerable<object[]> GetSamples()
    {
        BugReportCreateRequest request1 = new()
        {
            Description = "Thing done blown up",
            Narrative = "When I click the do-dad, the whizzer blinkers"
        };
        BugReportCreateResponse response1 = new()
        {
            Created = FilingABugFixture.AssumedTime,
            CurrentStatus = BugReportStatus.InTriage,
            Id = "thing-done-blown-up",
            ReportedBy = "carl",
            Request = request1
        };

        BugReportCreateRequest request2 = new()
        {
            Description = "Can't Log In",
            Narrative = "When I click the do-dad, the whizzer blinkers"
        };
        BugReportCreateResponse response2 = new()
        {
            Created = FilingABugFixture.AssumedTime,
            CurrentStatus = BugReportStatus.InTriage,
            Id = "cant-log-in",
            ReportedBy = "carl",
            Request = request2
        };

        yield return new object[] { request1, response1 };
        yield return new object[] { request2, response2 };
    }
}

