using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Buoi2.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order? Order { get; set; }

        [Required]
        public int ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public Service? Service { get; set; }

        [Required]
        public int Quantity { get; set; } = 1; // Số lượng (ví dụ: 3 kg hoặc 2 cái áo)

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; } // Giá tại thời điểm đặt đơn

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; } // Thành tiền (Quantity * UnitPrice)

        [MaxLength(255)]
        public string? Note { get; set; } // Ghi chú riêng cho món đồ (ví dụ: Áo bị dính bẩn ở cổ...)
    }
}