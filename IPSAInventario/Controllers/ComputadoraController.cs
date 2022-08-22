using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPSAInventario.ViewModels;
using IPSAInventario.Models;

namespace IPSAInventario.Controllers
{
    public class ComputadoraController : Controller
    {
        //VARIABLES
        private InventarioDbcontext _context;//Base de datos

        //Inicia la base de datos para sus consulta
        public ComputadoraController()
        {
            _context = new InventarioDbcontext();
        }
        //Cierra la conexion a la base de datos
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET /Computadora
        public ActionResult Index()
        {
            return View();
        }
        // GET: /Computadora/NewComputadora
        public ActionResult NewComputadora()
        {
            var newComputadora = new ComputadoraFormViewModel(new Computadora())
            {
            };
            return View("ComputadoraForm", newComputadora);
        }
        // GET: /Computadora/NewAsignaComputadora
        public ActionResult NewAsignaComputadora()
        {
            var asignaView = new AsignaComputadoraViewModel();
            return View("AsignaComputadora", asignaView);
        }
        //----------------------------------------Funciones de Controlador (CRUD)
        // GET: Computadora/save
        // Inserta un nuevo modelo a la base de datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Computadora computadora)
        {
            // Nos permite pedir acceso para validaciones
            if (!ModelState.IsValid)
            {
                var nuevaVista = new ComputadoraFormViewModel(computadora)
                {

                };
                return View("ComputadoraForm", nuevaVista);
            }
            //Consulta en la base de datos el modelo con la ID
            var computadoraInDB = _context.Computadora.SingleOrDefault(c => c.Codigo_PC == computadora.Codigo_PC);

            if (computadoraInDB == null)
            {
                //agrega model a DB
                _context.Computadora.Add(computadora);
            }
            else
            {
                //Computadora 
                computadoraInDB.Actualizado = computadora.Actualizado;
                computadoraInDB.Baja = computadora.Baja;
                computadoraInDB.Aplicacion = computadora.Aplicacion;
                computadoraInDB.Expediente = computadora.Expediente;
                computadoraInDB.Check_ = computadora.Check_;
                computadoraInDB.Maquina = computadora.Maquina;
                computadoraInDB.Red = computadora.Red;
                computadoraInDB.IPV4 = computadora.IPV4;
                computadoraInDB.Mascara_IPV4 = computadora.Mascara_IPV4;
                computadoraInDB.IPV6 = computadora.IPV6;
                computadoraInDB.Mascara_IPV6 = computadora.Mascara_IPV6;
                computadoraInDB.Internet = computadora.Internet;
                computadoraInDB.Correo = computadora.Correo;
                computadoraInDB.Tipo_Computador = computadora.Tipo_Computador;
                computadoraInDB.Observaciones = computadora.Observaciones;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Computadora");
        }
        // GET: Computadora/Edit
        // Actualiza (Eliminar e Insertar) un nuevo model a la base de datos
        [HttpGet]
        public ActionResult Edit(string id)
        {
            //Consulta en la base de datos el modelo con la ID
            var computadora = _context.Computadora.SingleOrDefault(c => c.Codigo_PC == id);
            if (computadora == null)//Valida existencia
                return HttpNotFound(); //Error
            var nuevaVista = new ComputadoraFormViewModel(computadora)
            {
                txtCodigoPC = false
            };//Renderisa modelo
            return View("ComputadoraForm", nuevaVista);//Manda modelo a FormView
        }
        // GET: Computadora/SaveInFactura
        // Inserta un nuevo modelo a la base de datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveInFactura(Factura_Detalle_Comp factura_Detalle_Comp)
        {
            if (!ModelState.IsValid)
            {
                var asignaView = new AsignaComputadoraViewModel(factura_Detalle_Comp);
                return View("AsignaComputadora", asignaView);
            }
            factura_Detalle_Comp.Fecha = DateTime.Now;
            factura_Detalle_Comp.Hora = DateTime.Now.TimeOfDay;

            _context.Factura_Detalle_Comp.Add(factura_Detalle_Comp);
            _context.SaveChanges();
            return RedirectToAction("Index", "Computadora");
        }
    }
}