namespace ToDo.Models.DTO;

public class TodoResponseDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    
    public required string Title { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public bool IsDone { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = null;
    public DateTime? CompletedAt { get; set; } = null;
    public string? Category { get; set; } = null;
}