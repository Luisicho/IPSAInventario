using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IPSAInventario.Models;

namespace IPSAInventario.Controllers.API
{
    public class FacturaController : ApiController
    {
        //VARIABLES
        private InventarioDbcontext _context;//Variable a la base de datos
        public FacturaController()
        {
            
            _context = new InventarioDbcontext();//Iniciar base de datos
        }
        //GET /api/factura
        public IEnumerable<Factura> GetFactura()
        {
            return _context.Factura.ToList();//Retorna una lista de facturas
        }

        //GET /api/factura/1
        public Factura GetFactura(int id)
        {
            //Consulta la DB por una factura con id x
            var facturaInDB = _context.Factura.SingleOrDefault(f => f.IDFactura == id);
            //Valida si encontro la factura con id x
            if (facturaInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return facturaInDB; 
        }
        //POST /api/factura
        [HttpPost]
        public Factura CreateFactura(Factura factura)
        {
            //Valida si la factura a guardar esta correcta
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            //Agrega la factura nueva a DB
            _context.Factura.Add(factura);
            //Actualiza la DB con la factura nueva
            _context.SaveChanges();
            return factura;
        }

        //PUT /api/factura/1
        [HttpPut]
        public void UpsateFactura(int id,Factura factura)
        {
            //Valida si la factura a guardar esta correcta
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            //Consulta la DB por una factura con id x
            var facturaInDB = _context.Factura.SingleOrDefault(f => f.IDFactura == id);
            //Valida si encontro la factura con id x
            if (facturaInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            //Actualiza la factura a DB
            facturaInDB.IDFactura = factura.IDFactura;
            facturaInDB.Proveedores = factura.Proveedores;
            facturaInDB.Vendedor = factura.Vendedor;
            facturaInDB.Requisicion = factura.Requisicion;
            facturaInDB.Factura1 = factura.Factura1;
            facturaInDB.Fecha_Compra = factura.Fecha_Compra;
            facturaInDB.Descripcion = factura.Descripcion;
            //Actualiza la DB con la factura nueva
            _context.SaveChanges();
        }
        //DELETE /api/factura/1
        [HttpDelete]
        public void DeleteFactura(int id)
        {
            //Consulta la factura con id x
            var facturaInDB = _context.Factura.SingleOrDefault(f => f.IDFactura == id);
            //Valida si la factura existe
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            //Elimina factura de DB
            _context.Factura.Remove(facturaInDB);
            //Actualiza la factura en DB
            _context.SaveChanges();
        }
    }
}
