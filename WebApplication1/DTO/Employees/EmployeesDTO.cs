﻿namespace WebApplication1.DTO.Employees
{
    public class EmployeesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        //public int? DepartmentId { get; set; } // Foreign key to Departments
    }
}
