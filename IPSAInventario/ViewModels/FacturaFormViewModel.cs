using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using IPSAInventario.Models;

namespace IPSAInventario.ViewModels
{
    public class FacturaFormViewModel
    {
        //Controladores
        public FacturaFormViewModel()
        {
            IDFactura = 0;
        }
        public FacturaFormViewModel(Factura factura)
        {
            deshabilitar = false;
            IDFactura = factura.IDFactura;
            IDProveedor = factura.IDProveedor;
            Vendedor = factura.Vendedor;
            facturaPath = factura.facturaPath;
            Factura1 = factura.Factura1;
            Fecha_Compra = factura.Fecha_Compra;
            requisicionPath = factura.requisicionPath;
            Requisicion = factura.Requisicion;
            Descripcion = factura.Descripcion;
        }

        //Caracteristicas
        public bool deshabilitar { get; set; }

        //Lista de Proovedores
        public IEnumerable<Proveedores> Proveedores { get; set; }
        
        //Factura de Formulario
        [Key]
        public int? IDFactura { get; set; }

        [Display(Name = "Proveedor")]
        [Required(ErrorMessage = "Coloque un proveedor valido")]
        public int? IDProveedor { get; set; }
        public string Vendedor { get; set; }
        [Required]
        [Display(Name = "Factura")]
        [NotMapped]
        public HttpPostedFileBase facturaPath { get; set; }
        [Column("Factura")]
        public byte[] Factura1 { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Fecha de Compra")]
        [Required]
        [FechaValida]
        public DateTime? Fecha_Compra { get; set; }
        [Required]
        [Display(Name = "Requisicion")]
        [NotMapped]
        public HttpPostedFileBase requisicionPath { get; set; }
        public byte[] Requisicion { get; set; }

        public string Descripcion { get; set; }
        //Ultima id disponible
        public int lastID { get; set; }
    }
}