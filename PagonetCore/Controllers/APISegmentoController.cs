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
    public class APISegmentoController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APISegmento
        [Route("Segmento/listarSegmento")]
        public IHttpActionResult GetSegmentos()
        {
            var listarSegmento = db.Segmentos.Select(p => new {
                p.id_segmento,
                p.co_seg,
                p.seg_des,
                p.importado_web,
                p.importado_pro
            }).ToList();

            return Ok(listarSegmento);
        }

        // GET: api/APISegmento/5
        [Route("Segmento/listarSegmentos/{id:int:min(1)}")]
        [ResponseType(typeof(AdSegmento))]
        public IHttpActionResult GetAdSegmento(int id)
        {
            var adSegmento = db.Segmentos.Where(p => p.id_segmento.Equals(id)).Select(p => new {
                p.id_segmento,
                p.co_seg,
                p.seg_des,
                p.importado_web,
                p.importado_pro
            }).ToList();

            if (adSegmento == null)
            {
                return NotFound();
            }

            return Ok(adSegmento);
        }

        // PUT: api/APISegmento/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdSegmento(int id, AdSegmento adSegmento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adSegmento.id_segmento)
            {
                return BadRequest();
            }

            db.Entry(adSegmento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdSegmentoExists(id))
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
        // POST: Segmento/GuardarDatos
        [HttpPost]
        [Route("Segmento/GuardarDatos")]
        [ResponseType(typeof(int))]
        public int CrearSegmento(AdSegmento adSegmento)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }

            db.Segmentos.Add(adSegmento);
            db.SaveChanges();

            return 1;
        }

        // POST: api/APISegmento
        [ResponseType(typeof(AdSegmento))]
        public IHttpActionResult PostAdSegmento(AdSegmento adSegmento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Segmentos.Add(adSegmento);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adSegmento.id_segmento }, adSegmento);
        }

        // DELETE: api/APISegmento/5
        [ResponseType(typeof(AdSegmento))]
        public IHttpActionResult DeleteAdSegmento(int id)
        {
            AdSegmento adSegmento = db.Segmentos.Find(id);
            if (adSegmento == null)
            {
                return NotFound();
            }

            db.Segmentos.Remove(adSegmento);
            db.SaveChanges();

            return Ok(adSegmento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdSegmentoExists(int id)
        {
            return db.Segmentos.Count(e => e.id_segmento == id) > 0;
        }
    }
}