using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Http;
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
                .Include(s => s.Factura_Detalle_Soft)
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
        //POST /api/software
        [HttpPost]
        public IHttpActionResult CreateSoftware(SoftwareDto softwareDto)
        {
            //Valida si el software a guardar esta correcta
            if (!ModelState.IsValid)
                return BadRequest();
            //Combierto el mappeo a una software
            var software = Mapper.Map<SoftwareDto, Software>(softwareDto);
            //Agrega el software nueva a DB
            _context.Software.Add(software);
            //Actualiza la DB con el software nueva
            _context.SaveChanges();
            //Actualiza la id generada en la DB a el software Dto
            softwareDto.IDSoftware = software.IDSoftware;
            /*Para ver el cambio dentro de la peticion de la API es necesario utilizcar IHttpActionResult
             luego crear u URL a la pagina en este caso /api/software/{id}, y mandar el objeto*/
            return Created(new Uri(Request.RequestUri + "/" + software.IDSoftware), softwareDto);
        }
        //PUT /api/software/1
        [HttpPut]
        public IHttpActionResult UpdateSoftware(int id, SoftwareDto softwareDto)
        {
            //Valida si el software a guardar esta correcta
            if (!ModelState.IsValid)
                return BadRequest();
            //Consulta la DB por un software con id x
            var softwareInDB = _context.Software.SingleOrDefault(s => s.IDSoftware == id);
            //Valida si encontro la factura con id x
            if (softwareInDB == null)
                return NotFound();
            //Actualiza la factura a DB
            Mapper.Map<SoftwareDto, Software>(softwareDto, softwareInDB);
            //Actualiza la DB con la factura nueva
            _context.SaveChanges();

            return Ok();
        }
        //DELETE /api/software/1
        [HttpDelete]
        public IHttpActionResult DeleteSoftware(int id)
        {
            //Consulta el software con id x
            var softwareInDB = _context.Software.SingleOrDefault(s => s.IDSoftware == id);
            //Valida si el software existe
            if (!ModelState.IsValid)
                return NotFound();
            //Elimina software de DB
            _context.Software.Remove(softwareInDB);
            //Actualiza el software en DB
            _context.SaveChanges();

            return Ok();
        }
    }
}