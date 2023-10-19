using Marten;

using SoftwareCenter.Commands;
using SoftwareCenter.Entities;
using SoftwareCenter.Events;

namespace SoftwareCenter.Handlers;

public static class SoftwareHandler
{
    public static async Task<TechCreated> Handle(CreateSupportTech command, IDocumentSession session)
    {
        var tech = new SupportTechEntity(Guid.NewGuid(), command.Name, command.EmailAddress);
        session.Store(tech);
        await session.SaveChangesAsync();
        return new TechCreated(tech.Id, tech.Name, tech.EmailAddress);
       
    }

    public static async Task<(SoftwareTitleCreated, TechAssignedToSoftware)> HandleAsync(CreateSoftwareTitle command, IDocumentSession session)
    {
        var tech = await session.LoadAsync<SupportTechEntity>(command.SupportTechId);
        if(tech is not null)
        {
            var newTitle = new SoftwareItemEntity(Guid.NewGuid(), command.Title, command.Publisher, tech);
            session.Store(newTitle);
            await session.SaveChangesAsync();
            var titleEvent = new SoftwareTitleCreated(newTitle.Id, newTitle.Title, newTitle.Publisher);
            var assignEvent = new TechAssignedToSoftware(command.SupportTechId, newTitle.Id);
            return (titleEvent, assignEvent);
          
        } else
        {
            throw new ChaosException("No Tech");
        }
    }
}
