using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using IPSAInventario.Models;

namespace IPSAInventario.Models.Validation
{
    public class FacturaDSValida : ValidationAttribute
    {
        //VARIABLES
        private InventarioDbcontext _context;//Base de datos

        //Inicia la base de datos para sus consulta
        public FacturaDSValida()
        {
            _context = new InventarioDbcontext();
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var modeloFacturaDS = (Factura_Detalle_Soft)validationContext.ObjectInstance;

            // Revisa si software ya comprado
            //busca la factura en db
            var facturaDSInDB = _context.Software.Where(m => m.Factura_Detalle_Soft.Contains(modeloFacturaDS)).ToList();
            if (facturaDSInDB.Any())
            {
                return new ValidationResult("Software ya registrado en una factura");
            }

            return ValidationResult.Success;
        }
    }
}