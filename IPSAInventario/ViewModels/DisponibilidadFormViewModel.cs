using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using IPSAInventario.Models;
using IPSAInventario.Models.Validation;

namespace IPSAInventario.ViewModels
{
    public class DisponibilidadFormViewModel
    {
        public DisponibilidadFormViewModel() { }
        public DisponibilidadFormViewModel(Disponibilidad disponibilidad)
        {
            IdDisponibilidad = disponibilidad.IdDisponibilidad;
            Codigo_PC = disponibilidad.Codigo_PC;
            Computadora = disponibilidad.Computadora;
            Area = disponibilidad.Area;
            Departamento = disponibilidad.Departamento;
            Ubicacion_Act = disponibilidad.Ubicacion_Act;
            Status_ = disponibilidad.Status_;
            this.Disponible = disponibilidad.Disponible;
            Fecha_Asignacion = disponibilidad.Fecha_Asignacion;
            Responsable = disponibilidad.Responsable;
        }
        public int IdDisponibilidad { get; set; }
        [StringLength(7)]
        [Display(Name = "Codigo de Computadora")]
        [Required]
        public string Codigo_PC { get; set; }
        public Computadora Computadora { get; set; }
        public string Area { get; set; }
        public string Departamento { get; set; }
        [Display(Name = "Ubicacion Actual")]
        public string Ubicacion_Act { get; set; }
        [Display(Name = "Estatus")]
        public string Status_ { get; set; }
        public bool Disponible { get; set; }
        [Display(Name = "Fecha de Asignacion")]
        [FechaValida]
        public DateTime? Fecha_Asignacion { get; set; }
        public string Responsable { get; set; }
    }
}