using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Company_DAL;
using System.ComponentModel.DataAnnotations;

namespace Company_UI.Models
{
    public class EmployeeModel : Employee
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public string email { get; set; }
        public int age { get; set; }
    }
}