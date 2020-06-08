using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc_template
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Type { get; set; }
        public virtual List<Employee> Employees { get; set; }

        
    }
}