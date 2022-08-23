using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using IPSAInventario.Models;

namespace IPSAInventario.Controllers.API
{
    public class PerifericosController : ApiController
    {
        private InventarioDbcontext _context;
        public PerifericosController()
        {
            _context = new InventarioDbcontext();
        }
        // GET: /api/perifericos
        [HttpGet]
        public IHttpActionResult GetPerifericos()
        {
            var perifericos = _context.Perifericos.ToList();
            return Ok(perifericos);
        }
        // GET: /api/perifericos/id(idPeriferico)
        [HttpDelete]
        public IHttpActionResult DeletePerifericos(string id)
        {
            var periferico = _context.Perifericos.SingleOrDefault(m => m.IDPeriferico == id);
            if (periferico == null)
                return NotFound();
            _context.Perifericos.Remove(periferico);
            _context.SaveChanges();
            return Ok();
        }
    }
}