using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IPSAInventario.Models
{
    public class Especificaciones
    {
        [Key]
        public int IdEspecificaciones { get; set; }
        [StringLength(7)]
        [Display(Name = "Codigo de Computadora")]
        [Required]
        public string Codigo_PC { get; set; }
        public string Marca { get; set; }
        [Display(Name = "Serie de Maquina")]
        public string Serie_Maq { get; set; }
        public string Procesador { get; set; }
        public string Nucleos { get; set; }
        public int Velocidad { get; set; }
        [StringLength(7)]
        [Display(Name = "Unidad de Medida")]
        public string Unidad_Medida { get; set; }
        [Display(Name = "Mobo Marca")]
        public string Mobo_Marca { get; set; }
        [Display(Name = "Mobo Modelo")]
        public string Mobo_Modelo { get; set; }
        [Display(Name = "Mobo Serie")]
        public string Mobo_Serie { get; set; }
    }
}