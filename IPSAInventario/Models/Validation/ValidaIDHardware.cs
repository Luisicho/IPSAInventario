using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IPSAInventario.Models.Validation
{
    public class ValidaIDHardware : ValidationAttribute
    {
        //VARIABLES
        private InventarioDbcontext _context;//Base de datos

        //Inicia la base de datos para sus consulta
        public ValidaIDHardware()
        {
            _context = new InventarioDbcontext();
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var modeloRDHForm = (Ranura_Detalle_Hard)validationContext.ObjectInstance;
            if (modeloRDHForm.IDHardware == 0)
                return new ValidationResult("Coloque un codigo valido");
            if (!_context.Hardware.Where(m => m.IDHardware == modeloRDHForm.IDHardware).Any())
                return new ValidationResult("Codigo de Hardware No Existente");
            return ValidationResult.Success;
        }
    
    }
}