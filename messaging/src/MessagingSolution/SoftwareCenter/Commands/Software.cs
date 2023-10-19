namespace SoftwareCenter.Commands;


public abstract record SoftwareCatalogCommand
{
   

    public record CreateSoftwareTitle(string Title, string Publisher, Guid SupportTechId) : SoftwareCatalogCommand;
}

public abstract record TechOwnerCommand
{
    public record CreateSupportTech(string Name, string EmailAddress) : TechOwnerCommand;
}