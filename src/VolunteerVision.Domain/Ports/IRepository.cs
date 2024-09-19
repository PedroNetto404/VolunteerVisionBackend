using Ardalis.Specification;
using VolunteerVision.Domain.Core.Abstractions;

namespace VolunteerVision.Domain.Ports;

public interface IRepository<TAggregateRoot> : IRepositoryBase<TAggregateRoot>
    where TAggregateRoot : class, IAggregateRoot;