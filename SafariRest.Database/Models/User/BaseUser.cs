using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafariRest.Database.Models;

public class BaseUser
{
    [Column("id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("username", TypeName = "varchar(32)"), Required]
    public required string Username { get; set; }

    [Column("password", TypeName = "varchar(64)"), Required]
    public required string Password { get; set; }

    [Column("email", TypeName = "varchar(258)"), Required]
    public required string Email { get; set; }
}
