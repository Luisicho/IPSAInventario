using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IPSAInventario.Models;

namespace IPSAInventario.ViewModels
{
    public class AuxiliarFormViewModel
    {
        public AuxiliarFormViewModel() { }
        public AuxiliarFormViewModel(Auxiliar auxiliar)
        {
            IDPeriferico = auxiliar.IDPeriferico;
            IDAuxiliar = auxiliar.IDAuxiliar;
            Funcionando = auxiliar.Funcionando;
            Observaciones = auxiliar.Observaciones;
            Fecha_Inst = auxiliar.Fecha_Inst;
        }
        [Key]
        [StringLength(7)]
        public string IDPeriferico { get; set; }

        public string IDAuxiliar { get; set; }

        public bool Funcionando { get; set; }

        public string Observaciones { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha_Inst { get; set; }
    }
}