using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using IPSAInventario.ViewModels;
using IPSAInventario.Models;

namespace IPSAInventario.Controllers
{
    public class FacturaController : Controller
    {
        //VARIABLES
        private InventarioDbcontext _context;//Base de datos

        //Inicia la base de datos para sus consulta
        public FacturaController()
        {
            _context = new InventarioDbcontext();
        }
        //Cierra la conexion a la base de datos
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Factura
        public ActionResult Index()
        {
            var factura = _context.Factura.Include(f => f.Proveedores)
                                          .Include(f => f.Factura_Detalle_Comp)
                                          .Include(f => f.Factura_Detalle_Per)
                                          .Include(f => f.Factura_Detalle_Soft).ToList();
            return View(factura);
        }

        // GET: Factura/NewFactura
        // Crea un nuevo formulario de factura
        public ActionResult NewFactura()
        {
            var newFactura = new FacturaFormViewModel
            {
                Proveedores = _context.Proveedores,
                lastID = _context.Factura.Count()
            };
            return View("FacturaForm",newFactura);
        }

        //----------------------------------------Funciones de Controlador (CRUD)
        // GET: Factura/Create
        // Inserta una nueva factura a la base de datos
        [HttpPost]
        public ActionResult Save(FacturaFormViewModel newFacturaVM)
        {
            // Validaciones
            // Nos permite pedir acceso para validaciones
            if (!ModelState.IsValid)
            {
                var nuevaVista = new FacturaFormViewModel
                {
                    Factura = newFacturaVM.Factura,
                    lastID = _context.Factura.Count(),
                    Proveedores = _context.Proveedores
                };
                nuevaVista.Factura.IDFactura = nuevaVista.lastID + 1;
                return View("FacturaForm", nuevaVista);
            }
            if (newFacturaVM.Factura.IDFactura == 0)
                //agrega la facura
                _context.Factura.Add(newFacturaVM.Factura);
            else
            {
                //Busca la factura en la base de datos
                var facturainDB = _context.Factura.Single(f => f.IDFactura == newFacturaVM.Factura.IDFactura);
                //Actualiza todas las propiedades de tu objeto en DB
                //TryUpdateModel(facturainDB);
                //Se busca no permitir el uso indevido de la aplicacion por lo tanto se asignaran los valores manualmente
                //Se puede reducir el codigo utilizando un Maper Mapper.Map(newFacturaVM,facturainDB);
                facturainDB.IDFactura = newFacturaVM.Factura.IDFactura;
                facturainDB.Proveedores = newFacturaVM.Factura.Proveedores;
                facturainDB.Vendedor = newFacturaVM.Factura.Vendedor;
                facturainDB.Requisicion = newFacturaVM.Factura.Requisicion;
                facturainDB.Factura1 = newFacturaVM.Factura.Factura1;
                facturainDB.Fecha_Compra = newFacturaVM.Factura.Fecha_Compra;
                facturainDB.Descripcion = newFacturaVM.Factura.Descripcion;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Factura");
        }
        // GET: Factura/Edit
        // Actualiza (Eliminar e Insertar) una nueva factura a la base de datos
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            //Consulta en la base de datos la factura con la ID
            var factura = _context.Factura.SingleOrDefault(f => f.IDFactura == id);
            if(factura == null)//Valida existencia
                return HttpNotFound(); //Error
            var newFacturaVM = new FacturaFormViewModel
            {
                Factura = factura,
                Proveedores = _context.Proveedores
            };//Renderisa la factura
            return View("FacturaForm", newFacturaVM);//Manda la factura a la view FacturaForm
        }
    }
}