using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using IPSAInventario.Models;

namespace IPSAInventario.Controllers.API
{
    public class BitacoraController : ApiController
    {
        //VARIABLES
        private InventarioDbcontext _context;//Variable a la base de datos
        public BitacoraController()
        {
            _context = new InventarioDbcontext();//Iniciar base de datos
        }
        //GET /api/bitacora/id(Codigo_PC)
        [HttpGet]
        public IHttpActionResult GetBitacora(string id)
        {
            var bitacoras = _context.Bitacora.Where(b => b.Codigo_PC == id); // retorna lista de bitacoras que contengan esta ID
            return Ok(bitacoras);
        }
        //DELETE /api/bitacora/1
        [HttpDelete]
        public IHttpActionResult DeleteBitacora(int id)
        {
            //Consulta el modelo con id x
            var bitacoraInDB = _context.Bitacora.SingleOrDefault(b => b.IDBitacora == id);
            //Valida si el modelo existe
            if (bitacoraInDB == null)
                return NotFound();
            //Elimina modelo de DB
            _context.Bitacora.Remove(bitacoraInDB);
            //Actualiza el modelo en DB
            _context.SaveChanges();

            return Ok();
        }
    }
}