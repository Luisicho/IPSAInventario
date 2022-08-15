using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using IPSAInventario.Models;

namespace IPSAInventario.ViewModels
{
    public class EspecificacionesFormViewModel
    {
        public EspecificacionesFormViewModel() { }
        public EspecificacionesFormViewModel(Especificaciones especificaciones)
        {
            IdEspecificaciones = especificaciones.IdEspecificaciones;
            Codigo_PC = especificaciones.Codigo_PC;
            Computadora = especificaciones.Computadora;
            Marca = especificaciones.Marca;
            Serie_Maq = especificaciones.Serie_Maq;
            Procesador = especificaciones.Procesador;
            Nucleos = especificaciones.Nucleos;
            Velocidad = especificaciones.Velocidad;
            Unidad_Medida = especificaciones.Unidad_Medida;
            Mobo_Marca = especificaciones.Mobo_Marca;
            Mobo_Modelo = especificaciones.Mobo_Modelo;
            Mobo_Serie = especificaciones.Mobo_Serie;
        }
        public int IdEspecificaciones { get; set; }
        [StringLength(7)]
        [Display(Name = "Codigo de Computadora")]
        [Required]
        public string Codigo_PC { get; set; }
        [ForeignKey("Codigo_PC")]
        public Computadora Computadora { get; set; }
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