using VolunteerVision.Domain.Core.Abstractions;

namespace VolunteerVision.Domain.Resouces.VoluntaryActions.Events;

public sealed record VoluntaryActionCreated(Guid ActionId) : IDomainEvent;
