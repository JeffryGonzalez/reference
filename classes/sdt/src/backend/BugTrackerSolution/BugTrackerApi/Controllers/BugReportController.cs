using BugTrackerApi.Models;
using BugTrackerApi.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OneOf;

namespace BugTrackerApi.Controllers;

public class BugReportController : ControllerBase
{

    private readonly BugCatalog _catalog;

    public BugReportController(BugCatalog catalog)
    {
        _catalog = catalog;
    }

    [Authorize]
    [HttpPost("catalog/{software}/bugs")]
    public async Task<ActionResult> FileBugReportAsync([FromBody] BugReportCreateRequest request, [FromRoute] string software)
    {

        var createBugReportResponse = await _catalog.CreateBugRequestAsync(User.GetName(), software, request);

        return createBugReportResponse.Match<ActionResult>(
             report => CreatedAtRoute("bugs#get-by-slug", new { slug = report.Id }, report),
             _ => NotFound()
          );

    }

    [HttpGet("/catalog/super-app/bugs/{slug}", Name = "bugs#get-by-slug")]
    public async Task<ActionResult> GetABugBySlugAsync([FromRoute] string slug)
    {
        var bugReport = await _catalog.GetBugReportBySlugAsync(slug);
        return bugReport.Match<ActionResult>(
            report => Ok(report),
            notFound => NotFound()
            );
        
    }
}
