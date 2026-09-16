using System.ComponentModel.DataAnnotations;

namespace Buoi2.DTOs;

public class UserRoleDto
{
    [Required(ErrorMessage = "Vai trò (Role) không được để trống.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Vai trò phải có độ dài từ 2 đến 50 ký tự.")]
    [RegularExpression(@"^(Admin|User|Manager|Staff)$", ErrorMessage = "Vai trò không hợp lệ. Chỉ chấp nhận các giá trị: Admin, User, Manager, Staff.")]
    public string Role { get; set; } = "User";
}