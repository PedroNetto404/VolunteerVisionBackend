using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VolunteerVision.Domain.Resouces.Organizations;

namespace VolunteerVision.Infra.Persistence.EntityTypesConfiguration;

internal sealed class OrganizationTypeConfig : AggregateTypeConfiguration<Organization>
{
    public override void Configure(EntityTypeBuilder<Organization> builder) => base.Configure(builder);
}
