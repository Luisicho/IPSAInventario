using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IPSAInventario.Dtos
{
    public class Factura_Detalle_CompDto
    {
        public int IDFactura { get; set; }

        [StringLength(7)]
        public string Codigo_PC { get; set; }
    }
}