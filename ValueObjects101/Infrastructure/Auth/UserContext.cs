using ValueObjects101.Domain.Shared.ValueObjects;

namespace ValueObjects101.Infrastructure.Auth;

public class UserContext : IUserContext
{
    public Email GetEmail() => new("some@user.com");
}
