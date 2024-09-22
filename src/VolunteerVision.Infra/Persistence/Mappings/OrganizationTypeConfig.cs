using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VolunteerVision.Domain.Resources.Organizations;

namespace VolunteerVision.Infra.Persistence.Mappings;

internal sealed class OrganizationTypeConfig : EntityTypeConfiguration<Organization>
{
    public override void Configure(EntityTypeBuilder<Organization> builder) => base.Configure(builder);
}
