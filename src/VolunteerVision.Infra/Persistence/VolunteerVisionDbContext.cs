﻿using Microsoft.EntityFrameworkCore;
using VolunteerVision.Domain.Resources.Users;

namespace VolunteerVision.Infra.Persistence;

internal class VolunteerVisionDbContext(
    DbContextOptions<VolunteerVisionDbContext> options
) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VolunteerVisionDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
