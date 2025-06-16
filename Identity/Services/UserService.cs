using Identity.Infra;
using Identity.Model.Entities;
using Identity.Repositories.Interfaces;
using Identity.Services.Interfaces;

namespace Identity.Services;

public class UserService(IUserRepository repository) : IUserService
{
    public User? GetUser(string username, string password)
    {
        var user = repository.GetUserByUsername(username);
        if (user is null || !PasswordHasher.VerifyPassword(password, user.Password, user.PasswordSalt))
        {
            return null;
        }

        return user;
    }

    public User CreateUser(string username, string password)
    {
        var (hash, salt) = PasswordHasher.HashPassword(password);
        var user = new User
        {
            Username = username,
            Password = hash,
            PasswordSalt = salt,
        };
        return repository.CreateUser(user);
    }
}