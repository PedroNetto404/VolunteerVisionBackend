using VolunteerVision.Domain.Core.Abstractions;

namespace VolunteerVision.Domain.Resources.VoluntaryActions.Events;

public sealed record VoluntaryActionCreated(Guid ActionId) : IDomainEvent;
