using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VolunteerVision.Domain.Core.Abstractions;

namespace VolunteerVision.Infra.Persistence.Mappings;

public abstract class AuditableEntityTypeConfiguration<TAuditableEntity> :
    EntityTypeConfiguration<TAuditableEntity>
    where TAuditableEntity : class, IAuditableEntity
{
    public override void Configure(EntityTypeBuilder<TAuditableEntity> builder)
    {
        base.Configure(builder);

        builder.Property(p => p.CreatedAtUtc).IsRequired();
        builder.Property(p => p.UpdatedAtUtc).IsRequired();
        builder.Property(p => p.DeletedAtUtc);
        builder.HasQueryFilter(q => q.DeletedAtUtc == null);
    }
}
