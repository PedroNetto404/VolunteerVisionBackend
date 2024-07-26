using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VolunteerVision.Domain.Core.Abstractions;

namespace VolunteerVision.Infra.Persistence.EntityTypesConfiguration;

internal abstract class AggregateTypeConfiguration<TAggregate> :
    IEntityTypeConfiguration<TAggregate>
    where TAggregate : AggregateRoot
{
    public virtual void Configure(EntityTypeBuilder<TAggregate> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id);
    }
}
