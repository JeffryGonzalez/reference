using Marten.Events.Projections;

using SoftwareCenter.Commands;
using SoftwareCenter.Events;

namespace SoftwareCenter.Handlers;

public class TechHandler
{
    public TechCreated Handle(TechOwnerCommand.CreateSupportTech command)
    {
        return new TechCreated(Guid.NewGuid(), command.Name, command.EmailAddress);
    }
}


public class TechSummary
{
    public Guid Id { get; set; }
    public List<TechModel> Techs { get; set; } = new();
    public record TechModel(Guid Id, string Name, string EmailAddress);
}

public class TechSummaryProjection : MultiStreamProjection<TechSummary, Guid>
{
    public Guid Id { get; set; } = Constants.TechsStream;

    public void Apply(TechCreated @event, TechSummary view)
    {
        view.Techs.Add(new TechSummary.TechModel(@event.Id, @event.Name, @event.EmailAddress));
    }
}