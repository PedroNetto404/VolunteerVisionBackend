namespace VolunteerVision.Application.Ports;

public interface IUserContextProvider
{
    Guid UserId { get; }

    bool IsAuthenticated { get; }

    string Email { get; }
}
