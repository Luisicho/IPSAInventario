using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using IPSAInventario.Models;

namespace IPSAInventario.Models.Validation
{
    public class FacturaDetalleCompValida : ValidationAttribute
    {
        //VARIABLES
        private InventarioDbcontext _context;//Base de datos

        //Inicia la base de datos para sus consulta
        public FacturaDetalleCompValida()
        {
            _context = new InventarioDbcontext();
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var modeloFacturaDC = (Factura_Detalle_Comp)validationContext.ObjectInstance;

            var facturaDetalleCompInDB = _context.Computadora
                .Where(m => m.Factura_Detalle_Comp
                .Any(y => y.Codigo_PC == modeloFacturaDC.Codigo_PC))
                .Any();

            if (facturaDetalleCompInDB)
            {
                return new ValidationResult("Computadora ya registrado en una factura");
            }
            var computadoraDetalleCompuInDB = _context.Computadora
                .SingleOrDefault(m => m.Codigo_PC == modeloFacturaDC.Codigo_PC);
            if (computadoraDetalleCompuInDB == null)
            {
                return new ValidationResult("Computadora No existente");
            }
            return ValidationResult.Success;
        }
    }
}