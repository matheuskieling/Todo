using Microsoft.AspNetCore.Mvc;
using ToDo.Models.DTO;
using ToDo.Services.Interfaces;

namespace ToDo.Controllers;

[ApiController]
[Route("[controller]")]
public class TodosController(ITodoService service) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var todos = await service.GetAllAsync();
        return Ok(todos);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var todo = await service.GetByIdAsync(id);
        if (todo is null)
        {
            return NotFound();
        }
        return Ok(todo);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddTodo(AddTodoDto dto)
    {
        var todo = await service.AddTodoAsync(dto);
        return CreatedAtAction(nameof(AddTodo), new { Id = todo.Id }, todo);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTodo(Guid id, UpdateTodoDto dto)
    {
        var todo = await service.UpdateTodoAsync(id, dto);
        if (todo is null)
        {
            return NotFound();
        }
        return Ok(todo);
    }

    [HttpPatch("/complete/{id}")]
    public async Task<IActionResult> CompleteTodo(Guid id)
    {
        var todo = await service.CompleteAsync(id);
        if (!todo)
        {
            return NotFound();
        }
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodo(Guid id)
    {
        var todo = await service.DeleteAsync(id);
        if (!todo)
        {
            return NotFound();
        }
        return Ok();
    }
    
}