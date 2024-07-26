using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VolunteerVision.Domain.Resources.VoluntaryActions;

namespace VolunteerVision.Infra.Persistence.EntityTypesConfiguration;

internal sealed class ActionTypeConfig : AggregateTypeConfiguration<VoluntaryAction>
{
    public override void Configure(EntityTypeBuilder<VoluntaryAction> builder) => base.Configure(builder);
}
