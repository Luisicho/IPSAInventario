﻿using System;
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
            var newRanuras = new RanurasFormViewModel(
                new Ranuras()
                {
                    IDRanura = 0
                });
            return View("RanurasForm", newRanuras);
        }
        // GET: Ranuras/RanurasIDHardware
        public ActionResult RanurasIDHardware(int id)
        {
            var hardware_detalle = new Ranura_Detalle_Hard() { IDHardware = id };
            return View("RanurasIDHardware", hardware_detalle);
        }
        // GET: /Ranuras/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Ranuras ranuras)
        {

            if (!ModelState.IsValid)
            {
                var newRanuras = new RanurasFormViewModel(ranuras);
                return View("RanurasForm", newRanuras);
            }

            if (ranuras.IDRanura== 0)
            {
                //agrega model a DB
                _context.Ranuras.Add(ranuras);
            }
            else
            {
                var ranurasInDb = _context.Ranuras.Single(r => r.IDRanura == ranuras.IDRanura);
                ranurasInDb.Codigo_PC = ranuras.Codigo_PC;
                ranurasInDb.Tipo_Slot = ranuras.Tipo_Slot;
                ranurasInDb.Disponible = ranuras.Disponible;
                ranurasInDb.Computadora = ranuras.Computadora;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Ranuras");
        }
        // GET: /Ranuras/Edit/id(idRanuras)
        public ActionResult Edit(int id)
        {
            var ranurasInDb = _context.Ranuras.SingleOrDefault(r => r.IDRanura == id);
            if (ranurasInDb == null)
                return HttpNotFound();
            var nuevaVista = new RanurasFormViewModel(ranurasInDb);
            return View("RanurasForm", nuevaVista);
        }
        //-----------------Ranura_Detalle_Hard y Ranura_Detalle_Per-------------------------
        // GET: /Ranuras/NewAsignar/id(idRanura)?asigna=(formHardware o formPeriferico)
        public ActionResult NewAsignar(int id, string asigna)
        {
            if (asigna == "1")
            {
                var nuevaAsignacion = new AsignacionHFormViewModel( 
                    new Ranura_Detalle_Hard()
                    {
                        IDRanura = id,
                    });
                return View("AsignacionHForm", nuevaAsignacion);
            }
            if (asigna == "2")
            {
                var nuevaAsignacion = new AsignacionPFormViewModel();
                return View("AsignacionPForm", nuevaAsignacion);
            }
            
            return Content("asigna =" + asigna + " id =" + id);
        }
        // GET: /Ranuras/SaveHard
        public ActionResult SaveHard(Ranura_Detalle_Hard ranura_Detalle_Hard)
        {
            if (!ModelState.IsValid)
            {
                var nuevaAsignacion = new AsignacionHFormViewModel(ranura_Detalle_Hard);
                return View("AsignacionHForm", nuevaAsignacion);
            }
            ranura_Detalle_Hard.Fecha = DateTime.Now;
            ranura_Detalle_Hard.Hora = DateTime.Now.TimeOfDay;

            _context.Ranura_Detalle_Hard.Add(ranura_Detalle_Hard);
            _context.SaveChanges();

            return RedirectToAction("Index", "Ranuras");
        }
    }
}