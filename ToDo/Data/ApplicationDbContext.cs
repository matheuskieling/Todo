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
            new TodoCategory
            {
                Name = "Work",
                Id = Guid.Parse("08237ce3-24c8-4504-8548-e1661abadcd4"),
                CreatedAt = DateTime.SpecifyKind(new DateTime(2025, 1, 1), DateTimeKind.Utc),
                UpdatedAt = DateTime.SpecifyKind(new DateTime(2025, 1, 1), DateTimeKind.Utc),
                UserId = Guid.Parse("573440b8-55e8-4f69-a7fc-e693718c9b45")
            },
            new TodoCategory
            {
                Name = "House",
                Id = Guid.Parse("75cd5777-ecfc-4012-af5d-2f2c4491220e"),
                CreatedAt = DateTime.SpecifyKind(new DateTime(2025, 1, 1), DateTimeKind.Utc),
                UpdatedAt = DateTime.SpecifyKind(new DateTime(2025, 1, 1), DateTimeKind.Utc),
                UserId = Guid.Parse("573440b8-55e8-4f69-a7fc-e693718c9b45")
            },
            new TodoCategory
            {
                Name = "Pets",
                Id = Guid.Parse("710a4d1f-d814-4311-bdb6-ee60c69d937d"),
                CreatedAt = DateTime.SpecifyKind(new DateTime(2025, 1, 1), DateTimeKind.Utc),
                UpdatedAt = DateTime.SpecifyKind(new DateTime(2025, 1, 1), DateTimeKind.Utc),
                UserId = Guid.Parse("573440b8-55e8-4f69-a7fc-e693718c9b45")
            },
            new TodoCategory
            {
                Name = "Others",
                Id = Guid.Parse("4e3b1dcf-8010-47c2-a712-45bf8cce1877"),
                CreatedAt = DateTime.SpecifyKind(new DateTime(2025, 1, 1), DateTimeKind.Utc),
                UpdatedAt = DateTime.SpecifyKind(new DateTime(2025, 1, 1), DateTimeKind.Utc),
                UserId = Guid.Parse("573440b8-55e8-4f69-a7fc-e693718c9b45")
            }
        ]);
        modelBuilder.Entity<User>().ToTable("Users", "identity");
    }
}