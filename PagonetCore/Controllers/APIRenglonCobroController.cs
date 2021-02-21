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
    public class APIRenglonCobroController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APIRenglonCobro
        public IQueryable<AdRenglonesCobro> GetRenglonesCobro()
        {
            return db.RenglonesCobro;
        }

        // GET: api/APIRenglonCobro/5
        [ResponseType(typeof(AdRenglonesCobro))]
        public IHttpActionResult GetAdRenglonesCobro(int id)
        {
            AdRenglonesCobro adRenglonesCobro = db.RenglonesCobro.Find(id);
            if (adRenglonesCobro == null)
            {
                return NotFound();
            }

            return Ok(adRenglonesCobro);
        }

        // PUT: api/APIRenglonCobro/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdRenglonesCobro(int id, AdRenglonesCobro adRenglonesCobro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adRenglonesCobro.idrencob)
            {
                return BadRequest();
            }

            db.Entry(adRenglonesCobro).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdRenglonesCobroExists(id))
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

        // Nota: Este método retorna el número de registros afectados por la petición.
        // POST: cobros/renglones
        [HttpPost]
        [Route("cobros/renglones")]
        [ResponseType(typeof(int))]
        public int CrearRenglonCobro(AdRenglonesCobro renglonCobro)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }

            db.RenglonesCobro.Add(renglonCobro);
            db.SaveChanges();

            return 1;
        }

        // POST: api/APIRenglonCobro
        [ResponseType(typeof(AdRenglonesCobro))]
        public IHttpActionResult PostAdRenglonesCobro(AdRenglonesCobro adRenglonesCobro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RenglonesCobro.Add(adRenglonesCobro);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AdRenglonesCobroExists(adRenglonesCobro.idrencob))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = adRenglonesCobro.idrencob }, adRenglonesCobro);
        }

        // DELETE: api/APIRenglonCobro/5
        [ResponseType(typeof(AdRenglonesCobro))]
        public IHttpActionResult DeleteAdRenglonesCobro(int id)
        {
            AdRenglonesCobro adRenglonesCobro = db.RenglonesCobro.Find(id);
            if (adRenglonesCobro == null)
            {
                return NotFound();
            }

            db.RenglonesCobro.Remove(adRenglonesCobro);
            db.SaveChanges();

            return Ok(adRenglonesCobro);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdRenglonesCobroExists(int id)
        {
            return db.RenglonesCobro.Count(e => e.idrencob == id) > 0;
        }
    }
}