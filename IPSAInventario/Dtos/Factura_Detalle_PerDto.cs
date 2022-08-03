using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IPSAInventario.Dtos
{
    public class Factura_Detalle_PerDto
    {
        public int IDFactura { get; set; }

        [StringLength(7)]
        public string IDPeriferico { get; set; }
    }
}