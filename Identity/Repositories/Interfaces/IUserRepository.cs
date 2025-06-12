using Identity.Model.Entities;
namespace Identity.Repositories.Interfaces;

public interface IUserRepository
{
    public User? GetUser(string username, string password);
    public User CreateUser(User user);
}