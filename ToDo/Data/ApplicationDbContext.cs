using Identity.Model.Entities;
using Microsoft.EntityFrameworkCore;
using ToDo.Models.Entities;

namespace ToDo.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Todo> Todos { get; set; }
    public DbSet<TodoCategory> TodoCategories { get; set; }
    
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>().ToTable("Todos", "todo");
        modelBuilder.Entity<TodoCategory>().ToTable("TodoCategories", "todo").HasData([
            new TodoCategory{ Name = "Work", Id= Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow},
            new TodoCategory{ Name = "House", Id= Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow},
            new TodoCategory{ Name = "Pets", Id= Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow},
            new TodoCategory{ Name = "Others", Id= Guid.NewGuid(), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow},
        ]);
        modelBuilder.Entity<User>().ToTable("Users", "idenaatity");
    }
}