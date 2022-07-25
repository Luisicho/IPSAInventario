using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using IPSAInventario.ViewModels;

namespace IPSAInventario.Models
{
    public class FechaValida : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var modeloFacturaForm = (Factura)validationContext.ObjectInstance;
            var AñoActual = DateTime.Today;

            if (modeloFacturaForm.Fecha_Compra == null)
                return new ValidationResult("El campo Fecha de compra es requerido 'DD/MM/AAAA'");

            if (modeloFacturaForm.Fecha_Compra.Value > AñoActual)
                return new ValidationResult("Fecha no valida");

            return ValidationResult.Success;
        }
    }
}