using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using System.Data.Entity;
using IPSAInventario.ViewModels;
using IPSAInventario.Models;
using System.IO;

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
            return View();
        }

        // GET: Factura/NewFactura
        // Crea un nuevo formulario de factura
        public ActionResult NewFactura()
        {
            var ultimoId = _context.Factura.Select(f => f.IDFactura).ToList().Max();//Selecciona el IDMaximo
            var newFactura = new FacturaFormViewModel(new Factura())
            {
                Proveedores = _context.Proveedores,
                lastID = ultimoId  //consigue el ultimo id factura
            };
            
            return View("FacturaForm",newFactura);
        }

        //----------------------------------------Funciones de Controlador (CRUD)
        // GET: Factura/save
        // Inserta una nueva factura a la base de datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Factura factura)
        {
             // Nos permite pedir acceso para validaciones
            if (!ModelState.IsValid)
            {
                var ultimoId = _context.Factura.Select(f => f.IDFactura).ToList().Max();//Selecciona el IDMaximo
                var nuevaVista = new FacturaFormViewModel(factura)
                {
                    lastID = ultimoId, //asigna el ultimo id factura
                    Proveedores = _context.Proveedores
                };
                return View("FacturaForm", nuevaVista);
            }
            
            if (factura.IDFactura == 0)
            {
                //Funcion para convertir factura a bits
                var ms = new MemoryStream();//Se crea variable para crear matriz de bit y guardar en DB
                factura.facturaPath.InputStream.CopyTo(ms); //Copia la informacion al arreglo a ms
                byte[] facturaBits = ms.ToArray(); // Crea arreglo de bits de la factura

                //Funcion para convertir requisicion a bits
                var ms2 = new MemoryStream();//Se crea variable para crear matriz de bit y guardar en DB
                factura.requisicionPath.InputStream.CopyTo(ms2); //Copia la informacion al arreglo a ms
                byte[] requisicionBits = ms2.ToArray(); // Crea arreglo de bits de la requisicion

                //Asigna los arreglos a la factura
                factura.Factura1 = facturaBits;
                factura.Requisicion = requisicionBits;

                //agrega la facura a DB
                _context.Factura.Add(factura);
            }
            else
            {
                //Busca la factura en la base de datos
                var facturaInDB = _context.Factura.Single(f => f.IDFactura == factura.IDFactura);
                //Actualiza todas las propiedades de tu objeto en DB
                //TryUpdateModel(facturaInDB);s
                //Se busca no permitir el uso indevido de la aplicacion por lo tanto se asignaran los valores manualmente
                //Se puede reducir el codigo utilizando un Maper Mapper.Map(factura,facturaInDB);
                facturaInDB.IDFactura = factura.IDFactura;
                facturaInDB.Proveedores = factura.Proveedores;
                facturaInDB.Vendedor = factura.Vendedor;
                facturaInDB.Requisicion = factura.Requisicion;
                facturaInDB.Factura1 = factura.Factura1;
                facturaInDB.Fecha_Compra = factura.Fecha_Compra;
                facturaInDB.Descripcion = factura.Descripcion;
            }
            //Actualiza la DB con la factura nueva
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
            var newFacturaVM = new FacturaFormViewModel(factura)
            {
                Proveedores = _context.Proveedores,
                deshabilitar = true
            };//Renderisa la factura
            return View("FacturaForm", newFacturaVM);//Manda la factura a la view FacturaForm
        }
    }
}