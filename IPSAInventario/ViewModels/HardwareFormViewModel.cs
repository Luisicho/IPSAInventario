using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IPSAInventario.Models;

namespace IPSAInventario.ViewModels
{
    public class HardwareFormViewModel
    {

        public HardwareFormViewModel()
        {

        }
        public HardwareFormViewModel(Hardware hardware)
        {
            IDHardware = hardware.IDHardware;
            Tamano = hardware.Tamano;
            Unidad_Med = hardware.Unidad_Med;
            Velocidad = hardware.Velocidad;
        }
        public int IDHardware { get; set; }

        public int? Tamano { get; set; }

        public string Unidad_Med { get; set; }

        public int? Velocidad { get; set; }

    }
}