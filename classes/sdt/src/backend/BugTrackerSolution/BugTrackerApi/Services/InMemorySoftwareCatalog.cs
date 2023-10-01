namespace BugTrackerApi.Services;

public class InMemorySoftwareCatalog : IProvideTheSoftwareCatalog
{
    private readonly List<string> _catalog = new()
    {
        "super-app",
    };
    public Task<bool> HasSoftwareInCatalogAsync(string softwareTitle)
    {
        return Task.FromResult(_catalog.Contains(softwareTitle.Trim().ToLowerInvariant()));
    }
}
