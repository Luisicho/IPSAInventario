namespace IPSAInventario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Auxiliar")]
    public partial class Auxiliar
    {
        [Key]
        [StringLength(7)]
        public string IDPeriferico { get; set; }

        public string IDAuxiliar { get; set; }

        public bool Funcionando { get; set; }

        public string Observaciones { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha_Inst { get; set; }

        public Perifericos Perifericos { get; set; }
    }
}
