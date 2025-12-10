using DemoAPI.Data;
using DemoAPI.Dtos;
using DemoAPI.Mapper;
using DemoAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentDto department)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var new_dept = new Department
            {
                Name = department.Name,
                Description = department.Description,
                HeadId = department.HeadId,
            };
            await _context.Departments.AddAsync(new_dept);
            await _context.SaveChangesAsync();
            return Ok(new {IsSuccess = true});
        }

        [HttpGet]
        public async Task<IActionResult> GetAddDepartments()
        {
            var depts = await _context.Departments.Select(d => d.ToResponse()).ToListAsync();
            return Ok(depts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddDepartments(Guid id)
        {
            var dept = await _context.Departments.FirstOrDefaultAsync(d => d.Id == id);
            if (dept == null) return NotFound();
            return Ok(dept.ToResponse());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(Guid id, [FromBody] UpdateDepartmentDto updateDepartment)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var dept = await _context.Departments.FirstOrDefaultAsync(d => d.Id == id);
            if (dept == null) return NotFound();

            dept.UpdateFromDto(updateDepartment);
            await _context.SaveChangesAsync();
            return Ok(new {IsSuccess = true});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveDepartment(Guid id)
        {
            var dept = await _context.Departments.FirstOrDefaultAsync(d => d.Id == id);
            if (dept == null) return NotFound();

            _context.Departments.Remove(dept);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
