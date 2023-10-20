using Marten;
using SoftwareCenter.Commands;
using SoftwareCenter.Events;

namespace SoftwareCenter.Handlers;

public class TechHandler
{
    public TechCreated Handle(TechOwnerCommand.CreateSupportTech command, IDocumentSession session)
    {
        var @event =  new TechCreated(Guid.NewGuid(), command.Name, command.EmailAddress);
         session.Events.Append(@event.Id, @event);
        return @event;
    }
}


public class Tech
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;

    public void Apply(TechCreated @event, Tech view)
    {
        view.Id = @event.Id;
        view.Name = @event.Name;
        view.EmailAddress = @event.EmailAddress;
    } 
}

