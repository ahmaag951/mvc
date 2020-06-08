using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using test_custom_validation_anotation.Validators;

namespace test_custom_validation_anotation.Models
{

    
    public class model
    {
        [HasZLetter]
        [Required(ErrorMessage="required")]
        public string Name { get; set; }
    }
}