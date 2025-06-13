using ToDo.Models.DTO;
using ToDo.Models.Entities;
using ToDo.Repositories.Interfaces;
using ToDo.Services.Interfaces;

namespace ToDo.Services;

public class TodoService(ITodoRepository repository, CurrentUser currentUser) : ITodoService
{
    public async Task<List<TodoResponseDto>> GetAllAsync()
    {
        return await repository.GetAllAsync(currentUser.UserId);
    }

    public async Task<TodoResponseDto> GetByIdAsync(Guid id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task<TodoResponseDto> AddTodoAsync(AddTodoDto dto)
    {
        return await repository.AddTodoAsync(dto, currentUser.UserId);
    }

    public async Task<bool> CompleteAsync(Guid id)
    {
        return await repository.CompleteAsync(id);
    }

    public async Task<TodoResponseDto> UpdateTodoAsync(Guid id, UpdateTodoDto dto)
    {
        return await repository.UpdateTodoAsync(id, dto);
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        return repository.DeleteAsync(id);
    }

    public async Task<List<TodoResponseDto>> GetAllByCategoryAsync(string categoryName)
    {
        return await repository.GetAllByCategoryAsync(currentUser.UserId, categoryName);
    }

    public async Task<List<TodoCategory>> GetCategoriesAsync()
    {
        return await repository.GetCategoriesAsync(currentUser.UserId);
    }

    public async Task<TodoCategory> AddCategoryAsync(string categoryName)
    {
        return await repository.AddCategoryAsync(categoryName, currentUser.UserId);
    }

    public async Task<bool> DeleteCategoryAsync(Guid categoryId)
    {
        return await repository.DeleteCategoryAsync(categoryId);
    }
}