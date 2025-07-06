using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.DTO.Departments;
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
            var departmentsDTO = departments.Adapt<List<DepartmentDTO>>();
            return Ok(departmentsDTO);
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
