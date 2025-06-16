using Microsoft.EntityFrameworkCore;
using ToDo.Data;
using ToDo.Models.DTO;
using ToDo.Models.Entities;
using ToDo.Models.Mappers;
using ToDo.Repositories.Interfaces;

namespace ToDo.Repositories;

public class TodoRepository(ApplicationDbContext context) : ITodoRepository
{
    public async Task<List<TodoResponseDto>> GetAllAsync(Guid userId)
    {
        return await context.Todos
            .Include(t => t.Category)
            .Where(t => t.UserId == userId)
            .Select(t => TodoMapper.MapToDto(t)).ToListAsync();
    }

    public async Task<TodoResponseDto?> GetByIdAsync(Guid id)
    {
        var todo = await context.Todos
            .Include(t => t.Category)
            .Where(t => t.Id == id)
            .FirstOrDefaultAsync();
        if (todo is null)
        {
            return null;
        }

        return TodoMapper.MapToDto(todo);
    }
    
    public async Task<TodoResponseDto> AddTodoAsync(AddTodoRequestDto requestDto, Guid userId)
    {
        var category = await context.TodoCategories.FirstOrDefaultAsync(ct => ct.Name == requestDto.CategoryName);
        var todo = new Todo()
        {
            Title = requestDto.Title,
            UserId = userId,
            Description = requestDto.Description,
            Category = category,
        };
        await context.Todos.AddAsync(todo);
        await context.SaveChangesAsync();
        return TodoMapper.MapToDto(todo);
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

    public async Task<TodoResponseDto?> UpdateTodoAsync(Guid id, UpdateTodoDto dto)
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
        
        return TodoMapper.MapToDto(todo);
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
    
    public async Task<List<TodoResponseDto>> GetAllByCategoryAsync(Guid userId, string categoryName)
    {
        return await context.Todos
            .Include(t => t.Category)
            .Where(t => t.UserId == userId && t.Category != null && t.Category.Name == categoryName)
            .Select(t => TodoMapper.MapToDto(t)).ToListAsync();
    }

    public async Task<List<TodoCategory>> GetCategoriesAsync(Guid userId)
    {
        var categories = await context.TodoCategories.Where(c => c.UserId == userId).ToListAsync();
        return categories;
    }

    public async Task<TodoCategory> AddCategoryAsync(string categoryName, Guid userId)
    {
        var category = new TodoCategory { Name = categoryName , UserId = userId };
        await context.TodoCategories.AddAsync(category);
        await context.SaveChangesAsync();
        return category;
    }

    public async Task<bool> DeleteCategoryAsync(Guid categoryId)
    {
        var category = await context.TodoCategories.FindAsync(categoryId);
        if (category is null)
        {
            return false;
        }

        context.TodoCategories.Remove(category);
        await context.SaveChangesAsync();
        return true;
    }
}