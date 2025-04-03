using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ActivityTracker.Core.WindowActivity;

namespace ActivityTracker.DAL.DbModels;

[EntityTypeConfiguration(typeof(CurrentActivityWindowInfoDbConfiguration))]
internal class CurrentActivityWindowInfoDb : BaseDbEntity
{
    public DateTime DateTime { get; set; }

    public string AppName { get; set; } = string.Empty;

    public string SubInfo { get; set; } = string.Empty;
}

internal class CurrentActivityWindowInfoDbConfiguration 
    : BaseDbEntityConfiguration<CurrentActivityWindowInfoDb>
{
    public override void Configure(EntityTypeBuilder<CurrentActivityWindowInfoDb> builder)
    {
        base.Configure(builder);

        builder.ToTable("current_activity_window_infos");

        builder
            .Property(b => b.AppName)
            .HasColumnName("app_name")
            .HasMaxLength(64)
            .IsRequired();

        builder
            .Property(b => b.SubInfo)
            .HasMaxLength(CurrentWindowInfoAccessor.SubInfoLength)
            .HasColumnName("sub_info");

        builder
            .Property(b => b.DateTime)
            .HasColumnName("datetime")
            .IsRequired();
    }
}


