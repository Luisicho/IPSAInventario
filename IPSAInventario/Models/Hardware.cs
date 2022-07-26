namespace IPSAInventario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using IPSAInventario.Models.Validation;

    [Table("Hardware")]
    public partial class Hardware
    {
        public Hardware()
        {
            Ranura_Detalle_Hard = new HashSet<Ranura_Detalle_Hard>();
        }

        [Key]
        public int IDHardware { get; set; }

        [NumeroValido]
        [Display(Name = "Tama�o")]
        public int? Tamano { get; set; }

        public string Unidad_Med { get; set; }
        [NumeroValido]
        public int? Velocidad { get; set; }

        public ICollection<Ranura_Detalle_Hard> Ranura_Detalle_Hard { get; set; }
    }
}
