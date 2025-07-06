using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.DTO.Employees;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        ApplicationDbContext context = new ApplicationDbContext();

        // GET: api/Employees
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = context.Employees.ToList();
            var employeesDTO = employees.Adapt<List<EmployeesDTO>>();
            return Ok(employeesDTO);
        }
        // GET: api/Departments/5
        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employees = context.Employees.Find(id);
            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }
        // POST: api/Employees
        [HttpPost]
        public IActionResult Create(CreateEmployeeDTO requestDTO)
        {
            if (requestDTO == null)
            {
                return BadRequest("Employees cannot be null");
            }
            var employee = requestDTO.Adapt<Employee>();
            context.Employees.Add(employee);
            context.SaveChanges();
            return Ok();
        }

        // PUT: api/Departments/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee request)
        {

            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            employee.Name = request.Name;
            employee.Position = request.Position;
            employee.Salary = request.Salary;
            context.SaveChanges();
            return Ok(employee);
        }
        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            context.Employees.Remove(employee);
            context.SaveChanges();
            return Ok();
        }
    }
}
