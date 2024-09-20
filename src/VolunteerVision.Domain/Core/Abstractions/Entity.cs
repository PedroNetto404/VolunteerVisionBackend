namespace VolunteerVision.Domain.Core.Abstractions;

/// <summary>
/// Abstract class representing an entity in the domain.
/// </summary>
public abstract class Entity : IEquatable<Entity>, IEntity
{
    public Guid Id { get; } = Guid.NewGuid();

    public bool Equals(Entity? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Id == other.Id;
    }

    public override bool Equals(object? obj) =>
        obj is Entity entity && Equals(entity);

    public override int GetHashCode() =>
        Id.GetHashCode() * 17;

    public static bool operator ==(Entity? left, Entity? right) =>
        left?.Equals(right) ?? right is null;

    public static bool operator !=(Entity? left, Entity? right) =>
        !(left == right);
}

public abstract class AuditableEntity : Entity, IAuditableEntity
{
    public DateTime CreatedAtUtc { get; private set; } = DateTime.UtcNow;

    public DateTime UpdatedAtUtc { get; private set; } = DateTime.UtcNow;

    public DateTime? DeletedAtUtc { get; private set; }

    protected void OnUpdated() => UpdatedAtUtc = DateTime.UtcNow;

    protected void OnDeleted() => DeletedAtUtc = DateTime.UtcNow;
}