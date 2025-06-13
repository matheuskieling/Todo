using ToDo.Models.DTO;
using ToDo.Models.Entities;

namespace ToDo.Repositories.Interfaces;

public interface ITodoRepository
{
    Task<List<TodoResponseDto>> GetAllAsync(Guid userId);
    Task<TodoResponseDto> GetByIdAsync(Guid id);
    Task<TodoResponseDto> AddTodoAsync(AddTodoDto dto, Guid userId);
    Task<bool> CompleteAsync(Guid id);
    Task<TodoResponseDto> UpdateTodoAsync(Guid id, UpdateTodoDto dto);
    Task<bool> DeleteAsync(Guid id);

    Task<List<TodoResponseDto>> GetAllByCategoryAsync(Guid userId, string categoryName);

    Task<List<TodoCategory>> GetCategoriesAsync(Guid userId);
    Task<TodoCategory> AddCategoryAsync(string categoryName, Guid userId);
    Task<bool> DeleteCategoryAsync(Guid categoryId);
}