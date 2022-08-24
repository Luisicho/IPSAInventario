using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using IPSAInventario.Models;

namespace IPSAInventario.ViewModels
{
    public class ImpresoraFormViewModel
    {
        public ImpresoraFormViewModel() { }
        public ImpresoraFormViewModel(Impresora impresora)
        {
            IDPeriferico = impresora.IDPeriferico;
            IDImpresora = impresora.IDImpresora;
            Cart_Negro = impresora.Cart_Negro;
            Cart_Color = impresora.Cart_Color;
            Tipo = impresora.Tipo;
            Tipo_Imp = impresora.Tipo_Imp;
            Responsable = impresora.Responsable;
            Garantia = impresora.Garantia;
        }
        [Key]
        [StringLength(7)]
        public string IDPeriferico { get; set; }

        public string IDImpresora { get; set; }

        public string Cart_Negro { get; set; }

        public string Cart_Color { get; set; }

        public string Tipo { get; set; }

        public string Tipo_Imp { get; set; }

        public string Responsable { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Garantia { get; set; }
    }
}