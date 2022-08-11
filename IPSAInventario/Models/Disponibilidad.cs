using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IPSAInventario.Models
{
    public class Disponibilidad
    {
        [Key]
        public int IdDisponibilidad { get; set; }
        [StringLength(7)]
        [Display(Name = "Codigo de Computadora")]
        [Required]
        public string Codigo_PC { get; set; }
        public string Area { get; set; }
        public string Departamento { get; set; }
        [Display(Name = "Ubicacion Actual")]
        public string Ubicacion_Act { get; set; }
        [Display(Name = "Estatus")]
        public string Status_ { get; set; }
        public bool? Disponiblilidad { get; set; }
        [Display(Name = "Fecha de Asignacion")]
        public DateTime? Fecha_Asignacion { get; set; }
        public string Responsable { get; set; }
    }
}