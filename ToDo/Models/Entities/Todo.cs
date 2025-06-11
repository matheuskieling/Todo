using System.ComponentModel.DataAnnotations;

namespace ToDo.Models.Entities;

public class Todo
{
    [Key]
    public Guid Id { get; set; }
    
    public required string Title { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = null;
    public DateTime? CompletedAt { get; set; } = null;
    public TodoCategory? Category { get; set; } = null;
}
