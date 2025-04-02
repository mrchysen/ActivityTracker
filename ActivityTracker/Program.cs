using ActivityTracker;
using ActivityTracker.Core.WindowActivity;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<ICurrentWindowInfoAccessor, CurrentWindowInfoAccessor>();

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
