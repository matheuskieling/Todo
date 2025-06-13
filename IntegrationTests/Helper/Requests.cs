using ToDo.Models.DTO;

namespace IntegrationTests.Helper;

public static class Requests
{
    public static AddTodoRequestDto GetAddTodoDto(string title, string description, string categoryName)
    {
        var request = new AddTodoRequestDto(title, description, categoryName);
        return request;
    }
    public static UpdateTodoDto GetUpdateTodoDto(string? title, string? description, string? categoryName)
    {
        var request = new UpdateTodoDto(title, description, categoryName);
        return request;
    }

    public static AddCategoryDto GetAddCategoryDto(string categoryName)
    {
        var request = new AddCategoryDto(categoryName);
        return request;
    }
}