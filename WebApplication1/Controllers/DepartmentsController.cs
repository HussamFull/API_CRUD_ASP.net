using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: api/Departments
        [HttpGet]
        public IActionResult GetDepartments()
        {
            var departments = context.Department.ToList();
            return Ok(departments);
        }
        // GET: api/Departments/5
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
        // POST: api/Departments
        [HttpPost]
        public IActionResult Create(Departments request)
        {
            if (request == null)
            {
                return BadRequest("Department cannot be null");
            }
            context.Department.Add(request);
            context.SaveChanges();
            return Ok();
        }

        // PUT: api/Departments/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, Departments request)
        {
           
            var department = context.Department.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            department.DepartmentName = request.DepartmentName;
            department.Location = request.Location;
            department.Manager = request.Manager;
            context.SaveChanges();
            return Ok(department);
        }
        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var department = context.Department.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            context.Department.Remove(department);
            context.SaveChanges();
            return Ok();
        }
    }
}
