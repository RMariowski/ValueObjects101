using ValueObjects101.Domain.Shared.ValueObjects;

namespace ValueObjects101.Infrastructure.Auth;

public interface IUserContext
{
    Email GetEmail();
}
