using Marten;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using SoftwareCenter.Commands;
using SoftwareCenter.Entities;

using Wolverine;

namespace SoftwareCenter.Pages.Catalog;

public class Index : PageModel
{
    private readonly IDocumentSession _session;
    private readonly ILogger<Index> _logger;
    private readonly IMessageBus _bus;
    public Index(IDocumentSession session, ILogger<Index> logger, IMessageBus bus)
    {
        _session = session;
        _logger = logger;
        _bus = bus;
    }

    [BindProperty]
    public IReadOnlyList<SoftwareItemEntity> Catalog { get; set; } = null!;
    [BindProperty]
    public TechInfo TechInfo { get; set; } = new();
    [BindProperty]
    public IReadOnlyList<SupportTechEntity> Techs { get; set; } = null!;

    [BindProperty]
    public TitleInfo TitleInfo { get; set; } = new();
    public async Task OnGetAsync()
    {
        Catalog = await _session.Query<SoftwareItemEntity>().ToListAsync();
        Techs = await _session.Query<SupportTechEntity>().ToListAsync();
    }

    public async Task<IActionResult> OnPostTech()
    {
        var command = new CreateSupportTech(TechInfo.Name, TechInfo.EmailAddress);
        await _bus.InvokeAsync(command);
        return Redirect("/Catalog/index");
    }

    public async Task<IActionResult> OnPostTitle()
    {
        var command = new CreateSoftwareTitle(TitleInfo.Title, TitleInfo.Publisher, TitleInfo.TechId);
        await _bus.InvokeAsync(command);
        return Redirect("/Catalog/index");
    }
}

public record TechInfo
{
    public string Name { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;


}

public record TitleInfo
{
    public string Title { get; set; } = string.Empty;
    public string Publisher { get; set; } = string.Empty;
    public Guid TechId { get; set; } 
}