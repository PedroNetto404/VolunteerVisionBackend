using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VolunteerVision.Domain.Resources.Donors;

namespace VolunteerVision.Infra.Persistence.Mappings;

internal sealed class DonorTypeConfig : EntityTypeConfiguration<Donor>
{
    public override void Configure(EntityTypeBuilder<Donor> builder) => base.Configure(builder);
}
