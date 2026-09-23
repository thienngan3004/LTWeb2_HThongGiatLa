using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Buoi2.Models
{
    [Table("Services")]
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string ServiceName { get; set; } = string.Empty; // Ví dụ: Giặt ướt sấy khô, Giặt giày, Là hơi...

        public string? Description { get; set; } // Mô tả chi tiết dịch vụ

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } // Giá tiền (theo kg hoặc theo cái)

        [Required]
        [MaxLength(50)]
        public string Unit { get; set; } = "Kg"; // Đơn vị tính: Kg, Cái, Đôi...

        public bool IsActive { get; set; } = true; // Dịch vụ còn kinh doanh hay không
    }
}