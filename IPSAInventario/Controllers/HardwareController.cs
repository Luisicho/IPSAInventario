using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPSAInventario.ViewModels;
using IPSAInventario.Models;

namespace IPSAInventario.Controllers
{
    public class HardwareController : Controller
    {
        //VARIABLES
        private InventarioDbcontext _context;//Base de datos

        //Inicia la base de datos para sus consulta
        public HardwareController()
        {
            _context = new InventarioDbcontext();
        }
        //Cierra la conexion a la base de datos
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: /Hardware
        public ActionResult Index()
        {
            return View();
        }
        // GET: /Hardware/NewHardware
        public ActionResult NewHardware()
        {
            var newHardware = new HardwareFormViewModel(new Hardware())
            {
            };
            return View("HardwareForm", newHardware);
        }
        //----------------------------------------Funciones de Controlador (CRUD)
        // GET: Hardware/save
        // Inserta un nuevo modelo a la base de datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Hardware hardware)
        {
            // Nos permite pedir acceso para validaciones
            if (!ModelState.IsValid)
            {
                var nuevaVista = new HardwareFormViewModel(hardware)
                {

                };
                return View("HardwareForm", nuevaVista);
            }

            if (hardware.IDHardware == 0)
            {
                //agrega model a DB
                _context.Hardware.Add(hardware);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Hardware");
        }
    }
}