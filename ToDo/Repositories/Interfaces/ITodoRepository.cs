using ToDo.Models.DTO;
using ToDo.Models.Entities;

namespace ToDo.Repositories.Interfaces;

public interface ITodoRepository
{
    Task<List<Todo>> GetAllAsync();
    Task<Todo?> GetByIdAsync(Guid id);
    Task<Todo> AddTodoAsync(AddTodoDto dto);
    Task<bool> CompleteAsync(Guid id);
    Task<Todo?> UpdateTodoAsync(Guid id, UpdateTodoDto dto);
    Task<bool> DeleteAsync(Guid id);
}