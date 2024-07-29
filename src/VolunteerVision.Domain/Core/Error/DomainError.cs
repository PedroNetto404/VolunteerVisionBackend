using VolunteerVision.Domain.Core.Abstractions;

namespace VolunteerVision.Domain.Core.Error;

public abstract record DomainAggregateError<TEntity, TDomainError> : DomainError<TDomainError>
    where TEntity : class, IEntity
    where TDomainError : DomainAggregateError<TEntity, TDomainError>, new()
{
    protected DomainAggregateError(string code, string message) : base(code, message) { }

    public virtual string Resource { get; } = typeof(TEntity).Name.ToLower();
}

public abstract record DomainError<TDomainError> : Error
    where TDomainError : DomainError<TDomainError>, new()
{
    private static readonly Lazy<TDomainError> _instance = new(() => new TDomainError());

    protected DomainError(string code, string message) : base(code, message) { }

    public static TDomainError Instance => _instance.Value;
}
