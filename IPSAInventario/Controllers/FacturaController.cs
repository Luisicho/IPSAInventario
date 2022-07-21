using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using IPSAInventario.ViewModels;

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
            var factura = _context.Factura.Include(f => f.Factura_Detalle_Comp).ToList();
            return View(factura);
        }

        // GET: Factura/NewFactura
        // Crea un nuevo formulario de factura
        public ActionResult NewFactura()
        {
            var newFactura = new FacturaFormViewModel
            {
                Proveedores = GetProveedores()
            };
            return View("FacturaForm",newFactura);
        }

        //----------------------------------------Funciones de Controlador (CRUD)
        // GET: Factura/Create
        // Inserta una nueva factura a la base de datos
        [HttpPost]
        public ActionResult Create(FacturaFormViewModel newFactura)
        {
            return View();
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
            var newFactura = new FacturaFormViewModel
            {
                Factura = factura,
                Proveedores = GetProveedores()
            };//Renderisa la factura
            return View("FacturaForm",newFactura);//Manda la factura a la view FacturaForm
        }
        // Genera una lista de los proveedores
        public IEnumerable<string> GetProveedores()
        {
            return new List<string>
            {
                "Juan",
                "Pepe",
                "Felipe"
            };
        }
    }
}