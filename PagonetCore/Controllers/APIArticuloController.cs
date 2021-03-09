using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PagonetCore.DAL;
using PagonetCore.Models;

namespace PagonetCore.Controllers
{
    public class APIArticuloController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APIArticulo
        [HttpGet]
        [Route("Articulo/listarArticulos")]
        public IHttpActionResult GetArticulos()
        {
            var listarArticulos = db.Articulos.Select(p => new
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

            return Ok(listarArticulos);
        }

        [HttpGet]
        [Route("Articulo/listarartweb")]
        public object GetArticulosConPrecios()
        {
            const int IVA = 16;

            // LINQ de Deivison.
            return (from stock in db.StockAlmacenes
                    join alma in db.Almacenes
                    on stock.cod_almacen equals alma.cod_almacen
                    join Art in db.Articulos
                    on stock.id_art equals Art.id_art
                    join precio in db.PreciosArticulo
                    on Art.id_art equals precio.id_art
                    join img in db.ImagenesArticulo
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
                        montoiva = (precio.monto * IVA) / 100,
                        porcentaje = IVA,
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
        }

        [HttpGet]
        [Route("Articulo/listarartwebDisponibles/{disponible}")]
        public object GetAdArticuloArtWebDisponibles(string disponible)
        {
            return (from stock in db.StockAlmacenes
                    join alma in db.Almacenes
                    on stock.cod_almacen equals alma.cod_almacen
                    join Art in db.Articulos
                    on stock.id_art equals Art.id_art
                    join precio in db.PreciosArticulo
                    on Art.id_art equals precio.id_art
                    join img in db.ImagenesArticulo
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
        }

        [HttpGet]
        [Route("Articulo/listarartwebDisponibleacoti/{disponible}")]
        public object GetAdArticuloArtWebDisponiblesCoti(string disponible)
        {
            return (from stock in db.StockAlmacenes
                    join alma in db.Almacenes
                    on stock.cod_almacen equals alma.cod_almacen
                    join Art in db.Articulos
                    on stock.id_art equals Art.id_art
                    join precio in db.PreciosArticulo
                    on Art.id_art equals precio.id_art
                    join img in db.ImagenesArticulo
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
        }

        // GET: api/APIArticulo/5
        [HttpGet]
        [Route("Articulo/listarArticulo/{id:int:min(1)}")]
        [ResponseType(typeof(AdArticulo))]
        public IHttpActionResult GetAdArticulo(int id)
        {
            var adArticulo = db.Articulos.Where(p => p.id_art.Equals(id))
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

            if (adArticulo == null)
            {
                return NotFound();
            }

            return Ok(adArticulo);
        }

        [HttpGet]
        [Route("Articulo/listarPrecios")]
        public IHttpActionResult GetAdArticuloPrecios()
        {
            var listarPrecios = db.PreciosArticulo.Select(p => new
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

            return Ok(listarPrecios);
        }

        [HttpGet]
        [Route("Articulo/listarimagenesart")]
        public IHttpActionResult GetAdArticuloImagenes()
        {
            var listarimagenesart = db.ImagenesArticulo.Select(p => new
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

            return Ok(listarimagenesart);
        }

        // PUT: api/APIArticulo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdArticulo(int id, AdArticulo adArticulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adArticulo.id_art)
            {
                return BadRequest();
            }

            db.Entry(adArticulo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdArticuloExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/APIArticulo
        [ResponseType(typeof(AdArticulo))]
        public IHttpActionResult PostAdArticulo(AdArticulo adArticulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Articulos.Add(adArticulo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adArticulo.id_art }, adArticulo);
        }

        // DELETE: api/APIArticulo/5
        [ResponseType(typeof(AdArticulo))]
        public IHttpActionResult DeleteAdArticulo(int id)
        {
            AdArticulo adArticulo = db.Articulos.Find(id);
            if (adArticulo == null)
            {
                return NotFound();
            }

            db.Articulos.Remove(adArticulo);
            db.SaveChanges();

            return Ok(adArticulo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdArticuloExists(int id)
        {
            return db.Articulos.Count(e => e.id_art == id) > 0;
        }
    }
}