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
    public class APIIngresoController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APIIngreso
        public IQueryable<AdIngreso> GetIngresos()
        {
            return db.Ingresos;
        }

        // GET: api/APIIngreso/5
        [ResponseType(typeof(AdIngreso))]
        public IHttpActionResult GetAdIngreso(int id)
        {
            AdIngreso adIngreso = db.Ingresos.Find(id);
            if (adIngreso == null)
            {
                return NotFound();
            }

            return Ok(adIngreso);
        }

        // PUT: api/APIIngreso/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdIngreso(int id, AdIngreso adIngreso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adIngreso.id)
            {
                return BadRequest();
            }

            db.Entry(adIngreso).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdIngresoExists(id))
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

        // POST: api/APIIngreso
        [ResponseType(typeof(AdIngreso))]
        public IHttpActionResult PostAdIngreso(AdIngreso adIngreso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ingresos.Add(adIngreso);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adIngreso.id }, adIngreso);
        }

        // DELETE: api/APIIngreso/5
        [ResponseType(typeof(AdIngreso))]
        public IHttpActionResult DeleteAdIngreso(int id)
        {
            AdIngreso adIngreso = db.Ingresos.Find(id);
            if (adIngreso == null)
            {
                return NotFound();
            }

            db.Ingresos.Remove(adIngreso);
            db.SaveChanges();

            return Ok(adIngreso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdIngresoExists(int id)
        {
            return db.Ingresos.Count(e => e.id == id) > 0;
        }
    }
}