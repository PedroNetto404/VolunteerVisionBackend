using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VolunteerVision.Domain.Resources.Users;
using VolunteerVision.Domain.Resources.Users.Enums;
using VolunteerVision.Domain.Resources.Users.ValueObjects;

namespace VolunteerVision.Infra.Persistence.Mappings;

public sealed class UserMapping : AuditableEntityTypeConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(p => p.Email)
            .HasMaxLength(100)
            .IsRequired()
            .HasConversion(p => p.Value, p => Email.New(p));

        builder.Property(p => p.HashedPassword)
            .IsRequired();

        builder.Property(p => p.Role)
            .HasMaxLength(100)
            .IsRequired()
            .HasConversion(
                p => p.Name,
                p => Role.FromName(p, true));

        builder.OwnsOne(p => p.RefreshToken, propBuilder =>
        {
            propBuilder.Property(p => p.Value).IsRequired();    
            propBuilder.Property(p => p.Expiration).IsRequired();   
        });
        
        builder.HasIndex(p => p.Email).IsUnique();
        
        base.Configure(builder);
    }
}

