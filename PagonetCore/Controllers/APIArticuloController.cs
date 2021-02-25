﻿using System;
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
        public IQueryable<AdArticulo> GetArticulos()
        {
            return db.Articulos;
        }

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
                        montoiva = precio.monto * (IVA / 100),
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

        // GET: api/APIArticulo/5
        [ResponseType(typeof(AdArticulo))]
        public IHttpActionResult GetAdArticulo(int id)
        {
            AdArticulo adArticulo = db.Articulos.Find(id);
            if (adArticulo == null)
            {
                return NotFound();
            }

            return Ok(adArticulo);
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