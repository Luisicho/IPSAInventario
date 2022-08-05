namespace IPSAInventario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Software")]
    public partial class Software
    {
        public Software()
        {
            Factura_Detalle_Soft = new HashSet<Factura_Detalle_Soft>();
            Computadora_Software = new HashSet<Computadora_Software>();
        }

        [Key]
        public int IDSoftware { get; set; }
        [Required(ErrorMessage = "Especifica la llave del producto")]
        [Display(Name = "Llave del producto")]
        public string Product_Key { get; set; }
        [Display(Name = "Tipo de licencia")]
        public string Tipo_Lic { get; set; }

        public string Licencia { get; set; }
        [Display(Name = "Numero de licencia")]
        public string Num_Licencia { get; set; }
        [Display(Name = "License Pack Bar Code")]
        public string License_Pack_Bar_Code { get; set; }
        [Display(Name = "License Pack")]
        public string License_Pack { get; set; }

        public string Certificado { get; set; }
        [Display(Name = "AGMT ID")]
        public string AGMT_ID { get; set; }

        public string Activa { get; set; }

        public string Cantidad { get; set; }

        public bool Disponibilidad { get; set; }

        public ICollection<Factura_Detalle_Soft> Factura_Detalle_Soft { get; set; }

        public ICollection<Computadora_Software> Computadora_Software { get; set; }
    }
}
