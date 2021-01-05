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
    public class APIArticuloController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APIArticulo
        public IQueryable<AdArticulo> GetArticulos()
        {
            return db.Articulos;
        }

        // GET: api/APIArticulo/5
        [ResponseType(typeof(AdArticulo))]
        public IHttpActionResult GetAdArticulo(int id)
        {
            AdArticulo adArticulo = db.Articulos.Find(id);
            if (adArticulo == null)
            {
                return NotFound();
            }

            return Ok(adArticulo);
        }

        // PUT: api/APIArticulo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdArticulo(int id, AdArticulo adArticulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adArticulo.id_art)
            {
                return BadRequest();
            }

            db.Entry(adArticulo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdArticuloExists(id))
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

        // POST: api/APIArticulo
        [ResponseType(typeof(AdArticulo))]
        public IHttpActionResult PostAdArticulo(AdArticulo adArticulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Articulos.Add(adArticulo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adArticulo.id_art }, adArticulo);
        }

        // DELETE: api/APIArticulo/5
        [ResponseType(typeof(AdArticulo))]
        public IHttpActionResult DeleteAdArticulo(int id)
        {
            AdArticulo adArticulo = db.Articulos.Find(id);
            if (adArticulo == null)
            {
                return NotFound();
            }

            db.Articulos.Remove(adArticulo);
            db.SaveChanges();

            return Ok(adArticulo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdArticuloExists(int id)
        {
            return db.Articulos.Count(e => e.id_art == id) > 0;
        }
    }
}