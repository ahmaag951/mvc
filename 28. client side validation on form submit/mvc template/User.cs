using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc_template
{
    public class User
    {
        [Required]
        public string Email { get; set; }
    }
}