using Marten;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SoftwareCenter.Commands;
using SoftwareCenter.Handlers;
using Wolverine;

namespace SoftwareCenter.Pages.Catalog;

public class Index : PageModel
{
    private readonly IDocumentSession _session;
    private readonly IMessageBus _bus;

    public Index(IDocumentSession session, IMessageBus bus)
    {
        _session = session;
        _bus = bus;
    }

    [BindProperty] public string TitleName { get; set; } = string.Empty;
    public IReadOnlyList<SelectModel> Vendors { get; set; } = null!;
    public IReadOnlyList<SelectModel> Techs { get; set; } = null!;
    public IReadOnlyList<SoftwareTitle> Titles { get; set; } = null!;
    public async Task OnGetAsync()
    {
        Vendors = await _session.Query<Vendor>()
            .Select(v => new SelectModel(v.Id, v.Name))
            .ToListAsync();

        Techs = await _session.Query<Tech>()
            .Select(t => new SelectModel(t.Id, t.Name))
            .ToListAsync();
        Titles = await _session.Query<SoftwareTitle>().ToListAsync();
    }

    public async Task<IActionResult> OnPostTitleAsync()
    {
        await _bus.InvokeAsync(new SoftwareCatalogCommand.CreateSoftwareTitle(TitleName));
        return RedirectToPage();
    }
}

public record SoftwareTitleModel
{
    public string Name { get; set; } = string.Empty;
    public string Vendor { get; set; } = string.Empty;
}