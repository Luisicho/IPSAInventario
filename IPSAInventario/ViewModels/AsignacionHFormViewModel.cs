using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IPSAInventario.Models;
using System.Web;

namespace IPSAInventario.ViewModels
{
    public class AsignacionHFormViewModel
    {
        //Constructors
        public AsignacionHFormViewModel() { }
        public AsignacionHFormViewModel(Ranura_Detalle_Hard ranura_Detalle_Hard) 
        {
            IDRanura = ranura_Detalle_Hard.IDRanura;
            IDHardware = ranura_Detalle_Hard.IDHardware;
            Fecha = ranura_Detalle_Hard.Fecha;
            Hora = ranura_Detalle_Hard.Hora;
            Responsable = ranura_Detalle_Hard.Responsable;
            Hardware = ranura_Detalle_Hard.Hardware;
            Ranuras = ranura_Detalle_Hard.Ranuras;
        }
        //Parameters
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDRanura { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDHardware { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha { get; set; }

        public TimeSpan? Hora { get; set; }

        public string Responsable { get; set; }

        public Hardware Hardware { get; set; }

        public Ranuras Ranuras { get; set; }
    }
}