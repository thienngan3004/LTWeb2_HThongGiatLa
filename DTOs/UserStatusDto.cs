using System.ComponentModel.DataAnnotations;

namespace Buoi2.DTOs
{
    public class UserStatusDto
    {
        [Required(ErrorMessage = "Trạng thái kích hoạt (IsActive) không được để trống.")]
        public bool? IsActive { get; set; }
    }
}