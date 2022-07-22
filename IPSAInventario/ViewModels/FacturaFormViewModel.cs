using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IPSAInventario.Models;

namespace IPSAInventario.ViewModels
{
    public class FacturaFormViewModel
    {
        //Lista de Proovedores
        public IEnumerable<Proveedores> Proveedores { get; set; }
        //Lista de Facturas
        public Factura Factura { get; set; }
        //Ultima id disponible
        public int lastID { get; set; }
    }
}