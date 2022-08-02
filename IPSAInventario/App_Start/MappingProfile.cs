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

            // Customer Mappings
                // API -> Outbound
                Mapper.CreateMap<Factura, FacturaDto>();
                // API <- Inbound
                Mapper.CreateMap<FacturaDto, Factura>();
                // API -> Outbound
                Mapper.CreateMap<Proveedores, ProveedoresDto>();
                // API -> Outbound
                Mapper.CreateMap<Factura_Detalle_Comp, Factura_Detalle_CompDto>();
                // API -> Outbound
                Mapper.CreateMap<Factura_Detalle_Per, Factura_Detalle_PerDto>();
                // API -> Outbound
                Mapper.CreateMap<Factura_Detalle_Soft, Factura_Detalle_SoftDto>();

            // API -> Outbound
            Mapper.CreateMap<Software, SoftwareDto>();
            // API <- Inbound
            Mapper.CreateMap<SoftwareDto, Software>();
            // API -> Outbound
            Mapper.CreateMap<Computadora_Software, Computadora_SoftwareDto>();

        }
    }
}