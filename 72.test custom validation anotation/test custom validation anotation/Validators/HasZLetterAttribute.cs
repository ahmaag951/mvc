using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace test_custom_validation_anotation.Validators
{
    public class HasZLetterAttribute : ValidationAttribute
    {

        // the default constructor
        // if you want to send data with the validation you can
        // like [HasZLetter(1)]
        public HasZLetterAttribute()
            : base("has z letter")
        {

        }



        // make sure you override the right isvalid method, because there are two of them
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //value will contain the user input value 
            if (value != null && value.ToString().Contains('z'))
            {
                var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                return new ValidationResult(errorMessage);
            }
            else
            {
                return ValidationResult.Success;
            }

        }

    }

}