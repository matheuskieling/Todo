using System.ComponentModel.DataAnnotations;
using ToDo.Models.Entities;

namespace ToDo.Models.DTO;

public record AddTodoRequestDto(
    [Required] string Title,
    string? Description,
    string? CategoryName
);