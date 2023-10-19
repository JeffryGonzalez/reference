//using Marten.Events;
//using Marten.Events.Projections;

//using Microsoft.CodeAnalysis.VisualBasic.Syntax;

//using SoftwareCenter.Commands;
//using SoftwareCenter.Entities;
//using SoftwareCenter.Events;

//using Wolverine.Marten;

//using static SoftwareCenter.Commands.SoftwareCatalogCommand;
//using static SoftwareCenter.Commands.TechOwnerCommand;
//using static SoftwareCenter.Events.SoftwareCatalogEvents;

//namespace SoftwareCenter.Handlers;

//public class SoftwareEventHandler
//{
//    public static readonly  Guid CatalogId = Guid.Parse("2cfbf17f-6b92-4885-a707-e0329c951657");
//    [AggregateHandler]
//    public static TechCreated Handle(CreateSupportTech command, IEventStream<SoftwareCatalog> stream)
//    {
//        var catalog = stream.Aggregate;

//        TechCreated @event = new TechCreated(Guid.NewGuid(), command.Name, command.EmailAddress);
//        stream.AppendOne(@event);
//        return @event;
//    }

//    [AggregateHandler]
//    public static (SoftwareTitleCreated, TechAssignedToSoftware) Handle(CreateSoftwareTitle command, IEventStream<SoftwareCatalog> stream)
//    {
//        var catalog = stream.Aggregate;

//       if(catalog.Techs.Any(t => t.Id == command.SupportTechId))
//        {
//            var title = new SoftwareTitleCreated(Guid.NewGuid(), command.Title, command.Publisher);
//            stream.AppendOne(title);
//            var assignment = new TechAssignedToSoftware(command.SupportTechId, title.TitleId);
//            stream.AppendMany(assignment);
//            return (title, assignment);

//        } else
//        {
//            throw new ChaosException("No Support Tech");
//        }
//    }
//}


//public class CatalogDashboardReadModel 
//{ 


//    public Guid Id { get; set; }

//    public List<TitleSummary> Titles { get; set; } = new();
//    public List<TechSummary> Techs { get; set; } = new();

//    public record TitleSummary(Guid TitleId, string Name, string Publisher, Guid? CurrentSupportTech = null);
//    public record TechSummary(Guid SupportTechId, string Name, string Email);

//}
//public class CatalogDashboardProjection : MultiStreamProjection<CatalogDashboardReadModel, Guid>
//{
//    public Guid Id { get; set; }
//    public int Version { get; set; }
//    public CatalogDashboardProjection()
//    {
//        Identity<SoftwareCatalogEvents>(e => e.SoftwareCatalogId);
//    }

//    public void Apply(SoftwareTitleCreated @event, CatalogDashboardReadModel view)
//    {
//        Id = @event.SoftwareCatalogId;
//        view.Titles.Add(new CatalogDashboardReadModel.TitleSummary(@event.TitleId, @event.Title, @event.Publisher));

//    }
//    //public void Apply()
//}

//public class SoftwareCatalog
//{
//    public Guid Id { get; set; }
//    public int Version { get; set; }

//    public List<SoftwareItemEntity> Catalog { get; set; } = new();
//    public List<SupportTechEntity> Techs { get; set; } = new();

//    public void Apply(SoftwareTitleCreated @event)
//    {
//        var thing = new SoftwareItemEntity(@event.TitleId, @event.Title, @event.Publisher);
//        Catalog.Add(thing);
//    }

//    public void Apply(TechCreated @event)
//    {
//        var thing = new SupportTechEntity(@event.TechId, @event.Name, @event.EmailAddress);
//        Techs.Add(thing);
//    }

//    public void Apply(TechAssignedToSoftware @event)
//    {
//        var title = Catalog.Single(c => c.Id == @event.SoftwareId);
//        Catalog.Remove(title);
//        var tech = Techs.Single(t => t.Id == @event.TechId);
//        var newTitle = title with { SupportTech = tech };
//        Catalog.Add(newTitle);
//    }

//}

