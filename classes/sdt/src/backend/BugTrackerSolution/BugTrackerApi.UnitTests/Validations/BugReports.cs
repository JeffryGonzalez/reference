using System.ComponentModel.DataAnnotations;
using BugTrackerApi.Models;

namespace BugTrackerApi.UnitTests.Validations;

public class BugReports
{
    [Fact]
    public void ValidationsForCreatingABugReport()
    {
        var type = typeof(BugReportCreateRequest);

        var descriptionProperty = type.GetProperty(nameof(BugReportCreateRequest.Description));
        var narrativeProperty = type.GetProperty(nameof(BugReportCreateRequest.Description));

        descriptionProperty.Should()
            .BeDecoratedWith<RequiredAttribute>();

        descriptionProperty.Should().BeDecoratedWith<MaxLengthAttribute>(a => a.Length == 200);
    }
}