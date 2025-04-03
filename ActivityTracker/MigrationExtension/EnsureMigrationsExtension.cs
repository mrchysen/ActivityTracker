using ActivityTracker.DAL;
using Microsoft.EntityFrameworkCore;

namespace ActivityTracker.WorkerServices.MigrationExtension;

public static class EnsureMigrationsExtension
{
    public static async Task<IHost> EnsureMigrations(this IHost host)
    {
        using var scope = host.Services.CreateScope();

        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
        await db.Database.MigrateAsync();

        MigratorFlag.IsMigrationsEnsured = true;

        return host;
    }
}

internal static class MigratorFlag
{
    internal static bool IsMigrationsEnsured = false;
}