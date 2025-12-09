using DemoAPI.Data;
using DemoAPI.Dtos;
using DemoAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterEmployee([FromBody] RegisterEmployeeDto employee)
        {
            if (!ModelState.IsValid)
            {
                // Validation failed
                return BadRequest(ModelState);
            }
            var new_employee = new Employee
            {
                Id = Guid.NewGuid(),
                Name = employee.Name,
                Email = employee.Email,
                DateOfBirth = employee.DateOfBirth,
                StartDate = employee.StartDate,
                Salary = employee.Salary,
                Position = employee.Position.ToString() // if Employee.Position is string
                                                   // or just employee.Position if Employee.Position is enum
            };

            await _context.Employees.AddAsync(new_employee);
            await _context.SaveChangesAsync();
            return Ok(new_employee);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e=>e.Id == id);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            return Ok(employees);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, [FromBody] UpdateEmployeeDto employee)
        {
            //search employee
            var exist_employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
            //if null return NotFound
            if (exist_employee == null) return NotFound();
            
            //if found proceed to update
            exist_employee.Name = employee.Name;
            exist_employee.Email = employee.Email;
            exist_employee.StartDate = employee.StartDate;
            exist_employee.DateOfBirth = employee.DateOfBirth;
            exist_employee.Salary = employee.Salary;
            exist_employee.Position = employee.Position.ToString();

            //persist the updated data
            await _context.SaveChangesAsync();
            return Ok(exist_employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Invalid employee id.");

            var result = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null) return NotFound();
            _context.Employees.Remove(result);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
