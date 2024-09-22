using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VolunteerVision.Domain.Resources.Donations;

namespace VolunteerVision.Infra.Persistence.Mappings;

internal sealed class DonationTypeConfig : EntityTypeConfiguration<Donation>
{
    public override void Configure(EntityTypeBuilder<Donation> builder) => base.Configure(builder);
}
