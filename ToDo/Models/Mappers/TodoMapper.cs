using ToDo.Models.DTO;
using ToDo.Models.Entities;

namespace ToDo.Models.Mappers;

public class TodoMapper
{
    public static TodoResponseDto MapToDto(Todo todo)
    {
        return new TodoResponseDto
        {
            Id = todo.Id,
            UserId = todo.UserId,
            Title = todo.Title,
            Description = todo.Description,
            IsDone = todo.IsDone,
            CreatedAt = todo.CreatedAt,
            UpdatedAt = todo.UpdatedAt,
            CompletedAt = todo.CompletedAt,
            Category = todo.Category != null ? todo.Category.Name : null
        };
    }
}