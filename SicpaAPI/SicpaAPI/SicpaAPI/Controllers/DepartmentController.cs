using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SicpaAPI.Data;
using SicpaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SicpaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DataContext _context;
        public DepartmentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Department>>> GetDepartments()
        {
            return Ok(await _context.department.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var dbDepartment = await _context.department.FindAsync(id);
            if (dbDepartment == null)
                return BadRequest("Department not found.");
            return Ok(dbDepartment);
        }
        [HttpPost]
        public async Task<ActionResult<List<Department>>> CreateDepartment(Department department)
        {
            department.created_date = DateTime.Now;
            department.modified_date = DateTime.Now;
            department.modified_by = "N/A";
            _context.department.Add(department);
            await _context.SaveChangesAsync();

            return Ok(await _context.department.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Department>>> UpdateDepartment(Department department)
        {
            var dbDepartment = await _context.department.FindAsync(department.id);
            if (dbDepartment == null)
                return BadRequest("Department not found.");

            dbDepartment.modified_by = department.modified_by;
            dbDepartment.modified_date = DateTime.Now;
            dbDepartment.description = department.description;
            dbDepartment.name = department.name;
            dbDepartment.phone = department.phone;
            dbDepartment.id_enterprise = department.id_enterprise;

            await _context.SaveChangesAsync();

            return Ok(await _context.department.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Department>>> DeleteDepartment(int id)
        {
            var dbDepartment = await _context.department.FindAsync(id);
            if (dbDepartment == null)
                return BadRequest("Department not found.");

            _context.department.Remove(dbDepartment);
            await _context.SaveChangesAsync();

            return Ok(await _context.department.ToListAsync());
        }

    }
}
