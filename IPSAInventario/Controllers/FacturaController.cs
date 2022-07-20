using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        // GET: Factura
        public ActionResult Index()
        {
            var factura = _context.Factura.ToList();
            return View(factura);
        }
    }
}