namespace VolunteerVision.Domain.Core.Result;

public sealed record Error(string Code, string Message)
{
    public override string ToString() => $"{Code}:{Message}";
}
