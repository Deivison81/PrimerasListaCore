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
    public class APITasaIVAController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APITasaIVA
        [Route("TasaIVA/ListarIVA")]
        public IHttpActionResult GetTasasIVA()
        {
            var listarIVA = db.TasasIVA.Select(p => new
            {
                p.id_impuesto,
                p.fechapubli,
                p.nro_reng,
                p.tip_impu,
                p.ventas,
                p.consumosuntuario,
                p.porcentajetaza,
                p.porcentajesuntuario,
                p.importado_web,
                p.importado_pro
            }).ToList();

            return Ok(listarIVA);
        }

        // GET: api/APITasaIVA/5
        [ResponseType(typeof(Tasa_IVA))]
        public IHttpActionResult GetTasa_IVA(int id)
        {
            Tasa_IVA tasa_IVA = db.TasasIVA.Find(id);
            if (tasa_IVA == null)
            {
                return NotFound();
            }

            return Ok(tasa_IVA);
        }

        // PUT: api/APITasaIVA/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTasa_IVA(int id, Tasa_IVA tasa_IVA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tasa_IVA.id_impuesto)
            {
                return BadRequest();
            }

            db.Entry(tasa_IVA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tasa_IVAExists(id))
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

        // POST: api/APITasaIVA
        [ResponseType(typeof(Tasa_IVA))]
        public IHttpActionResult PostTasa_IVA(Tasa_IVA tasa_IVA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TasasIVA.Add(tasa_IVA);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Tasa_IVAExists(tasa_IVA.id_impuesto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tasa_IVA.id_impuesto }, tasa_IVA);
        }

        // DELETE: api/APITasaIVA/5
        [ResponseType(typeof(Tasa_IVA))]
        public IHttpActionResult DeleteTasa_IVA(int id)
        {
            Tasa_IVA tasa_IVA = db.TasasIVA.Find(id);
            if (tasa_IVA == null)
            {
                return NotFound();
            }

            db.TasasIVA.Remove(tasa_IVA);
            db.SaveChanges();

            return Ok(tasa_IVA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tasa_IVAExists(int id)
        {
            return db.TasasIVA.Count(e => e.id_impuesto == id) > 0;
        }
    }
}