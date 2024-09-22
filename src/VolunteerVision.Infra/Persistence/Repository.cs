using System;
using Ardalis.Specification.EntityFrameworkCore;
using VolunteerVision.Domain.Core.Abstractions;
using VolunteerVision.Domain.Ports;

namespace VolunteerVision.Infra.Persistence;

internal class Repository<T>(VolunteerVisionDbContext context) : 
    RepositoryBase<T>(context), 
    IRepository<T>
where T : AggregateRoot; 
