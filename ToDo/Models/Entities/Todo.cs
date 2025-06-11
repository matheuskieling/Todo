using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ToDo.Models.Entities;

[Index(nameof(Title), IsUnique = true)]
public class Todo
{
    [Key]
    public Guid Id { get; set; }
    
    public required string Title { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public bool IsDone { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = null;
    public DateTime? CompletedAt { get; set; } = null;
    public TodoCategory? Category { get; set; } = null;
}
