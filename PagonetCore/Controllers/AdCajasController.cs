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
    public class AdCajasController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/AdCajas
        public IQueryable<AdCajas> GetAdCajas()
        {
            return db.AdCajas;
        }

        // GET: api/AdCajas/5
        [ResponseType(typeof(AdCajas))]
        public IHttpActionResult GetAdCajas(int id)
        {
            AdCajas adCajas = db.AdCajas.Find(id);
            if (adCajas == null)
            {
                return NotFound();
            }

            return Ok(adCajas);
        }

        // PUT: api/AdCajas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdCajas(int id, AdCajas adCajas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adCajas.id_cajas)
            {
                return BadRequest();
            }

            db.Entry(adCajas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdCajasExists(id))
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

        // POST: api/AdCajas
        [ResponseType(typeof(AdCajas))]
        public IHttpActionResult PostAdCajas(AdCajas adCajas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AdCajas.Add(adCajas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adCajas.id_cajas }, adCajas);
        }

        // DELETE: api/AdCajas/5
        [ResponseType(typeof(AdCajas))]
        public IHttpActionResult DeleteAdCajas(int id)
        {
            AdCajas adCajas = db.AdCajas.Find(id);
            if (adCajas == null)
            {
                return NotFound();
            }

            db.AdCajas.Remove(adCajas);
            db.SaveChanges();

            return Ok(adCajas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdCajasExists(int id)
        {
            return db.AdCajas.Count(e => e.id_cajas == id) > 0;
        }
    }
}