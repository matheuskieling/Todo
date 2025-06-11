using System.ComponentModel.DataAnnotations;
using ToDo.Models.Entities;

namespace ToDo.Models.DTO;

public record UpdateTodoCategoryDto(
    [Required] string Name
);