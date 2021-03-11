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
    public class APITasaController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APITasa
        public IQueryable<AdTasa> GetTasas()
        {
            return db.Tasas;
        }

        // GET: api/APITasa/5
        [ResponseType(typeof(AdTasa))]
        public IHttpActionResult GetAdTasa(int id)
        {
            AdTasa adTasa = db.Tasas.Find(id);
            if (adTasa == null)
            {
                return NotFound();
            }

            return Ok(adTasa);
        }
        // GET: api/APITasa/5
        [ResponseType(typeof(AdTasa))]
        [Route("Tasa/listarTasa/{id:int:min(1)}")]
        public IHttpActionResult GetAdTasaid(int id)
        {
            var listarTasa = db.Tasas.Where(p => p.idmone.Equals(id))
                .Select(p => new
                {
                    p.idmone,
                    p.co_mone,
                    p.fecha,
                    p.tasa_v
                }).ToList(); 
           

            return Ok(listarTasa);
        }
        // GET: api/APITasa/5
        /*[ResponseType(typeof(AdTasa))]
        [Route("Tasa/listarTasamoneda/{codigo:string:min(1)}")]
        public IHttpActionResult GetAdTasacomene(string codigo)
        {
            var listarTasa = db.Tasas.Where(p => p.co_mone.Equals(codigo))
                .Select(p => new
                {
                    p.idmone,
                    p.co_mone,
                    p.fecha,
                    p.tasa_v
                }).ToList();


            return Ok(listarTasa);
        }*/
        // PUT: api/APITasa/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdTasa(int id, AdTasa adTasa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adTasa.idmone)
            {
                return BadRequest();
            }

            db.Entry(adTasa).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdTasaExists(id))
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

        // POST: api/APITasa
        [ResponseType(typeof(AdTasa))]
        public IHttpActionResult PostAdTasa(AdTasa adTasa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tasas.Add(adTasa);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adTasa.idmone }, adTasa);
        }

        // DELETE: api/APITasa/5
        [ResponseType(typeof(AdTasa))]
        public IHttpActionResult DeleteAdTasa(int id)
        {
            AdTasa adTasa = db.Tasas.Find(id);
            if (adTasa == null)
            {
                return NotFound();
            }

            db.Tasas.Remove(adTasa);
            db.SaveChanges();

            return Ok(adTasa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdTasaExists(int id)
        {
            return db.Tasas.Count(e => e.idmone == id) > 0;
        }
    }
}