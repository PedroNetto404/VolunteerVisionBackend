using Microsoft.EntityFrameworkCore;
using VolunteerVision.Domain.Core.Abstractions;
using VolunteerVision.Domain.Ports;

namespace VolunteerVision.Infra.Persistence;

internal sealed class Repository<TAggregateRoot>(
    VolunteerVisionDbContext context) :
    IRepository<TAggregateRoot>
    where TAggregateRoot : class, IAggregateRoot
{
    public Task<TAggregateRoot> GetByIdAsync(Guid id) =>
        context.Set<TAggregateRoot>()
            .FirstAsync(x => x.Id == id);

    public Task<IEnumerable<TAggregateRoot>> GetAllAsync(
        Func<IQueryable<TAggregateRoot>, IQueryable<TAggregateRoot>>? especification = null)
    {
        var query = context.Set<TAggregateRoot>().AsQueryable();
        query = especification?.Invoke(query) ?? query;

        return query.ToListAsync().ContinueWith(p => p.Result.AsEnumerable());
    }

    public Task AddAsync(TAggregateRoot aggregateRoot)
    {
        context.Set<TAggregateRoot>().Add(aggregateRoot);
        return context.SaveChangesAsync();
    }

    public Task UpdateAsync(TAggregateRoot aggregateRoot)
    {
        context.Set<TAggregateRoot>().Update(aggregateRoot);
        return context.SaveChangesAsync();
    }

    public Task DeleteAsync(TAggregateRoot aggregateRoot)
    {   
        context.Set<TAggregateRoot>().Remove(aggregateRoot);
        return context.SaveChangesAsync();
    }
}
