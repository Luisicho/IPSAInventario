using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IPSAInventario.Dtos
{
    public class Factura_Detalle_SoftDto
    {
        public int IDFactura { get; set; }

        public int IDSoftware { get; set; }
    }
}