using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPSAInventario.Models;
using IPSAInventario.ViewModels;

namespace IPSAInventario.Controllers
{
    public class RanurasController : Controller
    {
        //VARIABLES
        private InventarioDbcontext _context;//Base de datos

        //Inicia la base de datos para sus consulta
        public RanurasController()
        {
            _context = new InventarioDbcontext();
        }
        //Cierra la conexion a la base de datos
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Ranuras
        public ActionResult Index()
        {
            return View();
        }
        // GET: /Ranuras/NewRanuras
        public ActionResult NewRanuras()
        {
            var newRanuras = new RanurasFormViewModel();
            return View("RanurasForm", newRanuras);
        }
    }
}