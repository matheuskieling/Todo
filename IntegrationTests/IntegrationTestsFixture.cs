using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using IntegrationTests.Utils;
using Microsoft.AspNetCore.Mvc;
using ToDo.Models.DTO;
using ToDo.Models.Entities;

namespace IntegrationTests;

public class IntegrationTestsFixture : IDisposable
{
    public CustomWebApplicationFactory<Program> Factory { get; }
    public HttpClient Client { get; }
    public string Token = TestToken.FixedToken;

    public IntegrationTestsFixture()
    {
        Factory = new CustomWebApplicationFactory<Program>();
        Client = Factory.CreateClient();
        Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
    }

    public void Dispose()
    {
        Client.Dispose();
        Factory.Dispose();
    }
    
    public async Task<List<TodoResponseDto>> ListTodos()
    {
        var response = await Client.GetAsync("/Todos");
        response.EnsureSuccessStatusCode();
        var todos = await response.Content.ReadFromJsonAsync<List<TodoResponseDto>>();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(todos);
        return todos;

    }
    
    public async Task<TodoResponseDto> AddTodo(AddTodoRequestDto dto)
    {
        var response = await Client.PostAsJsonAsync("/Todos", dto);
        response.EnsureSuccessStatusCode();
        var todo = await response.Content.ReadFromJsonAsync<TodoResponseDto>();
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        Assert.NotNull(todo);
        return todo;
    }
    
    public async Task<TodoResponseDto> UpdateTodo(Guid id, UpdateTodoDto dto)
    {
        var response = await Client.PutAsJsonAsync($"/Todos/{id}", dto);
        response.EnsureSuccessStatusCode();
        var todo = await response.Content.ReadFromJsonAsync<TodoResponseDto>();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(todo);
        return todo;
    }
    
    public async Task DeleteTodo(Guid id)
    {
        var response = await Client.DeleteAsync($"/Todos/{id}");
        response.EnsureSuccessStatusCode();
    }
    
    public async Task CompleteTodo(Guid id)
    {
        var response = await Client.PatchAsync($"/Todos/Complete/{id}", null);
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    public async Task<TodoResponseDto?> GetTodoById(Guid id)
    {
        var response = await Client.GetAsync($"/Todos/{id}");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var todo = await response.Content.ReadFromJsonAsync<TodoResponseDto>();
        return todo;
    }
    
    public async Task<List<TodoResponseDto>> GetTodosByCategory(string categoryName)
    {
        var response = await Client.GetAsync($"/Todos/Filter/?category={categoryName}");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var todos = await response.Content.ReadFromJsonAsync<List<TodoResponseDto>>();
        Assert.NotNull(todos);
        return todos;
    }
    
    
    public async Task<List<TodoCategory>> GetCategories()
    {
        var response = await Client.GetAsync($"/Todos/Category");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var categorires = await response.Content.ReadFromJsonAsync<List<TodoCategory>>();
        Assert.NotNull(categorires);
        return categorires;
    }
    
    public async Task<TodoCategory> AddCategory(AddCategoryDto dto)
    {
        var response = await Client.PostAsJsonAsync("/Todos/Category", dto);
        response.EnsureSuccessStatusCode();
        var category = await response.Content.ReadFromJsonAsync<TodoCategory>();
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        Assert.NotNull(category);
        return category;
    }
    
    public async Task DeleteCategory(Guid id)
    {
        var response = await Client.DeleteAsync($"/Todos/Category/{id}");
        response.EnsureSuccessStatusCode();
    }
}
