using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafariRest.Database.Models;

public class User
{
    [Column("id")]
    public int Id { get; set; }

    [Column("username", TypeName = "varchar(32)")]
    public required string Username { get; set; }

    [Column("password", TypeName = "varchar(64)")]
    public required string Password { get; set; }

    [Column("email", TypeName = "varchar(258)")]
    public required string Email { get; set; }

    [Column("role"), Required]
    public ERole Role { get; set; } = ERole.User;
}

public enum ERole
{
    User = 0,
    Admin = 1
}
