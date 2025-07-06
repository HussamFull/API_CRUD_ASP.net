namespace WebApplication1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public int? DepartmentId { get; set; } // Foreign key to Departments
        public Departments Department { get; set; } // Navigation property
    }
}
