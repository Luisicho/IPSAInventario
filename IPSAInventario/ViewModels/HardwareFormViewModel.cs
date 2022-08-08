using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IPSAInventario.Models;

namespace IPSAInventario.ViewModels
{
    public class HardwareFormViewModel
    {
        public int IDHardware { get; set; }

        public int? Tamano { get; set; }

        public string Unidad_Med { get; set; }

        public int? Velocidad { get; set; }

        public ICollection<Ranura_Detalle_Hard> Ranura_Detalle_Hard { get; set; }
    }
}