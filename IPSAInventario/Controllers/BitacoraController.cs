using System;
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
            var bitacora = new Bitacora()
            {
                Codigo_PC = id
            };
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

        // GET: /Bitacora/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Bitacora bitacora)
        {

            if (!ModelState.IsValid)
            {
                var newBitacora = new BitacoraFormViewModel(bitacora);
                return View("BitacoraForm", newBitacora);
            }

            if (bitacora.IDBitacora == 0)
            {
                //agrega model a DB
                _context.Bitacora.Add(bitacora);
            }
            else
            {
                var bitacoraInDb = _context.Bitacora.Single(b => b.IDBitacora == bitacora.IDBitacora);
                bitacoraInDb.Expediente = bitacora.Expediente;
                bitacoraInDb.Falla_Reportada = bitacora.Falla_Reportada;
                bitacoraInDb.Que_Presenta = bitacora.Que_Presenta;
                bitacoraInDb.Causa = bitacora.Causa;
                bitacoraInDb.Accion = bitacora.Accion;
                bitacoraInDb.Observaciones = bitacora.Observaciones;
                bitacoraInDb.Reporto = bitacora.Reporto;
                bitacoraInDb.Atendio = bitacora.Atendio;
                bitacoraInDb.Fecha_Reporte = bitacora.Fecha_Reporte;
                bitacoraInDb.Fecha_Solucion = bitacora.Fecha_Solucion;
                bitacoraInDb.Ubicacion = bitacora.Ubicacion;
                bitacoraInDb.Computadora = bitacora.Computadora;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Bitacora",new {id = bitacora.Codigo_PC.Trim()});
        }

        // GET: /Bitacora/Edit/id(Codigo_PC)
        public ActionResult Edit(int id)
        {
            var bitacoraInDb = _context.Bitacora.SingleOrDefault(b => b.IDBitacora == id);
            if (bitacoraInDb == null)
                return HttpNotFound();
            var nuevaVista = new BitacoraFormViewModel(bitacoraInDb);
            return View("BitacoraForm", nuevaVista);
        }
    }
}