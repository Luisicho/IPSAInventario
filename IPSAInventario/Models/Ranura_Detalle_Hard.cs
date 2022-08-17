namespace IPSAInventario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using IPSAInventario.Models.Validation;

    public partial class Ranura_Detalle_Hard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idRanura_Detalle_Hard { get; set; }
        
        public int IDRanura { get; set; }

        [ValidaIDHardware]
        public int IDHardware { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha { get; set; }
        public int FechaHora { get; set; }
        [Required(ErrorMessage = "Se requiere de responsable")]
        public string Responsable { get; set; }

        public Hardware Hardware { get; set; }

        public Ranuras Ranuras { get; set; }
    }
}
