using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PagonetCore
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "CrearAlmacen",
                routeTemplate: "Almacen/guardarDatos"
            );

            config.Routes.MapHttpRoute(
                name: "CrearCondicionDePago",
                routeTemplate: "Condicion/guardarDatos"
            );

            config.Routes.MapHttpRoute(
                name: "CrearCotizacion",
                routeTemplate: "cotizacion/guardarDatos"
            );

            config.Routes.MapHttpRoute(
                name: "CrearIngreso",
                routeTemplate: "Ingresos/guardarDatos"
            );

            config.Routes.MapHttpRoute(
                name: "CrearPais",
                routeTemplate: "Adpais/guardarDatos"
            );

            config.Routes.MapHttpRoute(
                name: "CrearRenglonCotizacion",
                routeTemplate: "cotizacion/guardarDatosreng"
            );

            config.Routes.MapHttpRoute(
                name: "CrearSegmento",
                routeTemplate: "Segmento/GuardarDatos"
            );

            config.Routes.MapHttpRoute(
                name: "CrearTipoCliente",
                routeTemplate: "Tipocliente/guardarDatos"
            );

            config.Routes.MapHttpRoute(
                name: "CrearZona",
                routeTemplate: "Zona/guardarDatos"
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
