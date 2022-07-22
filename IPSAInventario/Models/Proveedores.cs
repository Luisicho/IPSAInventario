using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPSAInventario.Models
{
    [Table("Proveedores")]
    public class Proveedores
    {
        [Key]
        public int IDProveedor { get; set; }
        public string Name { get; set; }
    }
}