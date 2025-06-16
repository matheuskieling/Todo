using Identity.Model.Dto;
using Identity.Model.Entities;

namespace Identity.Model.Mappers;

public static class UserMapper
{
    public static UserResponseDto ToUserResponseDto(User user)
    {
        return new UserResponseDto(user.Id, user.Username, user.CreatedAt);
    }
}