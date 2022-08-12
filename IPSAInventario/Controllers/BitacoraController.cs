﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPSAInventario.Models;
using IPSAInventario.ViewModels;

namespace IPSAInventario.Controllers
{
    public class BitacoraController : Controller
    {
        //VARIABLES
        private InventarioDbcontext _context;//Base de datos

        //Inicia la base de datos para sus consulta
        public BitacoraController()
        {
            _context = new InventarioDbcontext();
        }
        //Cierra la conexion a la base de datos
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // Bitacora/Index/id(Codigo_PC)
        [HttpGet]
        public ActionResult Index(string id)
        {
            var bitacora = new Bitacora();
            bitacora.Codigo_PC = id;
            return View(bitacora);
        }
        // GET: /Bitacora/NewBitacora/id(codigoPC)
        [HttpGet]
        public ActionResult NewBitacora(string id)
        {
            var newBitacora = new BitacoraFormViewModel(
                new Bitacora() 
                { 
                    Codigo_PC = id,
                    IDBitacora = 0
                })
            {
            };
            return View("BitacoraForm", newBitacora);
        }
    }
}