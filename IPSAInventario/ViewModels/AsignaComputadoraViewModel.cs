using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using IPSAInventario.Models;

namespace IPSAInventario.ViewModels
{
    public class AsignaComputadoraViewModel
    {
        public AsignaComputadoraViewModel() { }
        public AsignaComputadoraViewModel(Factura_Detalle_Comp factura_Detalle_Comp)
        {
            IDFactura = factura_Detalle_Comp.IDFactura;
            Codigo_PC = factura_Detalle_Comp.Codigo_PC;
            Fecha = factura_Detalle_Comp.Fecha;
            Hora = factura_Detalle_Comp.Hora;
            Responsable = factura_Detalle_Comp.Responsable;
        }
        public int IDFactura { get; set; }
        public string Codigo_PC { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha { get; set; }

        public TimeSpan? Hora { get; set; }

        public string Responsable { get; set; }

    }
}