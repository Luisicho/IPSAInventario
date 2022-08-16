using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using IPSAInventario.Models;

namespace IPSAInventario.Models.Validation
{
    public class CodigoValido : ValidationAttribute
    {
        //VARIABLES
        private InventarioDbcontext _context;//Base de datos

        //Inicia la base de datos para sus consulta
        public CodigoValido()
        {
            _context = new InventarioDbcontext();
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var codigoPC = value + "";
            if (!_context.Computadora.Where(m => m.Codigo_PC == codigoPC).Any())
                return new ValidationResult("Codigo de PC no existente");

            return ValidationResult.Success;
        }
    }
}