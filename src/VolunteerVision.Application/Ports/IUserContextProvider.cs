namespace VolunteerVision.Application;

public interface IUserContextProvider
{
    Guid UserId { get; }

    bool IsAuthenticated { get; }

    string Email { get; }
}
