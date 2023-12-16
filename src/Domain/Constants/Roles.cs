using CleanArchitecture.Domain.Extensions;

namespace CleanArchitecture.Domain.Constants;

public abstract class Roles
{
    public const string Administrator = nameof(Administrator);
    public const string User = nameof(User);
    public static string[] GetRoles => typeof(Roles).GetAllPublicConstantValues<string>();
}
