using Identity.Data;
using Identity.Model.Dto;
using Identity.Services;
using Identity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{

    private readonly ILogger<AuthController> _logger;
    private readonly ITokenService _tokenService;
    private readonly AppDbContext _context;
    private readonly IUserService _userService;

    public AuthController(ILogger<AuthController> logger, ITokenService tokenService, AppDbContext context, IUserService userService)
    {
        _logger = logger;
        _tokenService = tokenService;
        _context = context;
        _userService = userService;
    }

    [HttpPost("Register")]
    public IActionResult Register(RegisterRequest registerRequest)
    {
        var user = _userService.CreateUser(registerRequest.Username, registerRequest.Password);
        return CreatedAtAction(nameof(Register), new { id = user.Id }, user);
    }

    [HttpPost("Login")]
    public IActionResult Login(TokenGenerationRequest request)
    {
        var user = _userService.GetUser(request.Username, request.Password);
        if (user is null)
        {
            return Unauthorized();
        }

        var token = _tokenService.GenerateToken(user);
        return Ok(new
        {
            UserId = user.Id,
            Token = token
        });
    }
}