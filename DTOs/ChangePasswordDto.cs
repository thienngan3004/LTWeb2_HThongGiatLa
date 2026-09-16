using System.ComponentModel.DataAnnotations;

namespace Buoi2.DTOs;

public class ChangePasswordDto
{
    [Required(ErrorMessage = "Mật khẩu hiện tại không được để trống.")]
    [DataType(DataType.Password)]
    public string CurrentPassword { get; set; } = string.Empty;

    [Required(ErrorMessage = "Mật khẩu mới không được để trống.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu mới phải có độ dài từ 6 đến 100 ký tự.")]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$",
        ErrorMessage = "Mật khẩu mới phải chứa ít nhất 1 chữ hoa, 1 chữ thường, 1 số và 1 ký tự đặc biệt.")]
    public string NewPassword { get; set; } = string.Empty;

    [Required(ErrorMessage = "Xác nhận mật khẩu không được để trống.")]
    [DataType(DataType.Password)]
    [Compare("NewPassword", ErrorMessage = "Mật khẩu xác nhận không khớp với mật khẩu mới.")]
    public string ConfirmPassword { get; set; } = string.Empty;
}