using Identity.Model.Entities;

namespace Identity.Services.Interfaces;

public interface IUserService
{
    public User? GetUser(string username, string password);
    public User CreateUser(string username, string password);
}