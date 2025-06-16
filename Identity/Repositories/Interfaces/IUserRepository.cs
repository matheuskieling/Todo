using Identity.Model.Entities;
namespace Identity.Repositories.Interfaces;

public interface IUserRepository
{
    public User? GetUserByUsername(string username);
    public User CreateUser(User user);
}