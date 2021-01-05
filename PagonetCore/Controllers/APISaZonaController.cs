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
    public class APISaZonaController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APISaZona
        public IQueryable<sazona> GetSazonas()
        {
            return db.Sazonas;
        }

        // GET: api/APISaZona/5
        [ResponseType(typeof(sazona))]
        public IHttpActionResult Getsazona(string id)
        {
            sazona sazona = db.Sazonas.Find(id);
            if (sazona == null)
            {
                return NotFound();
            }

            return Ok(sazona);
        }

        // PUT: api/APISaZona/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putsazona(string id, sazona sazona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sazona.co_zon)
            {
                return BadRequest();
            }

            db.Entry(sazona).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!sazonaExists(id))
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

        // POST: api/APISaZona
        [ResponseType(typeof(sazona))]
        public IHttpActionResult Postsazona(sazona sazona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sazonas.Add(sazona);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (sazonaExists(sazona.co_zon))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sazona.co_zon }, sazona);
        }

        // DELETE: api/APISaZona/5
        [ResponseType(typeof(sazona))]
        public IHttpActionResult Deletesazona(string id)
        {
            sazona sazona = db.Sazonas.Find(id);
            if (sazona == null)
            {
                return NotFound();
            }

            db.Sazonas.Remove(sazona);
            db.SaveChanges();

            return Ok(sazona);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool sazonaExists(string id)
        {
            return db.Sazonas.Count(e => e.co_zon == id) > 0;
        }
    }
}