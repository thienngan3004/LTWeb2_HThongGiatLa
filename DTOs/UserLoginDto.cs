using System.ComponentModel.DataAnnotations;

namespace Buoi2.DTOs
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Tên đăng nhập (hoặc Email) không được để trống.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tên đăng nhập phải từ 3 đến 50 ký tự.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mật khẩu không được để trống.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải có độ dài từ 6 đến 100 ký tự.")]
        public string Password { get; set; } = string.Empty;
    }
}