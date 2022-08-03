using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPSAInventario.Models;
using IPSAInventario.ViewModels;
using AutoMapper;

namespace IPSAInventario.Controllers
{
    public class SoftwareController : Controller
    {
        //VARIABLES
        private InventarioDbcontext _context;//Base de datos

        //Inicia la base de datos para sus consulta
        public SoftwareController()
        {
            _context = new InventarioDbcontext();
        }
        //Cierra la conexion a la base de datos
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Software
        public ActionResult Index()
        {
            return View();
        }

        // GET: software/newSoftware
        // Crea un nuevo formulario de factura
        public ActionResult NewSoftware()
        {
            var newSoftware = new SoftwareFormViewModel(new Software())
            {

            };

            return View("SoftwareForm", newSoftware);
        }
    }
}