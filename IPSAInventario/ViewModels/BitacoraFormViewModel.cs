using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using IPSAInventario.Models;

namespace IPSAInventario.ViewModels
{
    public class BitacoraFormViewModel
    {
        public BitacoraFormViewModel()
        {
            IDBitacora = 0;
        }

        public BitacoraFormViewModel(Bitacora bitacora)
        {
            IDBitacora = bitacora.IDBitacora;
            Codigo_PC = bitacora.Codigo_PC;
            Expediente = bitacora.Expediente;
            Falla_Reportada = bitacora.Falla_Reportada;
            Que_Presenta = bitacora.Que_Presenta;
            Causa = bitacora.Causa;
            Accion = bitacora.Accion;
            Observaciones = bitacora.Observaciones;
            Reporto = bitacora.Reporto;
            Atendio = bitacora.Atendio;
            Fecha_Reporte = bitacora.Fecha_Reporte;
            Fecha_Solucion = bitacora.Fecha_Solucion;
            Ubicacion = bitacora.Ubicacion;
        }

        public int IDBitacora { get; set; }

        [StringLength(7)]
        [Display(Name = "Codigo de Computadora")]
        public string Codigo_PC { get; set; }

        public string Expediente { get; set; }

        [Display(Name = "Falla Reportada")]
        public string Falla_Reportada { get; set; }

        [Display(Name = "Que Presenta")]
        public string Que_Presenta { get; set; }

        public string Causa { get; set; }

        public string Accion { get; set; }

        public string Observaciones { get; set; }

        public string Reporto { get; set; }

        public string Atendio { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Fecha de Reporte")]
        public DateTime? Fecha_Reporte { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Fecha de Solucion")]
        public DateTime? Fecha_Solucion { get; set; }

        public string Ubicacion { get; set; }
    }
}