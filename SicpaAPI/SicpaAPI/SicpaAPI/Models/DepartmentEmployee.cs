using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SicpaAPI.Models
{
    public class DepartmentEmployee
    {
        public int? id { get; set; }
        public string created_by { get; set; }
        public DateTime? created_date { get; set; }
        public string modified_by { get; set; }
        public DateTime? modified_date { get; set; }
        public bool status { get; set; }
        public int id_department { get; set; }
        public int id_employee { get; set; }
        public Department department { get; set; }
        public Employee employee { get; set; }
    }
}
