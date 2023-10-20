using Marten;
using SoftwareCenter.Commands;
using SoftwareCenter.Events;

namespace SoftwareCenter.Handlers;

public static class VendorHandler
{
    public static VendorCreated Handle(VendorCommands.CreateVendor command, IDocumentSession session)
    {
        var evt = new VendorCreated(Guid.NewGuid(), command.Name);
        session.Events.Append(evt.Id, evt);
        return evt;
    }
}

public class Vendor
{
    public Guid Id { get; set; }
    public int Version { get; set; }

    public string Name { get; set; } = string.Empty;

    public void Apply(VendorCreated evt, Vendor view)
    {
        view.Id = evt.Id;
        view.Name = evt.Name;
    }
}