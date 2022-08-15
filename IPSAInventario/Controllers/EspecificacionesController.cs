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
                        IdEspecificaciones = 0,
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
        public ActionResult Save (Especificaciones especificaciones)
        {
            if (!ModelState.IsValid)
            {
                var newVista = new EspecificacionesFormViewModel(especificaciones);
                return View("EspecificacionesForm", newVista);
            }
            
            if (especificaciones.IdEspecificaciones == 0)
            {
                _context.Especificaciones.Add(especificaciones);
            }
            else
            {
                var EspecificacionInDB = _context.Especificaciones.SingleOrDefault(e => e.IdEspecificaciones == especificaciones.IdEspecificaciones);
                EspecificacionInDB.Computadora = especificaciones.Computadora;
                EspecificacionInDB.Marca = especificaciones.Marca;
                EspecificacionInDB.Serie_Maq = especificaciones.Serie_Maq;
                EspecificacionInDB.Procesador = especificaciones.Procesador;
                EspecificacionInDB.Nucleos = especificaciones.Nucleos;
                EspecificacionInDB.Velocidad = especificaciones.Velocidad;
                EspecificacionInDB.Unidad_Medida = especificaciones.Unidad_Medida;
                EspecificacionInDB.Mobo_Marca = especificaciones.Mobo_Marca;
                EspecificacionInDB.Mobo_Modelo = especificaciones.Mobo_Modelo;
                EspecificacionInDB.Mobo_Serie = especificaciones.Mobo_Serie;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Computadora");
        }
    }
}