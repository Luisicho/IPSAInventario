using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using IPSAInventario.Models;
using IPSAInventario.Dtos;
using System.Data.Entity;
using AutoMapper;

namespace IPSAInventario.Controllers.API
{
    public class HardwareController : ApiController
    {
        //VARIABLES
        private InventarioDbcontext _context;//Variable a la base de datos
        public HardwareController()
        {
            _context = new InventarioDbcontext();//Iniciar base de datos
        }
        //GET /api/hardware
        public IHttpActionResult GetHardware()
        {
            var hardware = _context.Hardware
                .Include(h => h.Ranura_Detalle_Hard)
                .ToList() //Retorna una lista 
                .Select(Mapper.Map<Hardware, HardwareDto>); //Mapea modelo a modeloDto
            return Ok(hardware);
        }
        //GET /api/hardware/1
        public IHttpActionResult GetHardware(int id)
        {
            //Consulta la DB por un modelo con id x
            var hardwareInDB = _context.Hardware.SingleOrDefault(h => h.IDHardware == id);
            //Valida si encontro un modelo con id x
            if (hardwareInDB == null)
                return NotFound();
            return Ok(Mapper.Map<Hardware, HardwareDto>(hardwareInDB));
        }
        //DELETE /api/hardware/1
        [HttpDelete]
        public IHttpActionResult DeleteHardware(int id)
        {
            //Consulta el modelo con id x
            var hardwareInDB = _context.Hardware.SingleOrDefault(h => h.IDHardware == id);
            //Valida si el modelo existe
            if (!ModelState.IsValid)
                return NotFound();
            //Elimina modelo de DB
            _context.Hardware.Remove(hardwareInDB);
            //Actualiza el modelo en DB
            _context.SaveChanges();

            return Ok();
        }
    }
}