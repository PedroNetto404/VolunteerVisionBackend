using VolunteerVision.Domain.Resources.Donations;
using VolunteerVision.Domain.Resources.Donors;
using VolunteerVision.Domain.Resources.Users;
using VolunteerVision.Domain.Resources.VoluntaryActions;

namespace VolunteerVision.Domain.Ports;

public interface IUnitOfWork
{
    IRepository<User> Users { get; }

    IRepository<VoluntaryAction> VoluntaryActions { get; }

    IRepository<Donation> Donations { get; }

    IRepository<Donor> Donors { get; }

    Task<bool> SaveChangesAsync();
}
