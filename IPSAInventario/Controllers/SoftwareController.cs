using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPSAInventario.Models;
using IPSAInventario.ViewModels;
using AutoMapper;

namespace IPSAInventario.Controllers
{
    public class SoftwareController : Controller
    {
        //VARIABLES
        private InventarioDbcontext _context;//Base de datos

        //Inicia la base de datos para sus consulta
        public SoftwareController()
        {
            _context = new InventarioDbcontext();
        }
        //Cierra la conexion a la base de datos
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Software
        public ActionResult Index()
        {
            return View();
        }

        // GET: software/newSoftware
        // Crea un nuevo formulario de factura
        public ActionResult NewSoftware()
        {
            var newSoftware = new SoftwareFormViewModel(new Software())
            {
                Disponibilidad = true
            };

            return View("SoftwareForm", newSoftware);
        }
        //----------------------------------------Funciones de Controlador (CRUD)
        // GET: Factura/save
        // Inserta una nueva factura a la base de datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Software software)
        {
            // Nos permite pedir acceso para validaciones
            if (!ModelState.IsValid)
            {
                var nuevaVista = new SoftwareFormViewModel(software)
                {

                };
                return View("SoftwareForm", nuevaVista);
            }

            if (software.IDSoftware == 0)
            {
                //agrega software a DB
                _context.Software.Add(software);
            }
            else
            {
                var softwareInDB = _context.Software.SingleOrDefault(s => s.IDSoftware == software.IDSoftware);
                //softwareInDB = software;
                softwareInDB.IDSoftware = software.IDSoftware;
                softwareInDB.Product_Key = software.Product_Key;
                softwareInDB.Tipo_Lic = software.Tipo_Lic;
                softwareInDB.Licencia = software.Licencia;
                softwareInDB.Num_Licencia = software.Num_Licencia;
                softwareInDB.License_Pack_Bar_Code = software.License_Pack_Bar_Code;
                softwareInDB.License_Pack = software.License_Pack;
                softwareInDB.Certificado = software.Certificado;
                softwareInDB.AGMT_ID = software.AGMT_ID;
                softwareInDB.Activa = software.Activa;
                softwareInDB.Cantidad = software.Cantidad;
                softwareInDB.Disponibilidad = software.Disponibilidad;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Software");
        }
        // GET: Factura/Edit
        // Actualiza (Eliminar e Insertar) un nuevo software a la base de datos
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            //Consulta en la base de datos el software con la ID
            var software = _context.Software.SingleOrDefault(s => s.IDSoftware == id);
            if (software == null)//Valida existencia
                return HttpNotFound(); //Error
            var newSoftwareVM = new SoftwareFormViewModel(software)
            {
            };//Renderisa software
            return View("SoftwareForm", newSoftwareVM);//Manda Software a FormView
        }
    }
}