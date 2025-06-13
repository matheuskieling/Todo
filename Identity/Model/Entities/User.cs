using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Identity.Model.Entities;

[Index(nameof(Username), IsUnique = true)]
public class User
{
    [Key]
    public Guid Id { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
}