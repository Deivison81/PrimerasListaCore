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
    public class APIMovimientoBancoController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APIMovimientoBanco
        public IQueryable<AdMovimientoBanco> GetMovimientosBancos()
        {
            return db.MovimientosBancos;
        }

        // GET: api/APIMovimientoBanco/5
        [ResponseType(typeof(AdMovimientoBanco))]
        public IHttpActionResult GetAdMovimientoBanco(string id)
        {
            AdMovimientoBanco adMovimientoBanco = db.MovimientosBancos.Find(id);
            if (adMovimientoBanco == null)
            {
                return NotFound();
            }

            return Ok(adMovimientoBanco);
        }

        // PUT: api/APIMovimientoBanco/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdMovimientoBanco(string id, AdMovimientoBanco adMovimientoBanco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adMovimientoBanco.mov_num)
            {
                return BadRequest();
            }

            db.Entry(adMovimientoBanco).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdMovimientoBancoExists(id))
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

        // POST: api/APIMovimientoBanco
        [ResponseType(typeof(AdMovimientoBanco))]
        public IHttpActionResult PostAdMovimientoBanco(AdMovimientoBanco adMovimientoBanco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MovimientosBancos.Add(adMovimientoBanco);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AdMovimientoBancoExists(adMovimientoBanco.mov_num))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = adMovimientoBanco.mov_num }, adMovimientoBanco);
        }

        // DELETE: api/APIMovimientoBanco/5
        [ResponseType(typeof(AdMovimientoBanco))]
        public IHttpActionResult DeleteAdMovimientoBanco(string id)
        {
            AdMovimientoBanco adMovimientoBanco = db.MovimientosBancos.Find(id);
            if (adMovimientoBanco == null)
            {
                return NotFound();
            }

            db.MovimientosBancos.Remove(adMovimientoBanco);
            db.SaveChanges();

            return Ok(adMovimientoBanco);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdMovimientoBancoExists(string id)
        {
            return db.MovimientosBancos.Count(e => e.mov_num == id) > 0;
        }
    }
}