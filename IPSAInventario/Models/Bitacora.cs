namespace IPSAInventario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using IPSAInventario.Models.Validation;

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
        [Required(ErrorMessage = "La casilla Falla Reportada en requerida")]
        public string Falla_Reportada { get; set; }

        [Display(Name = "Que Presenta")]
        [Required (ErrorMessage = "La casilla Que presenta en requerida")]
        public string Que_Presenta { get; set; }

        public string Causa { get; set; }

        public string Accion { get; set; }

        public string Observaciones { get; set; }

        [Required]
        public string Reporto { get; set; }

        public string Atendio { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Fecha de Reporte")]
        [FechaValida]
        public DateTime? Fecha_Reporte { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Fecha de Solucion")]
        [FechaValida]
        public DateTime? Fecha_Solucion { get; set; }

        [Required]
        public string Ubicacion { get; set; }

        public Computadora Computadora { get; set; }
    }
}
