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
    public class APIStockAlmacenController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APIStockAlmacen
        [Route("Stock/listarStock")]
        public IHttpActionResult GetStockAlmacenes()
        {
            var listarStock = db.StockAlmacenes.Select(p => new
            {
                p.cod_almacen,
                p.co_alma,
                p.id_art,
                p.co_art,
                p.tipo,
                p.stock,
                p.importado_web,
                p.importado_pro
            }).ToList();

            return Ok(listarStock);
        }

        [Route("Stock/listarStocks")]
        public IHttpActionResult GetStockAlmacenesListarStocks(int idalma, int idart)
        {
            var listarStock = db.StockAlmacenes.Where(P => P.cod_almacen.Equals(idalma) && P.id_art.Equals(idart))
                .Select(p => new
                {
                    p.cod_almacen,
                    p.co_alma,
                    p.id_art,
                    p.co_art,
                    p.tipo,
                    p.stock,
                    p.importado_web,
                    p.importado_pro
                }).ToList();

            return Ok(listarStock);
        }

        // GET: api/APIStockAlmacen/5
        [ResponseType(typeof(StockAlma))]
        public IHttpActionResult GetStockAlma(int id)
        {
            StockAlma stockAlma = db.StockAlmacenes.Find(id);
            if (stockAlma == null)
            {
                return NotFound();
            }

            return Ok(stockAlma);
        }

        // PUT: api/APIStockAlmacen/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStockAlma(int id, StockAlma stockAlma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stockAlma.StockAlmacenID)
            {
                return BadRequest();
            }

            db.Entry(stockAlma).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockAlmaExists(id))
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

        // POST: api/APIStockAlmacen
        [ResponseType(typeof(StockAlma))]
        public IHttpActionResult PostStockAlma(StockAlma stockAlma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StockAlmacenes.Add(stockAlma);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = stockAlma.StockAlmacenID }, stockAlma);
        }

        // DELETE: api/APIStockAlmacen/5
        [ResponseType(typeof(StockAlma))]
        public IHttpActionResult DeleteStockAlma(int id)
        {
            StockAlma stockAlma = db.StockAlmacenes.Find(id);
            if (stockAlma == null)
            {
                return NotFound();
            }

            db.StockAlmacenes.Remove(stockAlma);
            db.SaveChanges();

            return Ok(stockAlma);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StockAlmaExists(int id)
        {
            return db.StockAlmacenes.Count(e => e.StockAlmacenID == id) > 0;
        }
    }
}