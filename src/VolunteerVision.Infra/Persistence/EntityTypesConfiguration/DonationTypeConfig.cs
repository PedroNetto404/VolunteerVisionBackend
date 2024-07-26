using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VolunteerVision.Domain.Resources.Donations;

namespace VolunteerVision.Infra.Persistence.EntityTypesConfiguration;

internal sealed class DonationTypeConfig : AggregateTypeConfiguration<Donation>
{
    public override void Configure(EntityTypeBuilder<Donation> builder) => base.Configure(builder);
}
