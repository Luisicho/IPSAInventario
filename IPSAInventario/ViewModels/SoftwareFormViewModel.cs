using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using IPSAInventario.Models;

namespace IPSAInventario.ViewModels
{
    public class SoftwareFormViewModel
    {
        //Constructores
        public SoftwareFormViewModel()
        {
            IDSoftware = 0;
        }
        public SoftwareFormViewModel(Software software)
        {
            IDSoftware = software.IDSoftware;
            Product_Key = software.Product_Key;
            Tipo_Lic = software.Tipo_Lic;
            Licencia = software.Licencia;
            Num_Licencia = software.Num_Licencia;
            License_Pack_Bar_Code = software.License_Pack_Bar_Code;
            License_Pack = software.License_Pack;
            Certificado = software.Certificado;
            AGMT_ID = software.AGMT_ID;
            Activa = software.Activa;
            Cantidad = software.Cantidad;
            Disponibilidad = software.Disponibilidad;
            
            Factura_Detalle_Soft = software.Factura_Detalle_Soft;
            Computadora_Software = software.Computadora_Software;
        }
        //Software
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

        public ICollection<Factura_Detalle_Soft> Factura_Detalle_Soft { get; set; }

        //Computadora_Software
        public ICollection<Computadora_Software> Computadora_Software { get; set; }

    }
}