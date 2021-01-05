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
    public class APICondicionDePagoController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APICondicionDePago
        public IQueryable<Adcondiciondepago> GetCondicionesDePago()
        {
            return db.CondicionesDePago;
        }

        // GET: api/APICondicionDePago/5
        [ResponseType(typeof(Adcondiciondepago))]
        public IHttpActionResult GetAdcondiciondepago(int id)
        {
            Adcondiciondepago adcondiciondepago = db.CondicionesDePago.Find(id);
            if (adcondiciondepago == null)
            {
                return NotFound();
            }

            return Ok(adcondiciondepago);
        }

        // PUT: api/APICondicionDePago/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdcondiciondepago(int id, Adcondiciondepago adcondiciondepago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adcondiciondepago.id_condicion)
            {
                return BadRequest();
            }

            db.Entry(adcondiciondepago).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdcondiciondepagoExists(id))
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

        // POST: api/APICondicionDePago
        [ResponseType(typeof(Adcondiciondepago))]
        public IHttpActionResult PostAdcondiciondepago(Adcondiciondepago adcondiciondepago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CondicionesDePago.Add(adcondiciondepago);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adcondiciondepago.id_condicion }, adcondiciondepago);
        }

        // DELETE: api/APICondicionDePago/5
        [ResponseType(typeof(Adcondiciondepago))]
        public IHttpActionResult DeleteAdcondiciondepago(int id)
        {
            Adcondiciondepago adcondiciondepago = db.CondicionesDePago.Find(id);
            if (adcondiciondepago == null)
            {
                return NotFound();
            }

            db.CondicionesDePago.Remove(adcondiciondepago);
            db.SaveChanges();

            return Ok(adcondiciondepago);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdcondiciondepagoExists(int id)
        {
            return db.CondicionesDePago.Count(e => e.id_condicion == id) > 0;
        }
    }
}