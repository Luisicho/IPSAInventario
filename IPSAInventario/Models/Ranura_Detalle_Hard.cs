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
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDRanura { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ValidaIDHardware]
        public int IDHardware { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha { get; set; }

        public TimeSpan? Hora { get; set; }
        [Required(ErrorMessage = "Se requiere de responsable")]
        public string Responsable { get; set; }

        public Hardware Hardware { get; set; }

        public Ranuras Ranuras { get; set; }
    }
}
