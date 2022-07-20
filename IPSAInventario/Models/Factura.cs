namespace IPSAInventario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Factura")]
    public partial class Factura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Factura()
        {
            Factura_Detalle_Comp = new HashSet<Factura_Detalle_Comp>();
            Factura_Detalle_Per = new HashSet<Factura_Detalle_Per>();
            Factura_Detalle_Soft = new HashSet<Factura_Detalle_Soft>();
        }

        [Key]
        public int IDFactura { get; set; }

        public string Proveedor { get; set; }

        public string Vendedor { get; set; }

        [Column("Factura")]
        public byte[] Factura1 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha_Compra { get; set; }

        public byte[] Requisicion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Factura_Detalle_Comp> Factura_Detalle_Comp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Factura_Detalle_Per> Factura_Detalle_Per { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Factura_Detalle_Soft> Factura_Detalle_Soft { get; set; }
    }
}
