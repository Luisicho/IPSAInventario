namespace IPSAInventario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ranuras
    {
        public Ranuras()
        {
            Ranura_Detalle_Hard = new HashSet<Ranura_Detalle_Hard>();
            Ranura_Detalle_Per = new HashSet<Ranura_Detalle_Per>();
        }

        [Required]
        [StringLength(7)]
        [Display(Name = "Codigo de Computadora")]
        public string Codigo_PC { get; set; }

        [Key]
        public int IDRanura { get; set; }

        public string Tipo_Slot { get; set; }

        public bool Disponible { get; set; }

        public Computadora Computadora { get; set; }

        public ICollection<Ranura_Detalle_Hard> Ranura_Detalle_Hard { get; set; }

        public ICollection<Ranura_Detalle_Per> Ranura_Detalle_Per { get; set; }
    }
}
