using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IPSAInventario.Models;
using IPSAInventario.Models.Validation;

namespace IPSAInventario.ViewModels
{
    public class ComputadoraFormViewModel
    {
        public ComputadoraFormViewModel()
        {

        }
        public ComputadoraFormViewModel(Computadora computadora)
        {
            Codigo_PC = computadora.Codigo_PC;
            Actualizado = computadora.Actualizado;
            Baja = computadora.Baja;
            Aplicacion = computadora.Aplicacion;
            Expediente = computadora.Expediente;
            Check_ = computadora.Check_;
            Maquina = computadora.Maquina;
            Red = computadora.Red;
            IPV4 = computadora.IPV4;
            Mascara_IPV4 = computadora.Mascara_IPV4;
            IPV6 = computadora.IPV6;
            Mascara_IPV6 = computadora.Mascara_IPV6;
            Internet = computadora.Internet;
            Correo = computadora.Correo;
            Tipo_Computador = computadora.Tipo_Computador;
            Observaciones = computadora.Observaciones;
        }
        [StringLength(7)]
        [Required]
        [Display(Name = "Codigo de Computadora")]
        public string Codigo_PC { get; set; }

        public bool? Actualizado { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Fecha Baja")]
        [FechaValida]
        public DateTime? Baja { get; set; }

        public string Aplicacion { get; set; }

        public string Expediente { get; set; }

        [Display(Name = "Check")]
        public bool? Check_ { get; set; }

        public string Maquina { get; set; }

        public bool? Red { get; set; }

        public string IPV4 { get; set; }
        [Display(Name = "Mascara IPV4")]
        public string Mascara_IPV4 { get; set; }

        public string IPV6 { get; set; }
        [Display(Name = "Mascara IPV6")]
        public string Mascara_IPV6 { get; set; }

        public string Internet { get; set; }

        public string Correo { get; set; }
        [Display(Name = "Tipo de Computadora")]
        public string Tipo_Computador { get; set; }

        public string Observaciones { get; set; }
    }
}