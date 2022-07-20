namespace IPSAInventario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bitacora")]
    public partial class Bitacora
    {
        [Key]
        public int IDBitacora { get; set; }

        [StringLength(7)]
        public string Codigo_PC { get; set; }

        public string Expediente { get; set; }

        public string Falla_Reportada { get; set; }

        public string Que_Presenta { get; set; }

        public string Causa { get; set; }

        public string Accion { get; set; }

        public string Observaciones { get; set; }

        public string Reporto { get; set; }

        public string Atendio { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha_Reporte { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha_Solucion { get; set; }

        public string Ubicacion { get; set; }

        public virtual Computadora Computadora { get; set; }
    }
}
