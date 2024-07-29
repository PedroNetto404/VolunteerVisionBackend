using Ardalis.SmartEnum;

namespace VolunteerVision.Domain;

public sealed class Role : SmartEnum<Role>
{
    public static readonly Role Admin = new(1, "Admin", "System Full Access");
    public static readonly Role CommonUser = new(2, "CommonUser", "System Basic Access");

    private Role(int id, string name, string description) : base(name, id)
    {
        Description = description;
    }

    public string Description { get; }
}