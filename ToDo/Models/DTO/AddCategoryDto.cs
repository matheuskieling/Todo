using System.ComponentModel.DataAnnotations;
using ToDo.Models.Entities;

namespace ToDo.Models.DTO;

public record AddCategoryDto(
    [Required] string CategoryName
);