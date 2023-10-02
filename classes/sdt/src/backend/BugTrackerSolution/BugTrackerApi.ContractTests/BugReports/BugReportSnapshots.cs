using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Alba;

using BugTrackerApi.ContractTests.Fixtures;

namespace BugTrackerApi.ContractTests.BugReports;
[Collection("happy path")]
[UsesVerify]
public class BugReportSnapshots
{

    private readonly IAlbaHost _host;
    public BugReportSnapshots(FilingABugFixture fixture)
    {
        _host = fixture.AlbaHost;
    }

    [Fact]
    public  Task GettingAThing()
    {
        //var response =  _host.Scenario(api =>
        //{
        //    api.Get.Url("/catalog/super-app/bugs/bozo");
        //});
        var thing = new { name = "Bozo" };

         return Verify(thing);
    }
}
