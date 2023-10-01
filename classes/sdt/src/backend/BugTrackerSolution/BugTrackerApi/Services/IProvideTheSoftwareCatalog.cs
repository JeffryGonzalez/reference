namespace BugTrackerApi.Services;

public interface IProvideTheSoftwareCatalog
{
    Task<bool> HasSoftwareInCatalogAsync(string softwareTitle);
}