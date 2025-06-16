using Identity.Data;
using Identity.Model.Entities;
namespace Identity.Repositories.Interfaces;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public User? GetUserByUsername(string username)
    {
        return context.Users.FirstOrDefault(u => u.Username == username);
    }

    public User CreateUser(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
        return user;
    }
}