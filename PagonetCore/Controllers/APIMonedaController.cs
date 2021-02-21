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
    public class APIMonedaController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APIMoneda
        public IQueryable<AdMoneda> GetMonedas()
        {
            return db.Monedas;
        }

        // GET: api/APIMoneda/5
        [ResponseType(typeof(AdMoneda))]
        public IHttpActionResult GetAdMoneda(int id)
        {
            AdMoneda adMoneda = db.Monedas.Find(id);
            if (adMoneda == null)
            {
                return NotFound();
            }

            return Ok(adMoneda);
        }

        // PUT: api/APIMoneda/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdMoneda(int id, AdMoneda adMoneda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adMoneda.id_moneda)
            {
                return BadRequest();
            }

            db.Entry(adMoneda).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdMonedaExists(id))
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

        // POST: api/APIMoneda
        [ResponseType(typeof(AdMoneda))]
        public IHttpActionResult PostAdMoneda(AdMoneda adMoneda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Monedas.Add(adMoneda);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AdMonedaExists(adMoneda.id_moneda))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = adMoneda.id_moneda }, adMoneda);
        }

        // DELETE: api/APIMoneda/5
        [ResponseType(typeof(AdMoneda))]
        public IHttpActionResult DeleteAdMoneda(int id)
        {
            AdMoneda adMoneda = db.Monedas.Find(id);
            if (adMoneda == null)
            {
                return NotFound();
            }

            db.Monedas.Remove(adMoneda);
            db.SaveChanges();

            return Ok(adMoneda);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdMonedaExists(int id)
        {
            return db.Monedas.Count(e => e.id_moneda == id) > 0;
        }
    }
}