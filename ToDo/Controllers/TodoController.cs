using Microsoft.AspNetCore.Authorization;
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
    
    [HttpGet("Filter")]
    public async Task<IActionResult> GetByCategory([FromQuery] string category)
    {
        var todos = await service.GetAllByCategoryAsync(category);
        return Ok(todos);
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

    [HttpPatch("Complete/{id}")]
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

    [HttpGet("Category")]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await service.GetCategoriesAsync();
        return Ok(categories);
    }
    
    [HttpPost("Category")]
    public async Task<IActionResult> AddCategory(AddCategoryDto dto)
    {
        var category = await service.AddCategoryAsync(dto.CategoryName);
        return CreatedAtAction(nameof(AddCategory), new { Id = category.Id }, category);
    }
    
    [HttpDelete("Category/{id}")]
    public async Task<IActionResult> DeleteCategory(Guid categoryId)
    {
        var success = await service.DeleteCategoryAsync(categoryId);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }
    
}