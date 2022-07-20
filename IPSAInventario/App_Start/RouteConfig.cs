using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IPSAInventario
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Habilitando atributos
            routes.MapMvcAttributeRoutes();
            //Ruta Statica
            /*routes.MapRoute(
                "Inicio",
                "factura/index",
                new { controller = "Factura", action = "index" });
            /*"MoviesByReleaseDate",
            "movies/released/{year}/{month}",
            new { controller = "Factura", action = "index" },
            new { year = @"2015|2016", month = @"\d{2}" });*/

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
