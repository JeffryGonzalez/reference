namespace SoftwareCenter.Commands;

public abstract record TechOwnerCommand
{
    public record CreateSupportTech(string Name, string EmailAddress) : TechOwnerCommand;
}