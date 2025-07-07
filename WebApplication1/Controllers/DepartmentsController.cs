using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.DTO.Departments;
using WebApplication1.Models;
using System.Linq; // <<<< أضف هذا السطر هنا


namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        ApplicationDbContext context = new ApplicationDbContext();

        // GET:Departments
        [HttpGet]
        public IActionResult GetDepartments()
        {

            var departments = context.Department.ToList();
            var departmentsDTO = departments.Adapt<List<DepartmentDTO>>();
            return Ok(departmentsDTO);
        }




        // GET: Details 
        [HttpGet("{id}")]
        public IActionResult GetDepartment(int id)
        {
            var department = context.Department.Find( id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }



        // POST: Create 
        [HttpPost]
        public IActionResult Create(CreateDepartmentDTO requestDTO)
        {
            if (requestDTO == null)
            {
                return BadRequest("Department cannot be null");
            }
            var department = requestDTO.Adapt<Departments>();
            context.Department.Add(department);
            context.SaveChanges();
            return Ok();
        }




        // PUT: Update 
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateDepartmentDTO requestDTO)
        {
            // 1. Find the existing department in the database
            var department = context.Department.Find(id);
            // 2. Check if the department exists
            if (department == null)
            {
                return NotFound();
            }
            // 3. Update the properties of the found department with values from the DTO
            department.DepartmentName = requestDTO.DepartmentName;
            department.Location = requestDTO.Location;
            department.Manager = requestDTO.Manager;
            context.Department.Update(department); 
            context.SaveChanges();
            // 5. Return the updated department (or a success message)
            return Ok(department);
        }




        // DELETE:
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var department = context.Department.Find(id);

            if (department == null)
            {
                return NotFound();
            }

            // (جديد) جلب الموظفين المرتبطين وتعديلهم
            // تأكد أن Employee موجود كـ DbSet في ApplicationDbContext
            var employeesInDepartment = context.Employees.Where(e => e.DepartmentId == id).ToList();

            foreach (var employee in employeesInDepartment)
            {
                // تأكد أن DepartmentId في نموذج Employee هو int? (nullable)
                employee.DepartmentId = null;
            }

            context.Department.Remove(department);
            context.SaveChanges(); // سيتم حفظ تحديثات الموظفين وحذف القسم هنا

            return Ok("Department deleted, associated employees updated.");
        }
    }
}
