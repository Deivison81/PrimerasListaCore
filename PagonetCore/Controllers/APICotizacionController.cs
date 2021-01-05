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
    public class APICotizacionController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APICotizacion
        public IQueryable<Adcotizacion> GetCotizaciones()
        {
            return db.Cotizaciones;
        }

        // GET: api/APICotizacion/5
        [ResponseType(typeof(Adcotizacion))]
        public IHttpActionResult GetAdcotizacion(int id)
        {
            Adcotizacion adcotizacion = db.Cotizaciones.Find(id);
            if (adcotizacion == null)
            {
                return NotFound();
            }

            return Ok(adcotizacion);
        }

        // PUT: api/APICotizacion/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdcotizacion(int id, Adcotizacion adcotizacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adcotizacion.id_doc_num)
            {
                return BadRequest();
            }

            db.Entry(adcotizacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdcotizacionExists(id))
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

        // POST: api/APICotizacion
        [ResponseType(typeof(Adcotizacion))]
        public IHttpActionResult PostAdcotizacion(Adcotizacion adcotizacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cotizaciones.Add(adcotizacion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adcotizacion.id_doc_num }, adcotizacion);
        }

        // DELETE: api/APICotizacion/5
        [ResponseType(typeof(Adcotizacion))]
        public IHttpActionResult DeleteAdcotizacion(int id)
        {
            Adcotizacion adcotizacion = db.Cotizaciones.Find(id);
            if (adcotizacion == null)
            {
                return NotFound();
            }

            db.Cotizaciones.Remove(adcotizacion);
            db.SaveChanges();

            return Ok(adcotizacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdcotizacionExists(int id)
        {
            return db.Cotizaciones.Count(e => e.id_doc_num == id) > 0;
        }
    }
}