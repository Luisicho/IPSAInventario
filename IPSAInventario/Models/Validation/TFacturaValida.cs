using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IPSAInventario.Models.Validation
{
    public class TFacturaValida : ValidationAttribute
    {
        //VARIABLES
        private InventarioDbcontext _context;//Base de datos

        //Inicia la base de datos para sus consulta
        public TFacturaValida()
        {
            _context = new InventarioDbcontext();
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (String.IsNullOrWhiteSpace(value + "") || (value + "") == "0")
            {
                return new ValidationResult("Coloque una factura valida");
            }
            //busca id factura
            var factura = _context.Factura.SingleOrDefault(m => m.IDFactura == (int)value);

            // Revisa si factura existe
            if (factura == null)
            {
                return new ValidationResult("Factura No existente");
            }
            return ValidationResult.Success;
        }
    }
}