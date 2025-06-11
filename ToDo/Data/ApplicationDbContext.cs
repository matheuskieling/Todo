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
}