using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_template
{
    public class User
    {
        [Required]
        [Remote("IsEmailExists", "Home", HttpMethod="Post", ErrorMessage="Email already exists")]
        public string Email { get; set; }
    }
}