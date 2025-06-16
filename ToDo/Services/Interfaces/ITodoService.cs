using ToDo.Models.DTO;
using ToDo.Models.Entities;

namespace ToDo.Services.Interfaces;

public interface ITodoService
{
    Task<List<TodoResponseDto>> GetAllAsync();
    Task<TodoResponseDto?> GetByIdAsync(Guid id);
    Task<TodoResponseDto> AddTodoAsync(AddTodoRequestDto todoRequest);
    Task<bool> CompleteAsync(Guid id);
    Task<TodoResponseDto?> UpdateTodoAsync(Guid id, UpdateTodoDto dto);
    Task<bool> DeleteAsync(Guid id);
    Task<List<TodoResponseDto>> GetAllByCategoryAsync(string categoryName);

    Task<List<TodoCategory>> GetCategoriesAsync();
    Task<TodoCategory> AddCategoryAsync(string categoryName);
    Task<bool> DeleteCategoryAsync(Guid categoryId);
}