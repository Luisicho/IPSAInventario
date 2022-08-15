using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPSAInventario.Models;
using IPSAInventario.ViewModels;

namespace IPSAInventario.Controllers
{
    public class DisponibilidadController : Controller
    {
        //VARIABLES
        private InventarioDbcontext _context;//Base de datos

        //Inicia la base de datos para sus consulta
        public DisponibilidadController()
        {
            _context = new InventarioDbcontext();
        }
        //Cierra la conexion a la base de datos
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // Disponibilidad/Index/id(Codigo_PC)
        [HttpGet]
        public ActionResult Index(string id)
        {
            var disponibilidad = new Disponibilidad()
            {
                IdDisponibilidad = 0,
                Codigo_PC = id
            };
            return View(disponibilidad);
        }
    }
}