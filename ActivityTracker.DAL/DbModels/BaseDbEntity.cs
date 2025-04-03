using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ActivityTracker.DAL.DbModels;

[EntityTypeConfiguration(typeof(BaseDbEntity))]
internal class BaseDbEntity
{
    public Guid Id { get; set; }
}

internal class BaseDbEntityConfiguration<TEntity>
    : IEntityTypeConfiguration<TEntity> where TEntity : BaseDbEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(b => b.Id);

        builder
            .Property(b => b.Id)
            .HasColumnName("id");
    }
}
