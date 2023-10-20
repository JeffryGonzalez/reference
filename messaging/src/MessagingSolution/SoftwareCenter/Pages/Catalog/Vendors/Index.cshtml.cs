using Marten;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SoftwareCenter.Commands;
using SoftwareCenter.Handlers;
using Wolverine;

namespace SoftwareCenter.Pages.Catalog.Vendors;

public class Index : PageModel
{
    private readonly IMessageBus _bus;
    private readonly IDocumentSession _session;

    public IReadOnlyList<Vendor> Vendors { get; set; } = null!;
    public Index(IMessageBus bus, IDocumentSession session)
    {
        _bus = bus;
        _session = session;
    }

    [BindProperty]
    public string VendorName { get; set; } = string.Empty;
    public async Task OnGetAsync()
    {
        
        Vendors = await _session.Query<Vendor>().ToListAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _bus.InvokeAsync(new VendorCommands.CreateVendor(VendorName));
        return RedirectToPage();
    }
}

