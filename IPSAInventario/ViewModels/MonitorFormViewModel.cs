using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IPSAInventario.Models;

namespace IPSAInventario.ViewModels
{
    public class MonitorFormViewModel
    {
        public MonitorFormViewModel() { }
        public MonitorFormViewModel(Monitor monitor) 
        {
            IDPeriferico = monitor.IDPeriferico;
            Tipo = monitor.Tipo;
            Tamano = monitor.Tamano;
            Unidad_Med = monitor.Unidad_Med;
        }

        [Key]
        [StringLength(7)]
        public string IDPeriferico { get; set; }

        public string Tipo { get; set; }

        public int? Tamano { get; set; }

        public string Unidad_Med { get; set; }
    }
}