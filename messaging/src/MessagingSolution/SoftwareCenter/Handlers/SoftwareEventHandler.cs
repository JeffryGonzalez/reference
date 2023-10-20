using Marten;
using SoftwareCenter.Commands;
using SoftwareCenter.Events;

namespace SoftwareCenter.Handlers;

public static class SoftwareTitleHandler
{
    public static SoftwareCatalogEvents.SoftwareTitleCreated Handle(SoftwareCatalogCommand.CreateSoftwareTitle command,
        IDocumentSession session)
    {
        var @event = new SoftwareCatalogEvents.SoftwareTitleCreated(Guid.NewGuid(), command.Title);
        session.Events.Append(@event.Id, @event);
        return @event;
    }
    
    
}

public class SoftwareTitle
{
    public Guid Id { get; set; }
    public int Version { get; set; }
    public string Title { get; set; } = string.Empty;
    public SelectModel? Vendor { get; set; } = null;
    public SelectModel? Owner { get; set; } = null;

    public void Apply(SoftwareCatalogEvents.SoftwareTitleCreated @event, SoftwareTitle view)
    {
        view.Id = @event.Id;
        view.Title = @event.Title;
    }
    
}