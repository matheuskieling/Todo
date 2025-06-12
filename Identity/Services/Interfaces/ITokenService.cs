using Identity.Model.Entities;

namespace Identity.Services;

public interface ITokenService
{
    public string GenerateToken(User user);
}