namespace WebApplication1.Models
{
    public class Departments
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string Location { get; set; }
        public string Manager { get; set; }

        // Navigation property for related employees
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();




    }
}
