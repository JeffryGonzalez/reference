using SoftwareCenter.Events;

namespace SoftwareCenter.Commands;

public abstract record SoftwareCatalogCommand
{

    public record AssignVendorToTitle(Guid Id, Guid VendorId) : SoftwareCatalogCommand;
    public record CreateSoftwareTitle(string Title) : SoftwareCatalogCommand;
}