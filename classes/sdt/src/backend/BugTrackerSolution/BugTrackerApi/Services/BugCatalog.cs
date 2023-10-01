using BugTrackerApi.Models;

using Marten;

using OneOf;

using Sluggo;

namespace BugTrackerApi.Services;

public class BugCatalog 
{
    private readonly ISystemTime _systemTime;
    private readonly Sluggo.SlugGenerator _slugGenerator;
    private readonly IProvideTheSoftwareCatalog _softwareCatalog;
    private readonly IDocumentSession _documentSession;

    public BugCatalog(ISystemTime systemTime, SlugGenerator slugGenerator,  IProvideTheSoftwareCatalog softwareCatalog, IDocumentSession documentSession)
    {
        _systemTime = systemTime;
        _slugGenerator = slugGenerator;

        _softwareCatalog = softwareCatalog;
        _documentSession = documentSession;
    }

    public async Task<OneOf<BugReportCreateResponse, NoBugReportFound>> GetBugReportBySlugAsync(string slug)
    {
        var saved = await _documentSession.Query<BugReportEntity>().Where(b => b.BugReport.Id == slug).SingleOrDefaultAsync();

        if(saved is null)
        {
            return new NoBugReportFound();
        } else
        {
            return saved.BugReport;
        }
    }
    public async Task<OneOf<BugReportCreateResponse, NoSoftwareFound>> CreateBugRequestAsync(string user, string software, BugReportCreateRequest request)
    {
        if (await _softwareCatalog.HasSoftwareInCatalogAsync(software))
        {
            BugReportCreateResponse response = new()
            {
                Request = request,
                Created = _systemTime.GetCurrent(),
                CurrentStatus = BugReportStatus.InTriage,
                ReportedBy = user,
                Id = await _slugGenerator.GenerateSlugAsync(request.Description, CheckForUniqueAsync)

            };
            var reportToSave = new BugReportEntity
            {
                Id = Guid.NewGuid(),
                BugReport = response
            };
            _documentSession.Insert(reportToSave);
            await _documentSession.SaveChangesAsync();
            return response;
        }
        else
        {
            return new NoSoftwareFound();
        }

        async Task<bool>  CheckForUniqueAsync(string slug)
        {
            
                return await _documentSession.Query<BugReportEntity>().Where(b => b.BugReport.Id == slug).AnyAsync() == false;
            
        }
    }

   
}

public record NoSoftwareFound();
public record NoBugReportFound();