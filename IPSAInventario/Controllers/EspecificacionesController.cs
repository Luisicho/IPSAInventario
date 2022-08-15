using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPSAInventario.Models;
using IPSAInventario.ViewModels;

namespace IPSAInventario.Controllers
{
    public class EspecificacionesController : Controller
    {
        //VARIABLES
        private InventarioDbcontext _context;//Base de datos

        //Inicia la base de datos para sus consulta
        public EspecificacionesController()
        {
            _context = new InventarioDbcontext();
        }
        //Cierra la conexion a la base de datos
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: /Especificaciones/newEspecificaciones/id(codigoPC)
        [HttpGet]
        public ActionResult newEspecificaciones(string id)
        {
            var EspecificacionInDB = _context.Especificaciones.SingleOrDefault(e => e.Codigo_PC == id);
            var newEspecificacion = new EspecificacionesFormViewModel();
            if (EspecificacionInDB == null)
            {
                newEspecificacion = new EspecificacionesFormViewModel(
                    new Especificaciones()
                    {
                        Codigo_PC = id
                    });
            }
            else
            {
                newEspecificacion = new EspecificacionesFormViewModel(EspecificacionInDB);
            }
            return View("EspecificacionesForm", newEspecificacion);
        }
        // GET: /Especificaciones/Save/id(codigoPC)
        public ActionResult Save (string id)
        {

            return View("Index","Computadora");
        }
    }
}