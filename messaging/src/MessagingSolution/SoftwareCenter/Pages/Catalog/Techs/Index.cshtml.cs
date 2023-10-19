using Marten;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using SoftwareCenter.Handlers;

using Wolverine;

using static SoftwareCenter.Commands.TechOwnerCommand;

namespace SoftwareCenter.Pages.Catalog.Techs;

public class IndexModel : PageModel
{
    private readonly IMessageBus _bus;
    private readonly IDocumentSession _session;

    public IndexModel(IMessageBus bus, IDocumentSession session)
    {
        _bus = bus;
        _session = session;
    }

    [BindProperty]
    public TechModel TechModel { get; set; } = new();

    public TechSummary Techs { get; set; } = new();
    public async void OnGetAsync()
    {
        Techs = await _session.Events.AggregateStreamAsync<>
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _bus.PublishAsync(TechModel.ToCommand());
        return RedirectToPage();
    }
}

public record TechModel
{
    public string Name { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
}

public static class ModelExtensions
{
    public static CreateSupportTech ToCommand(this TechModel model)
    {
        return new CreateSupportTech(model.Name, model.EmailAddress);
    }
}