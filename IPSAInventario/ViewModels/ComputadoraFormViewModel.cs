using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IPSAInventario.Models;

namespace IPSAInventario.ViewModels
{
    public class ComputadoraFormViewModel
    {
        public ComputadoraFormViewModel()
        {

        }
        public ComputadoraFormViewModel(Computadora computadora)
        {
        
        }
        [StringLength(7)]
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
    }
}