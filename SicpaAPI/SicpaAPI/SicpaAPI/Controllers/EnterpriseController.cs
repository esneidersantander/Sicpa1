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
    public class EnterpriseController : ControllerBase
    {
        private readonly DataContext _context;
        public EnterpriseController(DataContext context) 
        { 
            _context=context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Enterprise>>> GetEnterprises()
        {
            return Ok(await _context.enterprise.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Enterprise>> GetEnterprise(int id)
        {
            var dbEnterprise = await _context.enterprise.FindAsync(id);
            if (dbEnterprise == null)
                return BadRequest("Enterprise not found.");
            return Ok(dbEnterprise);
        }
        [HttpPost]
        public async Task<ActionResult<List<Enterprise>>> CreateEnterprise(Enterprise enterprise)
        {
            enterprise.created_date = DateTime.Now;
            enterprise.modified_date = DateTime.Now;
            enterprise.modified_by = "N/A";
            _context.enterprise.Add(enterprise);
            await _context.SaveChangesAsync();

            return Ok(await _context.enterprise.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Enterprise>>> UpdateEnterprise(Enterprise enterprise)
        {
            var dbEnterprise = await _context.enterprise.FindAsync(enterprise.id);
            if (dbEnterprise == null)
                return BadRequest("Enterprise not found.");

            dbEnterprise.modified_by = enterprise.modified_by;
            dbEnterprise.modified_date = DateTime.Now;
            dbEnterprise.address = enterprise.address;
            dbEnterprise.name = enterprise.name;
            dbEnterprise.phone = enterprise.phone;


            await _context.SaveChangesAsync();

            return Ok(await _context.enterprise.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Enterprise>>> DeleteEnterprise(int id)
        {
            var dbEnterprise = await _context.enterprise.FindAsync(id);
            if (dbEnterprise == null)
                return BadRequest("Enterprise not found.");

            _context.enterprise.Remove(dbEnterprise);
            await _context.SaveChangesAsync();

            return Ok(await _context.enterprise.ToListAsync());
        }

    }
}
