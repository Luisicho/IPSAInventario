using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IPSAInventario.Models;
using IPSAInventario.Dtos;
using AutoMapper;

namespace IPSAInventario.Controllers.API
{
    public class FacturaController : ApiController
    {
        //VARIABLES
        private InventarioDbcontext _context;//Variable a la base de datos
        public FacturaController()
        {
            _context = new InventarioDbcontext();//Iniciar base de datos
        }
        //GET /api/factura
        public IHttpActionResult GetFactura()
        {
            var factura = _context.Factura .ToList().Select(Mapper.Map<Factura, FacturaDto>);//Retorna una lista de facturas
            return Ok(factura);
        }

        //GET /api/factura/1
        public IHttpActionResult GetFactura(int id)
        {
            //Consulta la DB por una factura con id x
            var facturaInDB = _context.Factura.SingleOrDefault(f => f.IDFactura == id);
            //Valida si encontro la factura con id x
            if (facturaInDB == null)
                return NotFound();
            return Ok(Mapper.Map<Factura,FacturaDto>(facturaInDB)); 
        }
        //POST /api/factura
        [HttpPost]
        public IHttpActionResult CreateFactura(FacturaDto facturaDto)
        {
            //Valida si la factura a guardar esta correcta
            if (!ModelState.IsValid)
                return BadRequest();
            //Combierto el mappeo a una factura
            var factura = Mapper.Map<FacturaDto, Factura>(facturaDto);
            //Agrega la factura nueva a DB
            _context.Factura.Add(factura);
            //Actualiza la DB con la factura nueva
            _context.SaveChanges();
            //Actualiza la id generada en la DB a la factura Dto
            facturaDto.IDFactura = factura.IDFactura;
            /*Para ver el cambio dentro de la peticion de la API es necesario utilizcar IHttpActionResult
             luego crear u URL a la pagina en este caso /api/factura/{id}, y mandar el objeto*/
            return Created(new Uri(Request.RequestUri + "/" + factura.IDFactura),facturaDto);
        }

        //PUT /api/factura/1
        [HttpPut]
        public IHttpActionResult UpdateFactura(int id,FacturaDto facturaDto)
        {
            //Valida si la factura a guardar esta correcta
            if (!ModelState.IsValid)
                return BadRequest();
            //Consulta la DB por una factura con id x
            var facturaInDB = _context.Factura.SingleOrDefault(f => f.IDFactura == id);
            //Valida si encontro la factura con id x
            if (facturaInDB == null)
                return NotFound();
            //Actualiza la factura a DB
            Mapper.Map<FacturaDto, Factura>(facturaDto,facturaInDB);
            //Actualiza la DB con la factura nueva
            _context.SaveChanges();

            return Ok();
        }
        //DELETE /api/factura/1
        [HttpDelete]
        public IHttpActionResult DeleteFactura(int id)
        {
            //Consulta la factura con id x
            var facturaInDB = _context.Factura.SingleOrDefault(f => f.IDFactura == id);
            //Valida si la factura existe
            if (!ModelState.IsValid)
                return NotFound();
            //Elimina factura de DB
            _context.Factura.Remove(facturaInDB);
            //Actualiza la factura en DB
            _context.SaveChanges();

            return Ok();
        }
    }
}
