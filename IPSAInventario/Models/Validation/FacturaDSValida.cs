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
            //busca id software en factura de DB
            var facturaDSInDB = _context.Software
                .Where(m => m.Factura_Detalle_Soft
                .Any(y => y.IDSoftware == modeloFacturaDS.IDSoftware))//Revisa dentro de iCollection si se encuentra el iDsoftware en alguna factura
                .Any();//true si lo encuentra
            
            if (facturaDSInDB)
            {
                return new ValidationResult("Software ya registrado en una factura");
            }
            // Revisa si software existe
            //busca id software
            var softDSInDB = _context.Software
                .SingleOrDefault(m => m.IDSoftware == modeloFacturaDS.IDSoftware);
            if (softDSInDB == null)
            {
                return new ValidationResult("Software No existente");
            }
            return ValidationResult.Success;
        }
    }
}