using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPSAInventario.Models;
using IPSAInventario.ViewModels;

namespace IPSAInventario.Controllers
{
    public class Factura_Detalle_SoftController : Controller
    {
        //VARIABLES
        private InventarioDbcontext _context;//Base de datos

        //Inicia la base de datos para sus consulta
        public Factura_Detalle_SoftController()
        {
            _context = new InventarioDbcontext();
        }
        //Cierra la conexion a la base de datos
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Factura_Detalle_Soft
        public ActionResult Index()
        {
            return View();
        }
        //----------------------------------------Funciones de Controlador (CRUD)
        // GET: Factura_Detalle_Soft/save
        // Inserta una nueva factura a la base de datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Factura_Detalle_Soft facturaDS)
        {
            // Nos permite pedir acceso para validaciones
            if (!ModelState.IsValid)
            {
                var nuevaVista = new FDetalleSoftViewModel(facturaDS)
                {
                };
                return View("Index", nuevaVista);
            }
            facturaDS.Fecha = DateTime.Now.Date;
            facturaDS.Factura = _context.Factura.Single(f => f.IDFactura == facturaDS.IDFactura);
            facturaDS.Software = _context.Software.Single(s => s.IDSoftware == facturaDS.IDSoftware);
            //Se agrega a la DB
            _context.Factura_Detalle_Soft.Add(facturaDS);
            //Actualiza la DB con la factura nueva
            _context.SaveChanges();
            return RedirectToAction("Index", "Factura");
        }
    }
}