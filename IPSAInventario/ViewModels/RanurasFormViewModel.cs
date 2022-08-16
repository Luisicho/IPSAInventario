using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using IPSAInventario.Models;

namespace IPSAInventario.ViewModels
{
    public class RanurasFormViewModel
    {
        public RanurasFormViewModel() { }
        public RanurasFormViewModel(Ranuras ranuras)
        {
            Codigo_PC = ranuras.Codigo_PC;
            IDRanura = ranuras.IDRanura;
            Tipo_Slot = ranuras.Tipo_Slot;
            Disponible = ranuras.Disponible;
            Computadora = ranuras.Computadora;
        }
        [Required]
        [StringLength(7)]
        public string Codigo_PC { get; set; }

        public int IDRanura { get; set; }

        public string Tipo_Slot { get; set; }

        public bool Disponible { get; set; }

        public Computadora Computadora { get; set; }
    }
}