using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using IPSAInventario.Models;

namespace IPSAInventario.Models.Validation
{
    public class NumeroValido : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                if ((value + "").Length > 0)
                    Int32.Parse(value + "");
            }
            catch (Exception e)
            {
                return new ValidationResult("Solo se aceptan numeros decimales");
            }

            return ValidationResult.Success;
        }
    }
}