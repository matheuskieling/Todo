using Identity.Model.Dto;
using Identity.Model.Entities;

namespace Identity.Services.Interfaces;

public interface IUserService
{
    public User? GetUser(string username, string password);
    public UserResponseDto CreateUser(string username, string password);
}