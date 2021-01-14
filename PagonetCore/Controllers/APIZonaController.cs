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
    public class APIZonaController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APIZona
        [Route("Zona/listazona")]
        public IQueryable<Adzona> GetZonas()
        {
            return db.Zonas;
        }

        // GET: api/APIZona/5
        [Route("Zona/listazonas/{id:int:min(1)}")]
        [ResponseType(typeof(Adzona))]
        public IHttpActionResult GetAdzona(int id)
        {
            Adzona adzona = db.Zonas.Find(id);
            if (adzona == null)
            {
                return NotFound();
            }

            return Ok(adzona);
        }

        // PUT: api/APIZona/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdzona(int id, Adzona adzona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adzona.id_zona)
            {
                return BadRequest();
            }

            db.Entry(adzona).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdzonaExists(id))
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
        // POST: Zona/guardarDatos
        [HttpPost]
        [Route("Zona/guardarDatos")]
        [ResponseType(typeof(int))]
        public int CrearZona(Adzona adzona)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }

            db.Zonas.Add(adzona);
            db.SaveChanges();

            return 1;
        }

        // POST: api/APIZona
        [ResponseType(typeof(Adzona))]
        public IHttpActionResult PostAdzona(Adzona adzona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Zonas.Add(adzona);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adzona.id_zona }, adzona);
        }

        // DELETE: api/APIZona/5
        [ResponseType(typeof(Adzona))]
        public IHttpActionResult DeleteAdzona(int id)
        {
            Adzona adzona = db.Zonas.Find(id);
            if (adzona == null)
            {
                return NotFound();
            }

            db.Zonas.Remove(adzona);
            db.SaveChanges();

            return Ok(adzona);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdzonaExists(int id)
        {
            return db.Zonas.Count(e => e.id_zona == id) > 0;
        }
    }
}