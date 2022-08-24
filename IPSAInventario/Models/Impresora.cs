namespace IPSAInventario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Impresora")]
    public partial class Impresora
    {
        [Key]
        [StringLength(7)]
        public string IDPeriferico { get; set; }
        [Display(Name = "Cartucho Negro")]
        public string Cart_Negro { get; set; }
        [Display(Name = "Cartucho de Color")]
        public string Cart_Color { get; set; }

        public string Tipo { get; set; }
        [Display(Name = "Tipo de Impresora")]
        public string Tipo_Imp { get; set; }

        public string Responsable { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Garantia { get; set; }

        public Perifericos Perifericos { get; set; }
    }
}
