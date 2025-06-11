using System.ComponentModel.DataAnnotations;
using ToDo.Models.Entities;

namespace ToDo.Models.DTO;

public record AddTodoDto(
    [Required] string Title,
    string? Description,
    TodoCategory? Category
);