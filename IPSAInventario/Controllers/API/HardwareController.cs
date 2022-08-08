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
        //GET /api/factura
        public IHttpActionResult GetHardware()
        {
            var hardware = _context.Hardware
                .Include(h => h.Ranura_Detalle_Hard)
                .ToList() //Retorna una lista 
                .Select(Mapper.Map<Hardware, HardwareDto>); //Mapea modelo a modeloDto
            return Ok(hardware);
        }
    }
}