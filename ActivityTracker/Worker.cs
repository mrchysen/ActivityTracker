using ActivityTracker.Core.WindowActivity;
using ActivityTracker.WorkerServices.MigrationExtension;

namespace ActivityTracker.WorkerServices;

public class Worker(
    ILogger<Worker> logger,
    ICurrentWindowInfoAccessor accessor) : BackgroundService
{
    private readonly ILogger<Worker> _logger = logger;
    private readonly ICurrentWindowInfoAccessor _accessor = accessor;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while(!MigratorFlag.IsMigrationsEnsured) 
        { 
            await Task.Delay(100, stoppingToken); 
        }

        while (!stoppingToken.IsCancellationRequested)
        {
            var info = _accessor.GetCurrentActiveAppName();

            if (_logger.IsEnabled(LogLevel.Information) && info != null)
            {
                _logger.LogInformation(
                    "Worker running at: {time} | appName: {currentAppName} | infoInApp: {info}",
                    info.DateTime,
                    info.AppName,
                    info.SubInfo);
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}
