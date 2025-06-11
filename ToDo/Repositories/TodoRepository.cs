using Microsoft.EntityFrameworkCore;
using ToDo.Data;
using ToDo.Models.DTO;
using ToDo.Models.Entities;
using ToDo.Repositories.Interfaces;

namespace ToDo.Repositories;

public class TodoRepository(ApplicationDbContext context) : ITodoRepository
{
    public async Task<List<Todo>> GetAllAsync()
    {
        return await context.Todos.ToListAsync();
    }

    public async Task<Todo?> GetByIdAsync(Guid id)
    {
        return await context.Todos.FindAsync(id);
    }

    public async Task<Todo> AddTodoAsync(AddTodoDto dto)
    {
        var category = await context.TodoCategories.FirstOrDefaultAsync(ct => ct.Name == dto.CategoryName);
        var todo = new Todo()
        {
            Title = dto.Title,
            Description = dto.Description,
            Category = category,
        };
        await context.Todos.AddAsync(todo);
        await context.SaveChangesAsync();
        return todo;
    }

    public async Task<bool> CompleteAsync(Guid id)
    {
        var todo = await context.Todos.FindAsync(id);
        if (todo is null)
        {
            return false;
        }
        
        todo.UpdatedAt = DateTime.UtcNow;
        todo.CompletedAt = DateTime.UtcNow;
        todo.IsDone = true;

        context.Todos.Update(todo);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<Todo?> UpdateTodoAsync(Guid id, UpdateTodoDto dto)
    {
        var todo = await context.Todos.FindAsync(id);
        var category = await context.TodoCategories.FirstOrDefaultAsync(ct => ct.Name == dto.CategoryName);
        if (todo is null)
        {
            return null;
        }
        todo.Title = dto.Title ?? todo.Title;
        todo.Description = dto.Description ?? todo.Description;
        todo.Category = category ?? todo.Category;
        todo.UpdatedAt = DateTime.UtcNow;
        
        context.Todos.Update(todo);
        await context.SaveChangesAsync();
        
        return todo;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var todo = await context.Todos.FindAsync(id);
        if (todo is null)
        {
            return false;
        }
        context.Todos.Remove(todo);
        await context.SaveChangesAsync();
        
        return true;
    }
}