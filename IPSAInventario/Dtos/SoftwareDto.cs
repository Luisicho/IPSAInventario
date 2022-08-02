using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IPSAInventario.Dtos
{
    public class SoftwareDto
    {
        [Key]
        public int IDSoftware { get; set; }
        [Required(ErrorMessage = "Especifica la llave del producto")]
        public string Product_Key { get; set; }

        public string Tipo_Lic { get; set; }

        public string Licencia { get; set; }

        public string Num_Licencia { get; set; }

        public string License_Pack_Bar_Code { get; set; }

        public string License_Pack { get; set; }

        public string Certificado { get; set; }

        public string AGMT_ID { get; set; }

        public string Activa { get; set; }

        public string Cantidad { get; set; }
        
        public bool? Disponibilidad { get; set; }

        public ICollection<Factura_Detalle_SoftDto> Factura_Detalle_Soft { get; set; }

        public ICollection<Computadora_SoftwareDto> Computadora_Software { get; set; }
    }
}