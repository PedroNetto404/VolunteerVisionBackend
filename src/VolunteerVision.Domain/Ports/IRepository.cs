using VolunteerVision.Domain.Core.Abstractions;

namespace VolunteerVision.Domain.Ports;

public interface IRepository<TAggregateRoot>
    where TAggregateRoot : class, IAggregateRoot
{
    public Task<TAggregateRoot> GetByIdAsync(Guid id);

    public Task<IEnumerable<TAggregateRoot>> GetAllAsync(
        Func<IQueryable<TAggregateRoot>, IQueryable<TAggregateRoot>>? especification = null);
    
    public Task AddAsync(TAggregateRoot aggregateRoot);
    
    public Task UpdateAsync(TAggregateRoot aggregateRoot);
    
    public Task DeleteAsync(TAggregateRoot aggregateRoot);
}
