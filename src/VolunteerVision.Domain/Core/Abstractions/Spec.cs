using System.Linq.Expressions;

namespace VolunteerVision.Domain.Core.Abstractions;

public interface ISpec<TAggregateRoot>
    where TAggregateRoot : class, IAggregateRoot
{
    IQueryable<TAggregateRoot> ApplyCriteria(IQueryable<TAggregateRoot> query);
}

/// <summary>
/// Specification pattern implementation.
/// </summary>
/// <typeparam name="TAggregateRoot"></typeparam>
/// <typeparam name="TSpec"></typeparam>
public abstract class Spec<TAggregateRoot> : ISpec<TAggregateRoot>
    where TAggregateRoot : class, IAggregateRoot
{
    private readonly List<Expression<Func<TAggregateRoot, bool>>> _criteria = [];

    protected Spec<TAggregateRoot> Where(Expression<Func<TAggregateRoot, bool>> criteria)
    {
        _criteria.Add(criteria);
        return this;
    }

    public IQueryable<TAggregateRoot> ApplyCriteria(IQueryable<TAggregateRoot> query) =>
        _criteria.Aggregate(query, (current, criteria) => current.Where(criteria));
}