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
            var modeloFacturaDS = (Factura_Detalle_Soft)validationContext.ObjectInstance;

            // Revisa si factura existe
            //busca id factura
            var factDSInDB = _context.Factura
                .SingleOrDefault(m => m.IDFactura == modeloFacturaDS.IDFactura);
            if (factDSInDB == null)
            {
                return new ValidationResult("Factura No existente");
            }
            return ValidationResult.Success;
        }
    }
}