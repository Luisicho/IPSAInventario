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
                .Include(f => f.Computadora_Software)
                .ToList();
            return Ok(software);
        }

        
    }
}