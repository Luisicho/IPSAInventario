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
        // GET: /Disponibilidad/NewDisponibilidad/id(codigoPC)
        [HttpGet]
        public ActionResult NewDisponibilidad(string id)
        {
            var newDisponibilidad = new DisponibilidadFormViewModel(
                new Disponibilidad()
                {
                    Codigo_PC = id,
                    IdDisponibilidad = 0
                })
            {
            };
            return View("DisponibilidadForm", newDisponibilidad);
        }
        // GET: /Disponibilidad/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Disponibilidad disponibilidad)
        {

            if (!ModelState.IsValid)
            {
                var newDisponibilidad = new DisponibilidadFormViewModel(disponibilidad);
                return View("DisponibilidadForm", newDisponibilidad);
            }

            if (disponibilidad.IdDisponibilidad == 0)
            {
                //agrega model a DB
                _context.Disponibilidad.Add(disponibilidad);
            }
            else
            {
                var disponibilidadInDb = _context.Disponibilidad.Single(d => d.IdDisponibilidad == disponibilidad.IdDisponibilidad);
                disponibilidadInDb.Computadora = disponibilidad.Computadora;
                disponibilidadInDb.Area = disponibilidad.Area;
                disponibilidadInDb.Departamento = disponibilidad.Departamento;
                disponibilidadInDb.Ubicacion_Act = disponibilidad.Ubicacion_Act;
                disponibilidadInDb.Status_ = disponibilidad.Status_;
                disponibilidadInDb.Disponible = disponibilidad.Disponible;
                disponibilidadInDb.Fecha_Asignacion = disponibilidad.Fecha_Asignacion;
                disponibilidadInDb.Responsable = disponibilidad.Responsable;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Disponibilidad", new { id = disponibilidad.Codigo_PC.Trim() });
        }
        // GET: /Disponibilidad/Edit/id(Codigo_PC)
        public ActionResult Edit(int id)
        {
            var disponibilidadInDb = _context.Disponibilidad.SingleOrDefault(d => d.IdDisponibilidad == id);
            if (disponibilidadInDb == null)
                return HttpNotFound();
            var nuevaVista = new DisponibilidadFormViewModel(disponibilidadInDb);
            return View("DisponibilidadForm", nuevaVista);
        }
    }
}