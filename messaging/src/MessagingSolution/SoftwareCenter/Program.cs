using Marten;
using Marten.Events.Projections;
using Oakton.Resources;
using SoftwareCenter.Handlers;
using Wolverine;
using Wolverine.Kafka;
using Wolverine.Marten;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    if (builder.Environment.IsDevelopment())
    {
        options.RequireHttpsMetadata = false;
    }
});
// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    
});

var databaseConnectionString = builder.Configuration.GetConnectionString("database") ??
                               throw new ChaosException("Need a database connection string");

var kafkaConnectionString = builder.Configuration.GetConnectionString("kafka") ??
                            throw new ChaosException("Need a Kafka Broker");

var marten = builder.Services.AddMarten(opts =>
{
    opts.Connection(databaseConnectionString);
    opts.Projections.Snapshot<Tech>(SnapshotLifecycle.Inline);
    opts.Projections.Snapshot<Vendor>(SnapshotLifecycle.Inline);
    opts.Projections.Snapshot<SoftwareTitle>(SnapshotLifecycle.Inline);
    if (builder.Environment.IsDevelopment())
    {
        opts.AutoCreateSchemaObjects = Weasel.Core.AutoCreate.All;
    }

}).IntegrateWithWolverine().UseLightweightSessions();

if (builder.Environment.IsProduction())
{
    marten.OptimizeArtifactWorkflow();
}

builder.Host.UseWolverine(options =>
{
    options.Services.AddResourceSetupOnStartup();
    options.Policies.AutoApplyTransactions();
    options.UseKafka(kafkaConnectionString);
    
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");

}


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();