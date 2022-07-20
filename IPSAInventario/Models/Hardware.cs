namespace IPSAInventario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hardware")]
    public partial class Hardware
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hardware()
        {
            Ranura_Detalle_Hard = new HashSet<Ranura_Detalle_Hard>();
        }

        [Key]
        public int IDHardware { get; set; }

        public int? Tamano { get; set; }

        public string Unidad_Med { get; set; }

        public int? Velocidada { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ranura_Detalle_Hard> Ranura_Detalle_Hard { get; set; }
    }
}
