namespace IPSAInventario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Factura_Detalle_Soft
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDFactura { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDSoftware { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha { get; set; }

        public TimeSpan? Hora { get; set; }

        public string Responsable { get; set; }

        public virtual Factura Factura { get; set; }

        public virtual Software Software { get; set; }
    }
}
