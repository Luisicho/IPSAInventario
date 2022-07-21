using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPSAInventario.ViewModels
{
    public class FacturaFormViewModel
    {
        public IEnumerable<string> Provedores { get; set; }
        public Factura Factura { get; set; }
    }
}