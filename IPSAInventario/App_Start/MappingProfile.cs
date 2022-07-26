using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using IPSAInventario.Models;
using IPSAInventario.Dtos;

namespace IPSAInventario.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Inicializa el mapper y asigna sus propiedades a las necesarias
            Mapper.CreateMap<Factura, FacturaDto>();
            Mapper.CreateMap<FacturaDto, Factura>();

        }
    }
}