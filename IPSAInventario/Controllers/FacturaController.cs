using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using IPSAInventario.ViewModels;

namespace IPSAInventario.Controllers
{
    public class FacturaController : Controller
    {
        private InventarioDbcontext _context;

        public FacturaController()
        {
            _context = new InventarioDbcontext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        

        public ActionResult NewFactura()
        {
            var newFactura = new FacturaFormViewModel
            {
                Provedores = GetProveedores()
            };
            return View(newFactura);
        }
        // GET: Factura
        public ActionResult Index()
        {
            var factura = _context.Factura.Include(f => f.Factura_Detalle_Comp).ToList();
            return View(factura);
        }

        //Funciones de Controlador
        [HttpPost]
        public ActionResult Create(FacturaFormViewModel newFactura)
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var factura = _context.Factura.SingleOrDefault(f => f.IDFactura == id);
            if(factura == null)
                return HttpNotFound();
            var newFactura = new FacturaFormViewModel
            {
                Factura = factura,
                Provedores = GetProveedores()
            };
            return View("FacturaForm",newFactura);
        }
        public IEnumerable<string> GetProveedores()
        {
            return new List<string>
            {
                "Juan",
                "Pepe",
                "Felipe"
            };
        }
    }
}