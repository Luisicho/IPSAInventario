namespace IPSAInventario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using IPSAInventario.Models.Validation;

    public partial class Factura_Detalle_Comp
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [TFacturaValida]
        public int IDFactura { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(7)]
        [FacturaDetalleCompValida]
        [Required]
        public string Codigo_PC { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha { get; set; }

        public TimeSpan? Hora { get; set; }

        [Required]
        public string Responsable { get; set; }

        public Computadora Computadora { get; set; }

        public Factura Factura { get; set; }
    }
}
