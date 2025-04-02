using ActivityTracker.Core.WindowActivity;

namespace ActivityTracker;

public class Worker(
    ILogger<Worker> logger,
    ICurrentWindowInfoAccessor accessor) : BackgroundService
{
    private readonly ILogger<Worker> _logger = logger;
    private readonly ICurrentWindowInfoAccessor _accessor = accessor;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var info = _accessor.GetCurrentActiveAppName();

            if (_logger.IsEnabled(LogLevel.Information) && info != null)
            {
                _logger.LogInformation(
                    "Worker running at: {time} | appName: {currentAppName} | infoInApp: {info}",
                    DateTimeOffset.Now,
                    info.AppName,
                    info.InfoInApp);
            }

            await Task.Delay(2000, stoppingToken);
        }
    }
}
