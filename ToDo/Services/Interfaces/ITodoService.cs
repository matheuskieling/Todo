using ToDo.Models.DTO;
using ToDo.Models.Entities;

namespace ToDo.Services.Interfaces;

public interface ITodoService
{
    Task<List<Todo>> GetAllAsync();
    Task<Todo?> GetByIdAsync(Guid id);
    Task<Todo> AddTodoAsync(AddTodoDto todo);
    Task<bool> CompleteAsync(Guid id);
    Task<Todo?> UpdateTodoAsync(Guid id, UpdateTodoDto dto);
    Task<bool> DeleteAsync(Guid id);
}