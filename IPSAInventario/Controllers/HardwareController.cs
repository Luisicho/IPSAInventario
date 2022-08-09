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
            else
            {
                //Consulta en la base de datos el modelo con la ID
                var hardwareInDB = _context.Hardware.SingleOrDefault(h => h.IDHardware == hardware.IDHardware);
                hardwareInDB.IDHardware = hardware.IDHardware;
                hardwareInDB.Tamano = hardware.Tamano;
                hardwareInDB.Unidad_Med = hardware.Unidad_Med;
                hardwareInDB.Velocidad = hardware.Velocidad;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Hardware");
        }
        // GET: hardware/Edit
        // Actualiza (Eliminar e Insertar) un nuevo model a la base de datos
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            //Consulta en la base de datos el modelo con la ID
            var hardware = _context.Hardware.SingleOrDefault(h => h.IDHardware == id);
            if (hardware == null)//Valida existencia
                return HttpNotFound(); //Error
            var newHardwareVM = new HardwareFormViewModel(hardware)
            {
            };//Renderisa modelo
            return View("HardwareForm", newHardwareVM);//Manda modelo a FormView
        }
    }
}