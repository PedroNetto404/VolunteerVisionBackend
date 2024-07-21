namespace VolunteerVision.Domain.Abstractions;

/// <summary>
/// Abstract class representing an entity in the domain.
/// </summary>
public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; private set; }

    protected Entity() => Id = Guid.NewGuid();

    public bool Equals(Entity? other) =>
        other is not null && Id == other.Id;

    public override bool Equals(object? obj) =>
        obj is Entity entity && Equals(entity);

    public override int GetHashCode() =>
        Id.GetHashCode() * 17;

    public static bool operator ==(Entity? left, Entity? right) =>
        left?.Equals(right) ?? right is null;

    public static bool operator !=(Entity? left, Entity? right) =>
        !(left == right);
}