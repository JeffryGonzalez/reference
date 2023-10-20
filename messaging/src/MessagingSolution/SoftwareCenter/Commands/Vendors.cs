namespace SoftwareCenter.Commands;

public abstract record VendorCommands
{
    public record CreateVendor(string Name) : VendorCommands;
}