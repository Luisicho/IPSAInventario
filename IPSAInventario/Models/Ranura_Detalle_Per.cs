namespace IPSAInventario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ranura_Detalle_Per
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDRanura { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(7)]
        public string IDPeriferico { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha { get; set; }

        public TimeSpan? Hora { get; set; }

        public string Responsable { get; set; }

        public virtual Perifericos Perifericos { get; set; }

        public virtual Ranuras Ranuras { get; set; }
    }
}
