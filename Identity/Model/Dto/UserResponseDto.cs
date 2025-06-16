namespace Identity.Model.Dto;

public record UserResponseDto(Guid userId, string username, DateTime createdAt);