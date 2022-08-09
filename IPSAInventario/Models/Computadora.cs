namespace IPSAInventario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Computadora")]
    public partial class Computadora
    {
         public Computadora()
        {
            Bitacora = new HashSet<Bitacora>();
            Factura_Detalle_Comp = new HashSet<Factura_Detalle_Comp>();
            Computadora_Perifericos = new HashSet<Computadora_Perifericos>();
            Computadora_Software = new HashSet<Computadora_Software>();
            Ranuras = new HashSet<Ranuras>();
        }

        [Key]
        [StringLength(7)]
        [Required]
        public string Codigo_PC { get; set; }

        public bool? Actualizado { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Baja { get; set; }

        public string Aplicacion { get; set; }

        public string Expediente { get; set; }

        public bool? Check_ { get; set; }

        public string Maquina { get; set; }

        public bool? Red { get; set; }

        public string IPV4 { get; set; }

        public string Mascara_IPV4 { get; set; }

        public string IPV6 { get; set; }

        public string Mascara_IPV6 { get; set; }

        public string Internet { get; set; }

        public string Correo { get; set; }

        public string Tipo_Computador { get; set; }

        public string Observaciones { get; set; }

        public ICollection<Bitacora> Bitacora { get; set; }

        public ICollection<Factura_Detalle_Comp> Factura_Detalle_Comp { get; set; }

        public ICollection<Computadora_Perifericos> Computadora_Perifericos { get; set; }

        public ICollection<Computadora_Software> Computadora_Software { get; set; }

        public ICollection<Ranuras> Ranuras { get; set; }
    }
}
