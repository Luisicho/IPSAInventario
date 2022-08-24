namespace IPSAInventario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Monitor")]
    public partial class Monitor
    {
        [Key]
        [StringLength(7)]
        public string IDPeriferico { get; set; }

        public string Tipo { get; set; }
        [Display (Name = "Tamaño")]
        public int Tamano { get; set; }
        [Display(Name = "Unidad de Medida")]
        public string Unidad_Med { get; set; }

        public Perifericos Perifericos { get; set; }
    }
}
