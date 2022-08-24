using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPSAInventario.ViewModels;
using IPSAInventario.Models;

namespace IPSAInventario.Controllers
{
    public class PerifericosController : Controller
    {
        private InventarioDbcontext _context;

        public PerifericosController()
        {
            _context = new InventarioDbcontext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Perifericos
        public ActionResult Index()
        {
            return View();
        }
        // GET: /Perifericos/NewPerifericos
        public ActionResult NewPerifericos()
        {
            var newPerifericos = new PerifericosFormViewModel(new Perifericos());
            return View("PerifericosForm", newPerifericos);
        }
        //----------------------------------------Funciones de Controlador (CRUD)
        // GET: Perifericos/save
        // Inserta un nuevo modelo a la base de datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Perifericos perifericos)
        {
            if (!ModelState.IsValid)
            {
                var nuevaVista = new PerifericosFormViewModel(perifericos);
                return View("PerifericosForm", nuevaVista);
            }
            var perifericoInDb = _context.Perifericos.SingleOrDefault(m => m.IDPeriferico == perifericos.IDPeriferico.Trim());
            if (perifericoInDb == null)
            {
                _context.Perifericos.Add(perifericos);
            }
            else
            {
                perifericoInDb.Marca = perifericos.Marca;
                perifericoInDb.Modelo = perifericos.Modelo;
                perifericoInDb.NoSerie = perifericos.NoSerie;
                perifericoInDb.Revisado = perifericos.Revisado;
                perifericoInDb.Baja = perifericos.Baja;
                perifericoInDb.Aplicacion = perifericos.Aplicacion;
                perifericoInDb.Expediente = perifericos.Expediente;
                perifericoInDb.Comentario = perifericos.Comentario;
                perifericoInDb.Disponibilidad = perifericos.Disponibilidad;
                perifericoInDb.Check_ = perifericos.Check_;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Perifericos");
        }
        // GET: Perifericos/Edit
        // Actualiza (Eliminar e Insertar) un nuevo model a la base de datos
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var perifericos = _context.Perifericos.SingleOrDefault(m => m.IDPeriferico == id);
            if (perifericos == null)//Valida existencia
                return HttpNotFound(); //Error
            var newPerifericosVM = new PerifericosFormViewModel(perifericos)
            {
                HabilitarDropDown = false,
                HabilitarTextBox = false
            };//Renderisa modelo
            return View("PerifericosForm", newPerifericosVM);//Manda modelo a FormView
        }
        // GET: Perifericos/EditTipoPeriferico
        // Inicia Tipo de periferico view
        [HttpGet]
        public ActionResult EditTipoPeriferico(string id, string tipoPeriferico)
        {
            
            return Content("id: " + id + " tipoPer: " + tipoPeriferico);
        }
    }
}