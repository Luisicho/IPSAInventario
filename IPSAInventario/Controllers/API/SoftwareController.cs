using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using IPSAInventario.Models;
using IPSAInventario.Dtos;
using AutoMapper;

namespace IPSAInventario.Controllers.API
{
    public class SoftwareController : ApiController
    {
        //VARIABLES
        private InventarioDbcontext _context;//Variable a la base de datos
        public SoftwareController()
        {
            _context = new InventarioDbcontext();//Iniciar base de datos
        }
        //GET /api/software
        public IHttpActionResult GetSoftware()
        {
            var software = _context.Software
                .Include(s => s.Computadora_Software) //Eagle loading a tabla Computadora_Software
                .ToList() //Retorna una lista de facturas
                .Select(Mapper.Map<Software, SoftwareDto>); //Mapea Factura a FacturaDto
            return Ok(software);
        }
        //GET /api/software/1
        public IHttpActionResult GetSoftware(int id)
        {
            //Consulta la DB por una factura con id x
            var softwareInDB = _context.Software.SingleOrDefault(s => s.IDSoftware == id);
            //Valida si encontro la factura con id x
            if (softwareInDB == null)
                return NotFound();
            return Ok(Mapper.Map<Software, SoftwareDto>(softwareInDB));
        }

    }
}