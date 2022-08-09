using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using IPSAInventario.ViewModels;

namespace IPSAInventario.Models.Validation
{
    public class FechaValida : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //var modeloFacturaForm = (Factura)validationContext.ObjectInstance;
            
            try
            {
                var fecha = DateTime.Parse(value + "");
                var AñoActual = DateTime.Today;
                if (fecha.Date > AñoActual)
                    return new ValidationResult("Fecha no valida, mayor a la actual");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new ValidationResult("Fecha no valida, formato 'DD/MM/AAAA'");
            }

            return ValidationResult.Success;
        }
    }
}