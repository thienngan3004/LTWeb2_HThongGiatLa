using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Buoi2.Models;

[Table("Users")] 
public class Users
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)] 
    public string Username { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)] 
    public string Email { get; set; } = string.Empty;

    [Required]
    public byte[] PasswordHash { get; set; } = Array.Empty<byte>();

    [Required]
    public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();

    // Admin: Quản trị hệ thống
    // User: Khách hàng
    [Required]
    [MaxLength(50)]
    public string Role { get; set; } = "User";

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    public bool IsActive { get; set; } = true;
}