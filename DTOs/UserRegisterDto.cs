using System.ComponentModel.DataAnnotations;

namespace Buoi2.DTOs;

public class UserRegisterDto
{
    [Required(ErrorMessage = "Email không được để trống.")]
    [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
    [StringLength(100, ErrorMessage = "Email không được vượt quá 100 ký tự.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Tên đăng nhập không được để trống.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Tên đăng nhập phải từ 3 đến 50 ký tự.")]
    [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Tên đăng nhập chỉ được chứa chữ cái, số và dấu gạch dưới (_).")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Mật khẩu không được để trống.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải có độ dài từ 6 đến 100 ký tự.")]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$",
        ErrorMessage = "Mật khẩu phải chứa ít nhất 1 chữ hoa, 1 chữ thường, 1 số và 1 ký tự đặc biệt.")]
    public string Password { get; set; } = string.Empty;
}