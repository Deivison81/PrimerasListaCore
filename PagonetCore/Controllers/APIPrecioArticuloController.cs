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
    public class APIPrecioArticuloController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APIPrecioArticulo
        public IQueryable<adpreciosart> GetPreciosArticulo()
        {
            return db.PreciosArticulo;
        }

        // GET: api/APIPrecioArticulo/5
        [ResponseType(typeof(adpreciosart))]
        public IHttpActionResult Getadpreciosart(int id)
        {
            adpreciosart adpreciosart = db.PreciosArticulo.Find(id);
            if (adpreciosart == null)
            {
                return NotFound();
            }

            return Ok(adpreciosart);
        }

        // PUT: api/APIPrecioArticulo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putadpreciosart(int id, adpreciosart adpreciosart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adpreciosart.id_preciosart)
            {
                return BadRequest();
            }

            db.Entry(adpreciosart).State = EntityState.Modified;

            try
            {
                decimal tasaDelDia = db.Tasas
                    .Where(t => t.fecha.Value.CompareTo(adpreciosart.desde.Value) <= 0)
                    .Select(t => (decimal)t.tasa_v)
                    .ToList()
                    .LastOrDefault();

                // TODO: Validar en el modelo.
                if (adpreciosart.precioOm.Equals("1"))
                {
                    adpreciosart.tasa_v = tasaDelDia;
                    adpreciosart.montoadi1 = (tasaDelDia != 0) ? (adpreciosart.monto / tasaDelDia) : 0;
                }
                else if (adpreciosart.precioOm.Equals("0"))
                {
                    adpreciosart.tasa_v = null;
                }
                else
                {
                    return BadRequest("precioOm debe ser un string con 0 o 1.");
                }

                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!adpreciosartExists(id))
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

        // POST: api/APIPrecioArticulo
        [ResponseType(typeof(adpreciosart))]
        public IHttpActionResult Postadpreciosart(adpreciosart adpreciosart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            decimal tasaDelDia = db.Tasas
                .Where(t => t.fecha.Value.CompareTo(adpreciosart.desde.Value) <= 0)
                .Select(t => (decimal)t.tasa_v)
                .ToList()
                .LastOrDefault();

            // TODO: Validar en el modelo.
            if(adpreciosart.precioOm.Equals("1"))
            {
                adpreciosart.tasa_v = tasaDelDia;
                adpreciosart.montoadi1 = (tasaDelDia != 0) ? (adpreciosart.monto / tasaDelDia) : 0;
            } else if(adpreciosart.precioOm.Equals("0"))
            {
                adpreciosart.tasa_v = null;
            } else
            {
                return BadRequest("precioOm debe ser un string con 0 o 1.");
            }

            db.PreciosArticulo.Add(adpreciosart);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adpreciosart.id_preciosart }, adpreciosart);
        }

        // DELETE: api/APIPrecioArticulo/5
        [ResponseType(typeof(adpreciosart))]
        public IHttpActionResult Deleteadpreciosart(int id)
        {
            adpreciosart adpreciosart = db.PreciosArticulo.Find(id);
            if (adpreciosart == null)
            {
                return NotFound();
            }

            db.PreciosArticulo.Remove(adpreciosart);
            db.SaveChanges();

            return Ok(adpreciosart);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool adpreciosartExists(int id)
        {
            return db.PreciosArticulo.Count(e => e.id_preciosart == id) > 0;
        }
    }
}