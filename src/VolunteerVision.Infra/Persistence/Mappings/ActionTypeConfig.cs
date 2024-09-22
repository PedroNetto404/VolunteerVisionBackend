using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VolunteerVision.Domain.Resources.VoluntaryActions;

namespace VolunteerVision.Infra.Persistence.Mappings;

internal sealed class ActionTypeConfig : EntityTypeConfiguration<VoluntaryAction>
{
    public override void Configure(EntityTypeBuilder<VoluntaryAction> builder) => base.Configure(builder);
}
