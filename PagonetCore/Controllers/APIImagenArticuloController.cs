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
    public class APIImagenArticuloController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APIImagenArticulo
        public IQueryable<Adimg_art> GetImagenesArticulo()
        {
            return db.ImagenesArticulo;
        }

        // GET: api/APIImagenArticulo/5
        [ResponseType(typeof(Adimg_art))]
        public IHttpActionResult GetAdimg_art(int id)
        {
            Adimg_art adimg_art = db.ImagenesArticulo.Find(id);
            if (adimg_art == null)
            {
                return NotFound();
            }

            return Ok(adimg_art);
        }

        // PUT: api/APIImagenArticulo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdimg_art(int id, Adimg_art adimg_art)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adimg_art.id_imgart)
            {
                return BadRequest();
            }

            db.Entry(adimg_art).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Adimg_artExists(id))
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

        // POST: api/APIImagenArticulo
        [ResponseType(typeof(Adimg_art))]
        public IHttpActionResult PostAdimg_art(Adimg_art adimg_art)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ImagenesArticulo.Add(adimg_art);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adimg_art.id_imgart }, adimg_art);
        }

        // DELETE: api/APIImagenArticulo/5
        [ResponseType(typeof(Adimg_art))]
        public IHttpActionResult DeleteAdimg_art(int id)
        {
            Adimg_art adimg_art = db.ImagenesArticulo.Find(id);
            if (adimg_art == null)
            {
                return NotFound();
            }

            db.ImagenesArticulo.Remove(adimg_art);
            db.SaveChanges();

            return Ok(adimg_art);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Adimg_artExists(int id)
        {
            return db.ImagenesArticulo.Count(e => e.id_imgart == id) > 0;
        }
    }
}