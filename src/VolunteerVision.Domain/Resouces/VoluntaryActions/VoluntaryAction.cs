using VolunteerVision.Domain.Core.Abstractions;
using VolunteerVision.Domain.Core.Error;
using VolunteerVision.Domain.Resouces.VoluntaryActions.Events;

namespace VolunteerVision.Domain.Resouces.VoluntaryActions;

public sealed class VoluntaryAction : AggregateRoot
{

    //#TODO: create factory method and configure private constructor
    public static ErrorOr<VoluntaryAction> Create()
    {
        var action = new VoluntaryAction();
        action.RaiseDomainEvent(new VoluntaryActionCreated(action.Id));

        throw new NotImplementedException();
    }

    // Required by EF Core
#pragma warning disable CS0628 // New protected member declared in sealed type
    protected VoluntaryAction() { }
#pragma warning restore CS0628 // New protected member declared in sealed type
}
