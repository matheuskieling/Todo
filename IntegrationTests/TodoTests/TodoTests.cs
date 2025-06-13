using System.Net;
using System.Net.Http.Json;
using IntegrationTests.Helper;
using ToDo.Models.DTO;

namespace IntegrationTests.TodoTests;

public class TodoTests : IDisposable
{
    private readonly IntegrationTestsFixture _fixture;

    public TodoTests()
    {
        _fixture = new IntegrationTestsFixture();
    }
    public void Dispose()
    {
        _fixture.Dispose();
    }

    [Fact]
    public async Task CreateTodo_ShouldReturn201()
    {
        var initDate = DateTime.UtcNow;
        var dto = Requests.GetAddTodoDto("title", "desc", "House");
        var todoResponse = await _fixture.AddTodo(dto);
        var afterSave = DateTime.UtcNow;
        
        var todos = await _fixture.ListTodos();
        Assert.Contains(todos, t => t.Id == todoResponse.Id && t.Title == dto.Title && t.Category == dto.CategoryName);
        Assert.Single(todos);
        var todoFromDb = todos.First();
        
        Assert.NotNull(todoFromDb);
        Assert.Equal(dto.Title, todoFromDb.Title);
        Assert.Equal(dto.CategoryName, todoFromDb.Category);
        Assert.Equal(dto.Description, todoFromDb.Description);
        Assert.True(todoFromDb.CreatedAt >= initDate && todoFromDb.CreatedAt <= afterSave);
        Assert.Null(todoFromDb.UpdatedAt);
        Assert.False(todoFromDb.IsDone);
        Assert.Null(todoFromDb.CompletedAt);

    }
    
    [Fact]
    public async Task ListTodo_ShouldReturn200()
    {
        var todos = await _fixture.ListTodos();
        Assert.Empty(todos);
    }

    [Fact]
    public async Task UpdateTodo_ShouldReturn200()
    {
        var beforeCreateDate = DateTime.UtcNow;
        var dto = Requests.GetAddTodoDto("title", "desc", "House");
        var todoResponse = await _fixture.AddTodo(dto);
        var afterCreateDate = DateTime.UtcNow;
        
        var beforeUpdateDate = DateTime.UtcNow;
        
        var updateDto = Requests.GetUpdateTodoDto("new title", "new desc", "Work");
        await _fixture.UpdateTodo(todoResponse.Id, updateDto);
        var afterUpdateDate = DateTime.UtcNow;

        var todoList = await _fixture.ListTodos();
        Assert.Single(todoList);
        var updatedTodoFromDb = todoList.First();
        
        Assert.Equal(updateDto.Title, updatedTodoFromDb.Title);
        Assert.Equal(updateDto.CategoryName, updatedTodoFromDb.Category);
        Assert.Equal(updateDto.Description, updatedTodoFromDb.Description);
        Assert.True(updatedTodoFromDb.CreatedAt >= beforeCreateDate && updatedTodoFromDb.CreatedAt <= afterCreateDate);
        Assert.True(updatedTodoFromDb.UpdatedAt >= beforeUpdateDate && updatedTodoFromDb.UpdatedAt <= afterUpdateDate);
    }
    
    [Fact]
    public async Task DeleteTodo_ShouldReturn200()
    {
        var dto = Requests.GetAddTodoDto("title", "desc", "House");
        await _fixture.AddTodo(dto);
        var todoListPostSave = await _fixture.ListTodos();
        Assert.Single(todoListPostSave);
        var todo = todoListPostSave.First();

        await _fixture.DeleteTodo(todo.Id);
        
        var todoListPostDelete = await _fixture.ListTodos();
        Assert.Empty(todoListPostDelete);
    }
    
    [Fact]
    public async Task CompleteTodo_ShouldReturn200()
    {
        var dto = Requests.GetAddTodoDto("title", "desc", "House");
        var todoResponse = await _fixture.AddTodo(dto);
        
        var beforeCompleteDate = DateTime.UtcNow;
        await _fixture.CompleteTodo(todoResponse.Id);
        var afterCompleteDate = DateTime.UtcNow;

        var todoList = await _fixture.ListTodos();
        Assert.Single(todoList);
        var completedTodoFromDb = todoList.First();
        
        Assert.True(completedTodoFromDb.IsDone);
        Assert.True(completedTodoFromDb.CompletedAt >= beforeCompleteDate && completedTodoFromDb.CompletedAt <= afterCompleteDate);
    }

    [Fact]
    public async Task GetTodoById_ShouldReturnTodo_WhenItExists()
    {
        var dto = Requests.GetAddTodoDto("title", "desc", "House");
        var todoResponse = await _fixture.AddTodo(dto);
        var todoFromDb = await _fixture.GetTodoById(todoResponse.Id);
        Assert.NotNull(todoFromDb);
        Assert.Equal(dto.Title, todoFromDb.Title);
        Assert.Equal(dto.Description, todoFromDb.Description);
        Assert.Equal(dto.CategoryName, todoFromDb.Category);
    }
    
    [Fact]
    public async Task GetTodosByCategory_ShouldReturnTodos_WhenTheyExist()
    {
        for (int i = 0; i < 5; i++)
        {
            var dto = Requests.GetAddTodoDto(i.ToString(), $"desc{i}", "House");
            await _fixture.AddTodo(dto);
        }
        
        var anotherDto = Requests.GetAddTodoDto("title", $"desc", "Pets");
        await _fixture.AddTodo(anotherDto);
        
        var todosByCategory = await _fixture.GetTodosByCategory("House");
        Assert.Equal(5, todosByCategory.Count);
    }
    
    [Fact]
    public async Task GetCategories_ShouldReturn200()
    {
        var categories = await _fixture.GetCategories();
        Assert.NotEmpty(categories);
    }
    
    [Fact]
    public async Task AddCategory_ShouldReturn201()
    {
        var dto = Requests.GetAddCategoryDto("New Category");
        await _fixture.AddCategory(dto);
        var categories = await _fixture.GetCategories();
        Assert.Contains(categories, c => c.Name == dto.CategoryName);
    }
    
    [Fact]
    public async Task DeleteCategory_ShouldReturn201()
    {
        var categories = await _fixture.GetCategories();
        Assert.NotEmpty(categories);
        var categoryToDelete = categories.First();
        await _fixture.DeleteCategory(categoryToDelete.Id);
        var categoriesAfterDelete = await _fixture.GetCategories();
        Assert.DoesNotContain(categoriesAfterDelete, c => c.Id == categoryToDelete.Id);
        
    }
}