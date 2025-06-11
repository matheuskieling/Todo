using Microsoft.AspNetCore.Mvc;

namespace ToDo.Controllers;

[ApiController]
[Route("[controller]")]
public class TodosController : ControllerBase
{
    private readonly ILogger<TodosController> _logger;

    public TodosController(ILogger<TodosController> logger)
    {
        _logger = logger;
        
    }
}