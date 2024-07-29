using VolunteerVision.Domain.Core.Abstractions;

namespace VolunteerVision.Domain.Ports;

public interface IRepository<TAggregateRoot>
    where TAggregateRoot : class, IAggregateRoot
{
    public Task<TAggregateRoot?> GetByIdAsync(Guid id);
    public Task<IEnumerable<TAggregateRoot>> GetAllAsync(ISpec<TAggregateRoot> especification);
    public Task<TAggregateRoot?> GetOneAsync(ISpec<TAggregateRoot> especification);
    public Task AddAsync(TAggregateRoot aggregateRoot);
    public Task UpdateAsync(TAggregateRoot aggregateRoot);
    public Task DeleteAsync(TAggregateRoot aggregateRoot);
}
