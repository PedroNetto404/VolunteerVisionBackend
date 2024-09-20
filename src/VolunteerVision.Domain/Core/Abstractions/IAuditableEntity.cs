namespace VolunteerVision.Domain.Core.Abstractions;

public interface IAuditableEntity : IEntity
{
    public DateTime CreatedAtUtc { get; }
    public DateTime UpdatedAtUtc { get; }
    public DateTime? DeletedAtUtc { get; }
}
