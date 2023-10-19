namespace SoftwareCenter.Events;

public record SoftwareTitleCreated(Guid TitleId, string Title, string Publisher);

public record TechAssignedToSoftware(Guid TechId, Guid SoftwareId);

public record TechCreated(Guid TechId, string Name, string EmailAddress);