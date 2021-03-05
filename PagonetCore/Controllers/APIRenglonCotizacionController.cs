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
        public IHttpActionResult PutAdCotizacionreg(int id, AdCotizacionreg adCotizacionreg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adCotizacionreg.id_doc_num)
            {
                return BadRequest("id_doc_num no coincide con el ID del parámetro del URL.");
            }

            db.Entry(adCotizacionreg).State = EntityState.Modified;

            try
            {
                DateTime fechaEmisionCotizacion = db.Cotizaciones
                .Where(c => c.doc_num == adCotizacionreg.doc_num)
                .Select(c => (DateTime)c.fec_emis)
                .FirstOrDefault();

                decimal baseNeta = 0, valorIva = 0, totalMontoImpuesto = 0, totalMontoNeto = 0;

                decimal tasaDelDia = db.Tasas
                    .Where(t => t.fecha.Value.CompareTo(fechaEmisionCotizacion) <= 0)
                    .Select(t => (decimal)t.tasa_v)
                    .ToList()
                    .LastOrDefault();

                baseNeta = (decimal)(adCotizacionreg.total_art * adCotizacionreg.prec_vta);
                valorIva = (decimal)(adCotizacionreg.porc_imp);
                adCotizacionreg.monto_imp = baseNeta * (valorIva / 100);
                adCotizacionreg.reng_neto = baseNeta + adCotizacionreg.monto_imp;
                totalMontoImpuesto += (decimal)adCotizacionreg.monto_imp;
                totalMontoNeto += (decimal)adCotizacionreg.reng_neto;
                adCotizacionreg.tasa_v = tasaDelDia;
                adCotizacionreg.prec_vta_om = (tasaDelDia != 0) ? (adCotizacionreg.prec_vta / tasaDelDia) : null;

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

        // Nota: Este método retorna el número de registros afectados por la petición.
        // POST: cotizacion/guardarDatosreng
        [HttpPost]
        [Route("cotizacion/guardarDatosreng")]
        [ResponseType(typeof(int))]
        public int CrearRenglonCotizacion(AdCotizacionreg adCotizacionreg)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }

            DateTime fechaEmisionCotizacion = db.Cotizaciones
                .Where(c => c.doc_num == adCotizacionreg.doc_num)
                .Select(c => (DateTime)c.fec_emis)
                .FirstOrDefault();

            decimal baseNeta = 0, valorIva = 0, totalMontoImpuesto = 0, totalMontoNeto = 0;

            decimal tasaDelDia = db.Tasas
                .Where(t => t.fecha.Value.CompareTo(fechaEmisionCotizacion) <= 0)
                .Select(t => (decimal)t.tasa_v)
                .ToList()
                .LastOrDefault();

            baseNeta = (decimal)(adCotizacionreg.total_art * adCotizacionreg.prec_vta);
            valorIva = (decimal)(adCotizacionreg.porc_imp);
            adCotizacionreg.monto_imp = baseNeta * (valorIva / 100);
            adCotizacionreg.reng_neto = baseNeta + adCotizacionreg.monto_imp;
            totalMontoImpuesto += (decimal)adCotizacionreg.monto_imp;
            totalMontoNeto += (decimal)adCotizacionreg.reng_neto;
            adCotizacionreg.tasa_v = tasaDelDia;
            adCotizacionreg.prec_vta_om = (tasaDelDia != 0) ? (adCotizacionreg.prec_vta / tasaDelDia) : null;

            db.RenglonesCotizacion.Add(adCotizacionreg);
            db.SaveChanges();

            return adCotizacionreg.reng_num;
        }

        // POST: api/APIRenglonCotizacion
        [ResponseType(typeof(AdCotizacionreg))]
        public IHttpActionResult PostAdCotizacionreg(AdCotizacionreg adCotizacionreg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DateTime fechaEmisionCotizacion = db.Cotizaciones
                .Where(c => c.doc_num == adCotizacionreg.doc_num)
                .Select(c => (DateTime)c.fec_emis)
                .FirstOrDefault();

            decimal baseNeta = 0, valorIva = 0, totalMontoImpuesto = 0, totalMontoNeto = 0;

            decimal tasaDelDia = db.Tasas
                .Where(t => t.fecha.Value.CompareTo(fechaEmisionCotizacion) <= 0)
                .Select(t => (decimal)t.tasa_v)
                .ToList()
                .LastOrDefault();

            baseNeta = (decimal)(adCotizacionreg.total_art * adCotizacionreg.prec_vta);
            valorIva = (decimal)(adCotizacionreg.porc_imp);
            adCotizacionreg.monto_imp = baseNeta * (valorIva / 100);
            adCotizacionreg.reng_neto = baseNeta + adCotizacionreg.monto_imp;
            totalMontoImpuesto += (decimal)adCotizacionreg.monto_imp;
            totalMontoNeto += (decimal)adCotizacionreg.reng_neto;
            adCotizacionreg.tasa_v = tasaDelDia;
            adCotizacionreg.prec_vta_om = (tasaDelDia != 0) ? (adCotizacionreg.prec_vta / tasaDelDia) : null;

            db.RenglonesCotizacion.Add(adCotizacionreg);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adCotizacionreg.id_doc_num }, adCotizacionreg);
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