using ToDo.Models.DTO;
using ToDo.Models.Entities;
using ToDo.Repositories.Interfaces;
using ToDo.Services.Interfaces;

namespace ToDo.Services;

public class TodoService(ITodoRepository repository) : ITodoService
{
    public async Task<List<Todo>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<Todo?> GetByIdAsync(Guid id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task<Todo> AddTodoAsync(AddTodoDto dto)
    {
        return await repository.AddTodoAsync(dto);
    }

    public async Task<bool> CompleteAsync(Guid id)
    {
        return await repository.CompleteAsync(id);
    }

    public async Task<Todo?> UpdateTodoAsync(Guid id, UpdateTodoDto dto)
    {
        return await repository.UpdateTodoAsync(id, dto);
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        return repository.DeleteAsync(id);
    }
}