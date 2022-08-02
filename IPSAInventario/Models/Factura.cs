namespace IPSAInventario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using IPSAInventario.Models.Validation;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Factura")]
    public partial class Factura
    {
         public Factura()
        {
            Factura_Detalle_Comp = new HashSet<Factura_Detalle_Comp>();
            Factura_Detalle_Per = new HashSet<Factura_Detalle_Per>();
            Factura_Detalle_Soft = new HashSet<Factura_Detalle_Soft>();
        }

        [Key]
        public int IDFactura { get; set; }

        public Proveedores Proveedores { get; set; }
        [Display(Name = "Proveedor")]
        [Required(ErrorMessage = "Coloque un proveedor valido")]
        public int IDProveedor { get; set; }
        public string Vendedor { get; set; }
        [NotMapped]
        public HttpPostedFileBase facturaPath { get; set; }
        public string Nombre_Factura { get; set; }
        
        [Column(TypeName = "date")]
        [Display(Name = "Fecha de Compra")]
        [Required]
        [FechaValida]
        public DateTime? Fecha_Compra { get; set; }
        [NotMapped]
        public HttpPostedFileBase requisicionPath { get; set; }
        public string Nombre_Requisicion { get; set; }
        

        public string Descripcion { get; set; }

        public ICollection<Factura_Detalle_Comp> Factura_Detalle_Comp { get; set; }

        public ICollection<Factura_Detalle_Per> Factura_Detalle_Per { get; set; }

        public ICollection<Factura_Detalle_Soft> Factura_Detalle_Soft { get; set; }


        [Column("Factura")]
        [Display(Name = "Factura")]
        public byte[] Factura1 { get; set; }
        public byte[] Requisicion { get; set; }
    }
}
