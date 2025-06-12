using System.ComponentModel.DataAnnotations;

namespace Identity.Model.Dto;

public record RegisterRequest(
    [Required] string Username,
    [Required] string Password
);