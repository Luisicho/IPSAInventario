using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using IPSAInventario.Models;

namespace IPSAInventario.Controllers.API
{
    public class RanurasController : ApiController
    {
        //VARIABLES
        private InventarioDbcontext _context;//Variable a la base de datos
        public RanurasController()
        {
            _context = new InventarioDbcontext();//Iniciar base de datos
        }
        //GET /api/Ranuras
        public IHttpActionResult GetRanuras()
        {
            var ranuras = _context.Ranuras
                .ToList(); //Retorna una lista 
            return Ok(ranuras);
        }
    }
}