using System.Text.RegularExpressions;
using VolunteerVision.Domain.Core.Result;

namespace VolunteerVision.Domain.Resources.Users.ValueObjects;

public sealed partial record Email
{
    public string Value { get; }
    public string Domain 
    {
        get 
        {
            var atIndex = Value.IndexOf('@');
            var domainPart = Value[(atIndex + 1)..];

            var dotIndex = domainPart.IndexOf('.');
            if(dotIndex == -1)
            {
                return string.Empty;
            }

            return domainPart[..dotIndex];
        }
    }
    private Email(string value) => Value = value;

    public static Result<Email> New(string value) 
    {
        if(string.IsNullOrWhiteSpace(value))
        {
            return new Error("email", "Email cannot be null or empty");
        }

        if(!EmailRegex().IsMatch(value))
        {
            return new Error("email", "Email is in invalid format");
        }

        return new Email(value);
    }

    [GeneratedRegex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$")]
    private static partial Regex EmailRegex();
}
