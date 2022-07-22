namespace IPSAInventario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Perifericos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Perifericos()
        {
            Computadora_Perifericos = new HashSet<Computadora_Perifericos>();
            Factura_Detalle_Per = new HashSet<Factura_Detalle_Per>();
            Ranura_Detalle_Per = new HashSet<Ranura_Detalle_Per>();
        }

        [Key]
        [StringLength(7)]
        public string IDPeriferico { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string NoSerie { get; set; }

        public bool? Revisado { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Baja { get; set; }

        public string Aplicacion { get; set; }

        public string Expediente { get; set; }

        public string Comentario { get; set; }

        public bool? Disponibilidad { get; set; }

        public bool? Check_ { get; set; }

        public string Tipo_Periferico { get; set; }

        public virtual Auxiliar Auxiliar { get; set; }

        public virtual Impresora Impresora { get; set; }

        public virtual Monitor Monitor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Computadora_Perifericos> Computadora_Perifericos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Factura_Detalle_Per> Factura_Detalle_Per { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ranura_Detalle_Per> Ranura_Detalle_Per { get; set; }
    }
}
