using Microsoft.EntityFrameworkCore;
using SicpaAPI.Dtos;
using SicpaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SicpaAPI.Data
{
    public class DataContext : DbContext
    { 
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Enterprise> enterprise { get; set; }
        public DbSet<Employee> employee { get; set; }
        public DbSet<Department> department { get; set; }
        public DbSet<DepartmentEmployeeDto> departmentemployee { get; set; }
    }
}
