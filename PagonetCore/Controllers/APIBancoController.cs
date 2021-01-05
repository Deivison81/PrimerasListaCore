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
    public class APIBancoController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APIBanco
        public IQueryable<AdBanco> GetBancos()
        {
            return db.Bancos;
        }

        // GET: api/APIBanco/5
        [ResponseType(typeof(AdBanco))]
        public IHttpActionResult GetAdBanco(int id)
        {
            AdBanco adBanco = db.Bancos.Find(id);
            if (adBanco == null)
            {
                return NotFound();
            }

            return Ok(adBanco);
        }

        // PUT: api/APIBanco/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdBanco(int id, AdBanco adBanco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adBanco.id_banco)
            {
                return BadRequest();
            }

            db.Entry(adBanco).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdBancoExists(id))
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

        // POST: api/APIBanco
        [ResponseType(typeof(AdBanco))]
        public IHttpActionResult PostAdBanco(AdBanco adBanco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bancos.Add(adBanco);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AdBancoExists(adBanco.id_banco))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = adBanco.id_banco }, adBanco);
        }

        // DELETE: api/APIBanco/5
        [ResponseType(typeof(AdBanco))]
        public IHttpActionResult DeleteAdBanco(int id)
        {
            AdBanco adBanco = db.Bancos.Find(id);
            if (adBanco == null)
            {
                return NotFound();
            }

            db.Bancos.Remove(adBanco);
            db.SaveChanges();

            return Ok(adBanco);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdBancoExists(int id)
        {
            return db.Bancos.Count(e => e.id_banco == id) > 0;
        }
    }
}