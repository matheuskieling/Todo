using Identity.Model.Entities;
using Identity.Repositories.Interfaces;
using Identity.Services.Interfaces;

namespace Identity.Services;

public class UserService(IUserRepository repository) : IUserService
{
    public User? GetUser(string username, string password)
    {
        return repository.GetUser(username, password);
    }

    public User CreateUser(string username, string password)
    {
        var user = new User
        {
            Username = username,
            Password = password
        };
        return repository.CreateUser(user);
    }
}