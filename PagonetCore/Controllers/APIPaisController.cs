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
    public class APIPaisController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APIPais
        [Route("Adpais/listarPais")]
        public IQueryable<Adpais> GetPaises()
        {
            return db.Paises;
        }

        // GET: api/APIPais/5
        [Route("Adpais/listarpais1/{id:int:min(1)}")]
        [ResponseType(typeof(Adpais))]
        public IHttpActionResult GetAdpais(int id)
        {
            Adpais adpais = db.Paises.Find(id);
            if (adpais == null)
            {
                return NotFound();
            }

            return Ok(adpais);
        }

        // PUT: api/APIPais/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdpais(int id, Adpais adpais)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adpais.id_pais)
            {
                return BadRequest();
            }

            db.Entry(adpais).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdpaisExists(id))
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

        // POST: api/APIPais
        [Route("api/APIPais", Name = "CrearPaisNuevaApi")]
        [Route("Adpais/guardarDatos")]
        [ResponseType(typeof(Adpais))]
        public IHttpActionResult PostAdpais(Adpais adpais)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Paises.Add(adpais);
            db.SaveChanges();

            string nombreRuta = "CrearPaisNuevaApi";

            if (string.Compare(Request.RequestUri.AbsolutePath, "/Adpais/guardarDatos") == 0)
            {
                nombreRuta = "CrearPais";
            }

            return CreatedAtRoute(nombreRuta, new { id = adpais.id_pais }, adpais);
        }

        // DELETE: api/APIPais/5
        [ResponseType(typeof(Adpais))]
        public IHttpActionResult DeleteAdpais(int id)
        {
            Adpais adpais = db.Paises.Find(id);
            if (adpais == null)
            {
                return NotFound();
            }

            db.Paises.Remove(adpais);
            db.SaveChanges();

            return Ok(adpais);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdpaisExists(int id)
        {
            return db.Paises.Count(e => e.id_pais == id) > 0;
        }
    }
}