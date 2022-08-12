namespace IPSAInventario.Models
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
        [Display(Name = "Codigo de Computadora")]
        public string Codigo_PC { get; set; }

        public string Expediente { get; set; }

        [Display(Name = "Falla Reportada")]
        public string Falla_Reportada { get; set; }

        [Display(Name = "Que Presenta")]
        public string Que_Presenta { get; set; }

        public string Causa { get; set; }

        public string Accion { get; set; }

        public string Observaciones { get; set; }

        public string Reporto { get; set; }

        public string Atendio { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Fecha de Reporte")]
        public DateTime? Fecha_Reporte { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Fecha de Solucion")]
        public DateTime? Fecha_Solucion { get; set; }

        public string Ubicacion { get; set; }

        public Computadora Computadora { get; set; }
    }
}
