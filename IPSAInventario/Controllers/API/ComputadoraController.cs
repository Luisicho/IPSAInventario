using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Http;
using IPSAInventario.Models;
using IPSAInventario.Dtos;
using AutoMapper;

namespace IPSAInventario.Controllers.API
{
    public class ComputadoraController : ApiController
    {
        //VARIABLES
        private InventarioDbcontext _context;//Variable a la base de datos
        public ComputadoraController()
        {
            _context = new InventarioDbcontext();//Iniciar base de datos
        }
        //GET /api/computadora
        public IHttpActionResult GetComputadora()
        {
            var computadora = _context.Computadora
                .ToList(); //Retorna una lista 
            return Ok(computadora);
        }
        //DELETE /api/computadora/1
        [HttpDelete]
        public IHttpActionResult DeleteComputadora(string id)
        {
            //Consulta el modelo con id x
            var computadoraInDB = _context.Computadora.SingleOrDefault(c => c.Codigo_PC == id);
            //Valida si el modelo existe
            if (!ModelState.IsValid)
                return NotFound();
            //Elimina modelo de DB
            _context.Computadora.Remove(computadoraInDB);
            //Actualiza el modelo en DB
            _context.SaveChanges();

            return Ok();
        }
    }
}