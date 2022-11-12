using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SicpaAPI.Models
{
    public class Department
    {
        public int? id { get; set; }
        public string created_by { get; set; }
        public DateTime? created_date { get; set; }
        public string modified_by { get; set; }
        public DateTime? modified_date { get; set; }
        public bool status { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public int id_enterprise { get; set; }
    }
}
