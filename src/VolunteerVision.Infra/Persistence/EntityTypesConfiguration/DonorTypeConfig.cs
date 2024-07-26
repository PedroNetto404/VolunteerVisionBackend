using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VolunteerVision.Domain.Resources.Donors;

namespace VolunteerVision.Infra.Persistence.EntityTypesConfiguration;

internal sealed class DonorTypeConfig : AggregateTypeConfiguration<Donor>
{
    public override void Configure(EntityTypeBuilder<Donor> builder) => base.Configure(builder);
}
