using VolunteerVision.Domain.Core.Error;

namespace VolunteerVision.Domain;

public sealed record CannotSaveChanges : DomainError<CannotSaveChanges>
{
    public CannotSaveChanges() : base("persistence", "Cannot save changes")
    {
    }
}
