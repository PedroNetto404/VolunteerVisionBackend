using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VolunteerVision.Domain.Core.Abstractions;

namespace VolunteerVision.Infra.Persistence.Mappings;

public abstract class EntityTypeConfiguration<TEntity> :
    IEntityTypeConfiguration<TEntity>
    where TEntity : class, IEntity
{
    public virtual void Configure(
        EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id);
    }
}
