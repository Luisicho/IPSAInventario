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
    }
}