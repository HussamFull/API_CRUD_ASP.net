using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Departments> Department { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public object Employee { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=LAPTOP-25Q2HGGN;Database=Api_web1;TrustServerCertificate=True;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // هنا يمكنك تكوين العلاقات إذا لزم الأمر
            // تأكد أن DepartmentId في Employee يمكن أن يكون null إذا كنت تنوي تعيينه إلى null
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany() // أو WithMany(d => d.Employees) إذا كان لديك خاصية Employees في نموذج Department
                .HasForeignKey(e => e.DepartmentId)
                .IsRequired(false); // <<<< هذا يجعل المفتاح الخارجي قابلاً للقيم الفارغة في قاعدة البيانات
        }
    }
    
}
