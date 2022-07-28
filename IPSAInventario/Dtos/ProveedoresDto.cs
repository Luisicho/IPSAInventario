using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IPSAInventario.Dtos
{
    public class ProveedoresDto
    {
        [Key]
        public int IDProveedor { get; set; }
        public string Name { get; set; }
    }
}