using Microsoft.AspNetCore.Mvc;
using ToDo.Models.DTO;
using ToDo.Services.Interfaces;

namespace ToDo.Controllers;

/// <summary>
/// Controller responsável por gerenciar tarefas e categorias.
/// </summary>
[ApiController]
[Route("[controller]")]
public class TodosController(ITodoService service) : ControllerBase
{
    /// <summary>
    /// Obtém todas as tarefas do usuário atual.
    /// </summary>
    /// <returns>Lista de tarefas associadas ao usuário.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var todos = await service.GetAllAsync();
        return Ok(todos);
    }

    /// <summary>
    /// Obtém uma tarefa pelo ID.
    /// </summary>
    /// <param name="id">ID da tarefa.</param>
    /// <returns>Detalhes da tarefa.</returns>
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

    /// <summary>
    /// Filtra tarefas por categoria.
    /// </summary>
    /// <param name="category">Nome da categoria.</param>
    /// <returns>Lista de tarefas filtradas.</returns>
    [HttpGet("Filter/")]
    public async Task<IActionResult> GetByCategory([FromQuery] string category)
    {
        var todos = await service.GetAllByCategoryAsync(category);
        return Ok(todos);
    }

    /// <summary>
    /// Adiciona uma nova tarefa.
    /// </summary>
    /// <param name="requestDto">Dados da nova tarefa.</param>
    /// <returns>Tarefa criada.</returns>
    [HttpPost]
    public async Task<IActionResult> AddTodo(AddTodoRequestDto requestDto)
    {
        var todo = await service.AddTodoAsync(requestDto);
        return CreatedAtAction(nameof(AddTodo), new { Id = todo.Id }, todo);
    }

    /// <summary>
    /// Atualiza uma tarefa existente.
    /// </summary>
    /// <param name="id">ID da tarefa.</param>
    /// <param name="dto">Dados atualizados da tarefa.</param>
    /// <returns>Tarefa atualizada.</returns>
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

    /// <summary>
    /// Marca uma tarefa como concluída.
    /// </summary>
    /// <param name="id">ID da tarefa.</param>
    /// <returns>Status da operação.</returns>
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

    /// <summary>
    /// Exclui uma tarefa.
    /// </summary>
    /// <param name="id">ID da tarefa.</param>
    /// <returns>Status da operação.</returns>
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

    /// <summary>
    /// Obtém todas as categorias do usuário atual.
    /// </summary>
    /// <returns>Lista de categorias.</returns>
    [HttpGet("Category")]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await service.GetCategoriesAsync();
        return Ok(categories);
    }

    /// <summary>
    /// Adiciona uma nova categoria.
    /// </summary>
    /// <param name="dto">Dados da nova categoria.</param>
    /// <returns>Categoria criada.</returns>
    [HttpPost("Category")]
    public async Task<IActionResult> AddCategory(AddCategoryDto dto)
    {
        var category = await service.AddCategoryAsync(dto.CategoryName);
        return CreatedAtAction(nameof(AddCategory), new { Id = category.Id }, category);
    }

    /// <summary>
    /// Exclui uma categoria.
    /// </summary>
    /// <param name="id">ID da categoria.</param>
    /// <returns>Status da operação.</returns>
    [HttpDelete("Category/{id}")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        var success = await service.DeleteCategoryAsync(id);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }
}