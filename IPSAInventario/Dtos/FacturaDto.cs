using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IPSAInventario.Models;
using System.Linq;
using System.Web;

namespace IPSAInventario.Dtos
{
    public class FacturaDto
    {
        public int IDFactura { get; set; }
        public ProveedoresDto Proveedores { get; set; }
        public int IDProveedor { get; set; }
        public string Vendedor { get; set; }
        public string Nombre_Factura { get; set; }

        [Column(TypeName = "date")]
        [Required]
        public DateTime? Fecha_Compra { get; set; }

        public string Nombre_Requisicion { get; set; }
       
        public string Descripcion { get; set; }
        
    }
}