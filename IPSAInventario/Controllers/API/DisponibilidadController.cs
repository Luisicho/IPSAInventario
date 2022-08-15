using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using IPSAInventario.Models;
using IPSAInventario.Dtos;
using AutoMapper;

namespace IPSAInventario.Controllers.API
{
    public class DisponibilidadController : ApiController
    {
        //VARIABLES
        private InventarioDbcontext _context;//Variable a la base de datos
        public DisponibilidadController()
        {
            _context = new InventarioDbcontext();//Iniciar base de datos
        }
        //GET /api/Disponibilidad/id(Codigo_PC)
        [HttpGet]
        public IHttpActionResult GetDisponibilidad(string id)
        {
            var disponibilidad = _context.Disponibilidad.Where(b => b.Codigo_PC == id);
            return Ok(disponibilidad);
        }
        //DELETE /api/Disponibilidad/1
        [HttpDelete]
        public IHttpActionResult DeleteDisponibilidad(int id)
        {
            var disponibilidadInDB = _context.Disponibilidad.SingleOrDefault(b => b.IdDisponibilidad == id);
            if (disponibilidadInDB == null)
                return NotFound();
            _context.Disponibilidad.Remove(disponibilidadInDB);
            _context.SaveChanges();
            return Ok();
        }
    }
}