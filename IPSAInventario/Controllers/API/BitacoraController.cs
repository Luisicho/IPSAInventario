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
            var bitacoras = _context.Bitacora.Where(c => c.Codigo_PC == id); // retorna lista de bitacoras que contengan esta ID
            return Ok(bitacoras);
        }
    }
}