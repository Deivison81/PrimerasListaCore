using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PagonetCore.Controllers
{
    public class ArticuloController : Controller
    {
        // GET: Articulo
        public ActionResult Index()
        {
            return View();
        }
        // Articulos
        public JsonResult listarArticulos()
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();

            var listarArticulos = bdsql.AdArticulo.Select(p => new
            {
                p.id_art,
                p.co_art,
                p.art_des,
                p.co_lin,
                p.co_subl,
                p.co_cat,
                p.co_color,
                p.co_ubicacion,
                p.cod_proc,
                p.cod_unidad,
                p.referencia,
                p.importado_web,
                p.importado_pro
            }).ToList();
            return Json (listarArticulos, JsonRequestBehavior.AllowGet);

        }

        public JsonResult listarArticulo(int id)
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();

            var listarArticulos = bdsql.AdArticulo.Where(p=> p.id_art.Equals(id))
                .Select(p => new
            {
                p.id_art,
                p.co_art,
                p.art_des,
                p.co_lin,
                p.co_subl,
                p.co_cat,
                p.co_color,
                p.co_ubicacion,
                p.cod_proc,
                p.cod_unidad,
                p.referencia,
                p.importado_web,
                p.importado_pro
            }).ToList();
            return Json(listarArticulos, JsonRequestBehavior.AllowGet);

        }

        //Articulos con sus precios
        public JsonResult listarPrecios()
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();

            var listarPrecios = bdsql.adpreciosart.Select(p => new
            {
                p.id_preciosart,
                p.id_art,
                p.co_art,
                p.co_precios,
                p.desde,
                p.hasta,
                p.cod_almacen,
                p.co_alma,
                p.monto,
                p.montoadi1,
                p.montoadi2,
                p.montoadi3,
                p.montoadi4,
                p.montoadi5,
                p.precioOm,
                p.importado_web,
                p.importado_pro


            }).ToList();
            return Json(listarPrecios, JsonRequestBehavior.AllowGet);
        }
        // Articulos con su imagen
        public JsonResult listarimagenesart()
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();
            var listarimagenesart = bdsql.Adimg_art.Select(p => new
            {
                p.id_imgart,
                p.id_art,
                p.co_art,
                p.tip,
                p.imagen_des,
                p.picture,
                p.importado_web,
                p.importado_pro

            }).ToList();

            return Json(listarimagenesart, JsonRequestBehavior.AllowGet);
        }
        /*
        public JsonResult listarartweb()
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();

            var listarartweb = (from stock in bdsql.StockAlma
                                join alma in bdsql.AdAlmacen
                                on stock.cod_almacen equals alma.cod_almacen
                                join Art in bdsql.AdArticulo
                                on stock.id_art equals Art.id_art
                                join precio in bdsql.adpreciosart
                                on Art.id_art equals precio.id_art
                                join img in bdsql.Adimg_art
                                on Art.id_art equals img.id_art
                                select new
                                {
                                    idproducto = Art.id_art,
                                    codigoproducto = Art.co_art,
                                    descripcionproducto = Art.art_des,
                                    adreferencia = Art.referencia,
                                    unidad = Art.cod_unidad,
                                    idprecio = precio.id_preciosart,
                                    codigoprecioprofit = precio.co_precios,
                                    pdesde = ((DateTime) precio.desde).ToShortDateString(),
                                    phasta = ((DateTime) precio.hasta).ToShortDateString(),
                                    montoprecio = precio.monto,
                                    precio1 = precio.montoadi1,
                                    precio2 = precio.montoadi2,
                                    precio3 = precio.montoadi3,
                                    precio4 = precio.montoadi4,
                                    precio5 = precio.montoadi5,
                                    precioOM = precio.precioOm,
                                    idimagen = img.id_imgart,
                                    adtip = img.tip,
                                    nombreimagen = img.imagen_des,
                                    ruta = img.picture,
                                    codigoA = alma.cod_almacen,
                                    almacenprofit = alma.co_alma,
                                    desalma = alma.des_alamacen,
                                    codigoartprof = stock.co_art,
                                    tipostock = stock.tipo,
                                    cantidades = stock.stock,
                                    paginaweb = stock.importado_web
                                }).ToList();
            return Json(listarartweb, JsonRequestBehavior.AllowGet);

        }
        */
        public JsonResult listarartweb()
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();
            var iva = 16;
            var listarartweb = (from stock in bdsql.StockAlma
                                join alma in bdsql.AdAlmacen
                                on stock.cod_almacen equals alma.cod_almacen
                                join Art in bdsql.AdArticulo
                                on stock.id_art equals Art.id_art
                                join precio in bdsql.adpreciosart
                                on Art.id_art equals precio.id_art
                                join img in bdsql.Adimg_art
                                on Art.id_art equals img.id_art
                               
                                select new
                                {
                                    idproducto = Art.id_art,
                                    codigoproducto = Art.co_art,
                                    descripcionproducto = Art.art_des,
                                    adreferencia = Art.referencia,
                                    unidad = Art.cod_unidad,
                                    tipoimput = Art.tipo_imp,
                                    idprecio = precio.id_preciosart,
                                    codigoprecioprofit = precio.co_precios,
                                    pdesde = precio.desde,
                                    phasta = precio.hasta,
                                    //precio en bs
                                    montoprecio = precio.monto,
                                    //Precio en $$
                                    // no modificar estas estructuras
                                    precio1 = precio.montoadi1,
                                    precio2 = precio.montoadi2,
                                    precio3 = precio.montoadi3,
                                    precio4 = precio.montoadi4,
                                    precio5 = precio.montoadi5,
                                    precioOM = precio.precioOm,
                                    montoiva = precio.monto * iva/100,
                                    porcentaje = iva,
                                    idimagen = img.id_imgart,
                                    adtip = img.tip,
                                    nombreimagen = img.imagen_des,
                                    ruta = img.picture,
                                    codi_almacen = alma.cod_almacen,
                                    almacenprofit = alma.co_alma,
                                    desalma = alma.des_alamacen,
                                    codigoartprof = stock.co_art,
                                    tipostock = stock.tipo,
                                    cantidades = stock.stock,
                                    paginaweb = stock.importado_web
                                }).ToList();
            return Json(listarartweb, JsonRequestBehavior.AllowGet);

        }


        public JsonResult listarartwebDisponibles(string disponible)
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();

            var listarartweb =  (from stock in bdsql.StockAlma
                                join alma in bdsql.AdAlmacen
                                on stock.cod_almacen equals alma.cod_almacen
                                join Art in bdsql.AdArticulo
                                on stock.id_art equals Art.id_art
                                join precio in bdsql.adpreciosart
                                on Art.id_art equals precio.id_art
                                join img in bdsql.Adimg_art
                                on Art.id_art equals img.id_art
                                where stock.tipo.Equals(disponible)
                                select new
                                {
                                    idproducto = Art.id_art,
                                    codigoproducto = Art.co_art,
                                    descripcionproducto = Art.art_des,
                                    adreferencia = Art.referencia,
                                    unidad = Art.cod_unidad,
                                    idprecio = precio.id_preciosart,
                                    codigoprecioprofit = precio.co_precios,
                                    pdesde = precio.desde,
                                    phasta = precio.hasta,
                                    montoprecio = precio.monto,
                                    precio1 = precio.montoadi1,
                                    precio2 = precio.montoadi2,
                                    precio3 = precio.montoadi3,
                                    precio4 = precio.montoadi4,
                                    precio5 = precio.montoadi5,
                                    precioOM = precio.precioOm,
                                    idimagen = img.id_imgart,
                                    adtip = img.tip,
                                    nombreimagen = img.imagen_des,
                                    ruta = img.picture,
                                    cod_almacen = alma.cod_almacen,
                                    almacenprofit = alma.co_alma,
                                    desalma = alma.des_alamacen,
                                    codigoartprof = stock.co_art,
                                    tipostock = stock.tipo,
                                    cantidades = stock.stock,
                                    paginaweb = stock.importado_web
                                }).ToList();
            return Json(listarartweb, JsonRequestBehavior.AllowGet);

        }
        //solo cotizacion disponible
        public JsonResult listarartwebDisponibleacoti(string disponible)
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();

            var listarartweb = (from stock in bdsql.StockAlma
                                join alma in bdsql.AdAlmacen
                                on stock.cod_almacen equals alma.cod_almacen
                                join Art in bdsql.AdArticulo
                                on stock.id_art equals Art.id_art
                                join precio in bdsql.adpreciosart
                                on Art.id_art equals precio.id_art
                                join img in bdsql.Adimg_art
                                on Art.id_art equals img.id_art
                                where stock.tipo.Equals(disponible)
                                select new
                                {
                                    idproducto = Art.id_art,
                                    codigoproducto = Art.co_art,
                                    descripcionproducto = Art.art_des,
                                    unidad = Art.cod_unidad,
                                    idprecio = precio.id_preciosart,
                                    codigoprecioprofit = precio.co_precios,
                                    montoprecio = precio.monto,
                                    precio1 = precio.montoadi1,
                                    precio2 = precio.montoadi2,
                                    precioOM = precio.precioOm,
                                    adtip = img.tip,
                                    nombreimagen = img.imagen_des,
                                    ruta = img.picture,
                                    almacenprofit = alma.co_alma,
                                    desalma = alma.des_alamacen,
                                    codigoartprof = stock.co_art,
                                    tipostock = stock.tipo,
                                    cantidades = stock.stock,
                                    paginaweb = stock.importado_web
                                }).ToList();
            return Json(listarartweb, JsonRequestBehavior.AllowGet);

        }

    }
}