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
    public class APIRenglonCotizacionController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APIRenglonCotizacion
        // GET: cotizacion/listarRenglones
        [Route("cotizacion/listarRenglones")]
        public IQueryable<AdCotizacionreg> GetRenglonesCotizacion()
        {
            return db.RenglonesCotizacion;
        }

        // GET: api/APIRenglonCotizacion/5
        [Route("cotizacion/listarRenglonesid/{id:int:min(1)}")]
        [ResponseType(typeof(AdCotizacionreg))]
        public IHttpActionResult GetAdCotizacionreg(int id)
        {
            AdCotizacionreg adCotizacionreg = db.RenglonesCotizacion.Find(id);
            if (adCotizacionreg == null)
            {
                return NotFound();
            }

            return Ok(adCotizacionreg);
        }

        // PUT: api/APIRenglonCotizacion/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdCotizacionreg(int id, AdCotizacionreg adCotizacionreg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adCotizacionreg.id_doc_num)
            {
                return BadRequest();
            }

            db.Entry(adCotizacionreg).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdCotizacionregExists(id))
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

        // POST: api/APIRenglonCotizacion
        [Route("api/APIRenglonCotizacion", Name = "CrearRenglonCotizacionNuevaApi")]
        [Route("cotizacion/guardarDatosreng")]
        [ResponseType(typeof(AdCotizacionreg))]
        public IHttpActionResult PostAdCotizacionreg(AdCotizacionreg adCotizacionreg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RenglonesCotizacion.Add(adCotizacionreg);
            db.SaveChanges();

            string nombreRuta = "CrearRenglonCotizacionNuevaApi";

            if (string.Compare(Request.RequestUri.AbsolutePath, "/cotizacion/guardarDatosreng") == 0)
            {
                nombreRuta = "CrearRenglonCotizacion";
            }

            return CreatedAtRoute(nombreRuta, new { id = adCotizacionreg.id_doc_num }, adCotizacionreg);
        }

        // DELETE: api/APIRenglonCotizacion/5
        [ResponseType(typeof(AdCotizacionreg))]
        public IHttpActionResult DeleteAdCotizacionreg(int id)
        {
            AdCotizacionreg adCotizacionreg = db.RenglonesCotizacion.Find(id);
            if (adCotizacionreg == null)
            {
                return NotFound();
            }

            db.RenglonesCotizacion.Remove(adCotizacionreg);
            db.SaveChanges();

            return Ok(adCotizacionreg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdCotizacionregExists(int id)
        {
            return db.RenglonesCotizacion.Count(e => e.id_doc_num == id) > 0;
        }
    }
}