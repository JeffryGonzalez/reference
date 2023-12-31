﻿using Alba;
using BugTrackerApi.ContractTests.Fixtures;
using BugTrackerApi.Models;

namespace BugTrackerApi.ContractTests.BugReports;
[Collection("happy path")]
public class FilingABugForNonExistentSoftware
{
    private readonly IAlbaHost _host;
    public FilingABugForNonExistentSoftware(FilingABugFixture fixture)
    {
        _host = fixture.AlbaHost;
    }

    [Fact]
    public async Task GivesAFourOhFour()
    {
        BugReportCreateRequest request = new()
        {
            Description = "Thing done blown up",
            Narrative = "When I click the do-dad, the whizzer blinkers"
        };
        var response = await _host.Scenario(api =>
        {
            api.Post.Json(request).ToUrl("/catalog/not-there/bugs");
            api.StatusCodeShouldBe(404);

        });


    }
}
