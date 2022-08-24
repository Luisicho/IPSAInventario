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
    public class PerifericosFormViewModel
    {
        public bool HabilitarDropDown = true;
        public bool HabilitarTextBox = true;
        public PerifericosFormViewModel() 
        {
            Disponibilidad = true;
            Check_ = false;
            Revisado = false;
        }
        public PerifericosFormViewModel(Perifericos perifericos)
        {
            IDPeriferico = perifericos.IDPeriferico;
            Marca = perifericos.Marca;
            Modelo = perifericos.Modelo;
            NoSerie = perifericos.NoSerie;
            Revisado = perifericos.Revisado;
            Baja = perifericos.Baja;
            Aplicacion = perifericos.Aplicacion;
            Expediente = perifericos.NoSerie;
            Comentario = perifericos.Comentario;
            Disponibilidad = perifericos.Disponibilidad;
            Check_ = perifericos.Check_;
            Tipo_Periferico = perifericos.Tipo_Periferico;
        }
        [Key]
        [StringLength(7)]
        public string IDPeriferico { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        [Display(Name = "No. de Serie")]
        public string NoSerie { get; set; }

        public bool Revisado { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Fecha de baja")]
        [FechaValida]
        public DateTime? Baja { get; set; }

        public string Aplicacion { get; set; }

        public string Expediente { get; set; }

        public string Comentario { get; set; }

        public bool Disponibilidad { get; set; }

        [Display(Name = "Check")]
        public bool Check_ { get; set; }

        [Display(Name = "Tipo de Periferico")]
        [DropDownValido]
        public string Tipo_Periferico { get; set; }

    }
}