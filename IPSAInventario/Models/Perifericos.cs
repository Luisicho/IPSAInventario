namespace IPSAInventario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Perifericos
    {
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
        
        [Display(Name = "No. de Serie")]
        public string NoSerie { get; set; }

        public bool Revisado { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Fecha de baja")]
        public DateTime? Baja { get; set; }

        public string Aplicacion { get; set; }

        public string Expediente { get; set; }

        public string Comentario { get; set; }

        public bool Disponibilidad { get; set; }

        [Display(Name = "Check")]
        public bool Check_ { get; set; }

        [Display(Name = "Tipo de Periferico")]
        public string Tipo_Periferico { get; set; }

        public Auxiliar Auxiliar { get; set; }

        public Impresora Impresora { get; set; }

        public Monitor Monitor { get; set; }

        public ICollection<Computadora_Perifericos> Computadora_Perifericos { get; set; }

        public ICollection<Factura_Detalle_Per> Factura_Detalle_Per { get; set; }

        public ICollection<Ranura_Detalle_Per> Ranura_Detalle_Per { get; set; }
    }
}
