using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Text;

namespace ActivityTracker.Core.WindowActivity;

public record CurrentActivityWindowInfo(string AppName, string SubInfo, DateTime DateTime);

public interface ICurrentWindowInfoAccessor
{
    CurrentActivityWindowInfo? GetCurrentActiveAppName();
}

public class CurrentWindowInfoAccessor(ILogger<CurrentWindowInfoAccessor> logger) : ICurrentWindowInfoAccessor
{
    private readonly ILogger<CurrentWindowInfoAccessor> _logger = logger;

    public const int SubInfoLength = 256;

    /// <summary>
    /// Возвращает дескриптор активного окна
    /// </summary>
    /// <returns></returns>
    [DllImport("user32.dll")] 
    private static extern IntPtr GetForegroundWindow();

    /// <summary>
    /// Кладёт в text какую-то информацию окна по дескриптору
    /// </summary>
    /// <param name="hWnd"></param>
    /// <param name="text"></param>
    /// <param name="count"></param>
    /// <returns></returns>

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

    /// <summary>
    /// Возвращает PID процесса по дескриптору
    /// </summary>
    /// <param name="hWnd"></param>
    /// <param name="processId"></param>
    /// <returns></returns>
    [DllImport("user32.dll")]
    private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

    public CurrentActivityWindowInfo? GetCurrentActiveAppName()
    {
        var subInfoBuffer = new StringBuilder(SubInfoLength);

        IntPtr activeWindowHandle = GetForegroundWindow();

        GetWindowThreadProcessId(activeWindowHandle, out uint processId);

        if (processId == 0)
        {
            _logger.LogWarning("Не получилось получить PID текущего процесса");

            return null;
        }

        var subInfoResult = GetWindowText(activeWindowHandle, subInfoBuffer, SubInfoLength);

        try
        {
            Process process = Process.GetProcessById((int)processId);

            return new CurrentActivityWindowInfo(
                process.ProcessName, 
                subInfoResult > 0 ? subInfoBuffer.ToString() : string.Empty,
                DateTime.Now); 
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Ошибка при получении информации о процессе (PID: {ProcessId})", processId);

            return null; 
        }
    }
}