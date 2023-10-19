namespace SoftwareCenter.Commands;

public record CreateSupportTech(string Name, string EmailAddress);

public record CreateSoftwareTitle(string Title, string Publisher, Guid SupportTechId);


