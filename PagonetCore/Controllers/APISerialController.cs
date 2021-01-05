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
    public class APISerialController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APISerial
        public IQueryable<AdSerial> GetSeriales()
        {
            return db.Seriales;
        }

        // GET: api/APISerial/5
        [ResponseType(typeof(AdSerial))]
        public IHttpActionResult GetAdSerial(int id)
        {
            AdSerial adSerial = db.Seriales.Find(id);
            if (adSerial == null)
            {
                return NotFound();
            }

            return Ok(adSerial);
        }

        // PUT: api/APISerial/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdSerial(int id, AdSerial adSerial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adSerial.reng_num)
            {
                return BadRequest();
            }

            db.Entry(adSerial).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdSerialExists(id))
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

        // POST: api/APISerial
        [ResponseType(typeof(AdSerial))]
        public IHttpActionResult PostAdSerial(AdSerial adSerial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Seriales.Add(adSerial);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AdSerialExists(adSerial.reng_num))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = adSerial.reng_num }, adSerial);
        }

        // DELETE: api/APISerial/5
        [ResponseType(typeof(AdSerial))]
        public IHttpActionResult DeleteAdSerial(int id)
        {
            AdSerial adSerial = db.Seriales.Find(id);
            if (adSerial == null)
            {
                return NotFound();
            }

            db.Seriales.Remove(adSerial);
            db.SaveChanges();

            return Ok(adSerial);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdSerialExists(int id)
        {
            return db.Seriales.Count(e => e.reng_num == id) > 0;
        }
    }
}