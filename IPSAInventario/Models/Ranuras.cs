namespace IPSAInventario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ranuras
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ranuras()
        {
            Ranura_Detalle_Hard = new HashSet<Ranura_Detalle_Hard>();
            Ranura_Detalle_Per = new HashSet<Ranura_Detalle_Per>();
        }

        [Required]
        [StringLength(7)]
        public string Codigo_PC { get; set; }

        [Key]
        public int IDRanura { get; set; }

        public string Tipo_Slot { get; set; }

        public bool? Disponible { get; set; }

        public virtual Computadora Computadora { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ranura_Detalle_Hard> Ranura_Detalle_Hard { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ranura_Detalle_Per> Ranura_Detalle_Per { get; set; }
    }
}
