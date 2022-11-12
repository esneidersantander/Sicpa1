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
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _context;
        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            return Ok(await _context.employee.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var dbEmployee = await _context.employee.FindAsync(id);
            if (dbEmployee == null)
                return BadRequest("Employee not found.");
            return Ok(dbEmployee);
        }
        [HttpPost]
        public async Task<ActionResult<List<Employee>>> CreateEmployee(Employee employee)
        {
            employee.created_date = DateTime.Now;
            employee.modified_date = DateTime.Now;
            employee.modified_by = "N/A";
            _context.employee.Add(employee);
            await _context.SaveChangesAsync();

            return Ok(await _context.employee.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(Employee employee)
        {
            var dbEmployee = await _context.employee.FindAsync(employee.id);
            if (dbEmployee == null)
                return BadRequest("Employee not found.");

            dbEmployee.modified_by = employee.modified_by;
            dbEmployee.modified_date = DateTime.Now;
            dbEmployee.email = employee.email;
            dbEmployee.name = employee.name;
            dbEmployee.position = employee.position;
            dbEmployee.surname = employee.surname;

            await _context.SaveChangesAsync();

            return Ok(await _context.employee.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employee>>> DeleteEmployee(int id)
        {
            var dbEmployee = await _context.employee.FindAsync(id);
            if (dbEmployee == null)
                return BadRequest("Employee not found.");

            _context.employee.Remove(dbEmployee);
            await _context.SaveChangesAsync();

            return Ok(await _context.employee.ToListAsync());
        }

    }
}
