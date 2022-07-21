using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPSAInventario.ViewModels
{
    public class FacturaFormViewModel
    {
        //Lista de Proovedores
        public IEnumerable<string> Proveedores { get; set; }
        //Lista de Facturas
        public Factura Factura { get; set; }
    }
}