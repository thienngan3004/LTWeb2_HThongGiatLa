using Buoi2.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    // Constructor nhận Options (chuỗi kết nối DB) từ Program.cs truyền vào
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Khai báo tập hợp bảng Users trong Database
    public DbSet<Users> Users { get; set; }
    
    public DbSet<Service> Services { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderDetail> OrderDetails { get; set; }

    //public DbSet<Category> Categories { get; set; }

    // Optional: Cấu hình Fluent API nếu muốn ràng buộc dữ liệu sâu hơn ở tầng DB
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Ví dụ: Đảm bảo Username và Email là duy nhất (Unique)
        modelBuilder.Entity<Users>()
            .HasIndex(u => u.Username)
            .IsUnique();

        modelBuilder.Entity<Users>()
            .HasIndex(u => u.Email)
            .IsUnique();
    }
}