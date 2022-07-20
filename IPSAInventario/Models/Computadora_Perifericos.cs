namespace IPSAInventario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Computadora_Perifericos
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(7)]
        public string IDPeriferico { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(7)]
        public string Codigo_PC { get; set; }

        public string Area { get; set; }

        public string Ubicacion_Act { get; set; }

        public string Status_ { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha_Asignacion { get; set; }

        public virtual Computadora Computadora { get; set; }

        public virtual Perifericos Perifericos { get; set; }
    }
}
