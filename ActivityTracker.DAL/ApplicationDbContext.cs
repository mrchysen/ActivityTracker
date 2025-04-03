using ActivityTracker.DAL.DbModels;
using Microsoft.EntityFrameworkCore;

namespace ActivityTracker.DAL;

public class ApplicationDbContext : DbContext
{
    internal DbSet<CurrentActivityWindowInfoDb> CurrentActivityWindowInfoDbs { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new CurrentActivityWindowInfoDbConfiguration().Configure(
            modelBuilder.Entity<CurrentActivityWindowInfoDb>());
    }
}
