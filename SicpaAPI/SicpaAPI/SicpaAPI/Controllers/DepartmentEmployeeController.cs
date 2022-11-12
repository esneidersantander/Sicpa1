using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SicpaAPI.Data;
using SicpaAPI.Dtos;
using SicpaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SicpaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentEmployeeController : ControllerBase
    {
        private readonly DataContext _context;
        public DepartmentEmployeeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<DepartmentEmployeeController>>> GetDepartmentEmployees()
        {

            List<DepartmentEmployee> departmentemployeesAux = new List<DepartmentEmployee>();
            var departmentemployees = from de in _context.departmentemployee
                                      join d in _context.department on de.id_department equals d.id
                                      join e in _context.employee on de.id_employee equals e.id
                                      select new DepartmentEmployee
                                      {
                                          id = de.id,
                                          created_by = de.created_by,
                                          created_date = de.created_date,
                                          modified_by = de.modified_by,
                                          modified_date = de.modified_date,
                                          status = de.status,
                                          id_department = de.id_department,
                                          id_employee = de.id_employee,
                                          department = d,
                                          employee = e
                                      };

            departmentemployeesAux = departmentemployees.ToList<DepartmentEmployee>();

            return Ok(departmentemployeesAux);
        }
        [HttpPost]
        public async Task<ActionResult<List<Department>>> CreateDepartmentEmployee(DepartmentEmployeeDto departmentEmployee)
        {
            departmentEmployee.created_date = DateTime.Now;
            departmentEmployee.modified_date = DateTime.Now;
            departmentEmployee.modified_by = "N/A";
            _context.departmentemployee.Add(departmentEmployee);
            await _context.SaveChangesAsync();

            return Ok(await _context.department.ToListAsync());
        }
    }
}
