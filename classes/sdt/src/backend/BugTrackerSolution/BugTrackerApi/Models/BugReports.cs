using System.ComponentModel.DataAnnotations;

namespace BugTrackerApi.Models;

public record BugReportCreateRequest {

    [Required, MaxLength(200)]
    public string Description { get; set; } = string.Empty;
[Required]
    public string Narrative { get; set; } = string.Empty;
}

public record BugReportCreateResponse
{
    public string Id { get; set; } = string.Empty;
    public BugReportStatus CurrentStatus { get; set; }

    public BugReportCreateRequest Request { get; set; } = new();

    public DateTimeOffset Created { get; set; } = new();
    public string ReportedBy { get; set; } = string.Empty;
}

public enum BugReportStatus { InTriage }