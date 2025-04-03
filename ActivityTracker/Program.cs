using ActivityTracker.Core.WindowActivity;
using ActivityTracker.DAL;
using ActivityTracker.WorkerServices;
using ActivityTracker.WorkerServices.MigrationExtension;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<ICurrentWindowInfoAccessor, CurrentWindowInfoAccessor>();
builder.Services.AddDbContext<ApplicationDbContext>(op => 
    op.UseSqlite(builder.Configuration.GetConnectionString("sqllite"),
    x => x.MigrationsAssembly("ActivityTracker.DAL")));
builder.Services.AddHostedService<Worker>();

var host = builder.Build();

await host.EnsureMigrations();

host.Run();
