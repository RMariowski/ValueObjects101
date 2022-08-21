namespace ValueObjects101.Infrastructure.Auth;

public class UserContext : IUserContext
{
    public string GetEmail() => "some@user.com";
}
