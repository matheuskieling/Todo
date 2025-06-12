using Identity.Data;
using Identity.Model.Entities;
namespace Identity.Repositories.Interfaces;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public User? GetUser(string username, string password)
    {
        return context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
    }

    public User CreateUser(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
        return user;
    }
}