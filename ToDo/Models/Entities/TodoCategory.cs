using System.ComponentModel.DataAnnotations;

namespace ToDo.Models.Entities;

public class TodoCategory
{
    [Key]
    public Guid Id { get; set; }
    public required string Name { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = null;
}
