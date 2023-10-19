namespace SoftwareCenter.Events;

public abstract record SoftwareCatalogEvents
{
    public Guid SoftwareCatalogId { get; } = Guid.Parse("2cfbf17f-6b92-4885-a707-e0329c951657");

    public record SoftwareTitleCreated( Guid TitleId, string Title, string Publisher): SoftwareCatalogEvents;

    public record TechAssignedToSoftware( Guid TechId, Guid SoftwareId): SoftwareCatalogEvents;

    public record TechCreated(Guid TechId, string Name, string EmailAddress): SoftwareCatalogEvents;
}