using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Buoi2.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; } // Khách hàng gửi đồ (Khóa ngoại trỏ tới bảng Users)
        [ForeignKey("UserId")]
        public Users? User { get; set; }

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow; // Ngày tạo đơn

        public DateTime? DeliveryDate { get; set; } // Ngày hẹn trả đồ cho khách

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; } = 0; // Tổng tiền của cả đơn hàng

        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = "Pending";
        // Trạng thái đơn: 
        // - Pending (Mới tiếp nhận)
        // - Processing (Đang giặt)
        // - Completed (Đã giặt xong)
        // - Delivered (Đã giao cho khách)
        // - Cancelled (Đã hủy)

        [Required]
        [MaxLength(50)]
        public string PaymentStatus { get; set; } = "Unpaid";
        // Trạng thái thanh toán: 
        // - Unpaid (Chưa thanh toán)
        // - Paid (Đã thanh toán)

        [MaxLength(255)]
        public string? Note { get; set; } // Ghi chú chung cho cả đơn (ví dụ: giặt gấp, giao giờ hành chính...)

        // Danh sách chi tiết các món đồ/dịch vụ trong đơn này
        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}