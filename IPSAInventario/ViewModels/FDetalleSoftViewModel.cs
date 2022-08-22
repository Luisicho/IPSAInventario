using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using IPSAInventario.Models;
using IPSAInventario.Models.Validation;

namespace IPSAInventario.ViewModels
{
    public class FDetalleSoftViewModel
    {
        public FDetalleSoftViewModel(Factura_Detalle_Soft facturaDS)
        {
            IDFactura = facturaDS.IDFactura;
            IDSoftware = facturaDS.IDSoftware;
            Fecha = facturaDS.Fecha;
            Responsable = facturaDS.Responsable;
            Factura = facturaDS.Factura;
            Software = facturaDS.Software;
        }
        [Required]
        public int IDFactura { get; set; }
        [Required]
        [FacturaDetalleSoftValida]
        public int IDSoftware { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha { get; set; }

        public TimeSpan? Hora { get; set; }

        public string Responsable { get; set; }

        public Factura Factura { get; set; }

        public Software Software { get; set; }
    }
}