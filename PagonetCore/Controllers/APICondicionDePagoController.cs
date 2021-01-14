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
    public class APICondicionDePagoController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APICondicionDePago
        [Route("Condicion/listarCondiciones")]
        public IQueryable<Adcondiciondepago> GetCondicionesDePago()
        {
            return db.CondicionesDePago;
        }

        // GET: cotizacion/listarCondicion
        // NOTA:
        // Esto se colocó para compatibilidad con rutas anteriores, pero no es apropiado, puesto
        // que la ruta incluye 'Cotización' en su URL, y esto es completamente 
        // y únicamente relacionado a Condición de Pago.
        [Route("cotizacion/listarCondicion")]
        public IHttpActionResult GetCondicionesDePagoCotizacion()
        {
            return Json(db.CondicionesDePago.Select(x => new
            {
                IID = x.id_condicion,
                CODIGO = x.co_cond,
                NOMBRE = x.cond_des,
                DIAS = x.dias_cred
            }));
        }

        // GET: api/APICondicionDePago/5
        [Route("Condicion/listarCondicion/{id:int:min(1)}")]
        [ResponseType(typeof(Adcondiciondepago))]
        public IHttpActionResult GetAdcondiciondepago(int id)
        {
            Adcondiciondepago adcondiciondepago = db.CondicionesDePago.Find(id);
            if (adcondiciondepago == null)
            {
                return NotFound();
            }

            return Ok(adcondiciondepago);
        }

        // PUT: api/APICondicionDePago/5
        [Route("Condicion/modificarDatos")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdcondiciondepago(int id, Adcondiciondepago adcondiciondepago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adcondiciondepago.id_condicion)
            {
                return BadRequest();
            }

            db.Entry(adcondiciondepago).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdcondiciondepagoExists(id))
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
        // POST: Condicion/guardarDatos
        [HttpPost]
        [Route("Condicion/guardarDatos")]
        [ResponseType(typeof(int))]
        public int CrearCondicionDePago(Adcondiciondepago adcondiciondepago)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }

            db.CondicionesDePago.Add(adcondiciondepago);
            db.SaveChanges();

            return 1;
        }

        // POST: api/APICondicionDePago
        [ResponseType(typeof(Adcondiciondepago))]
        public IHttpActionResult PostAdcondiciondepago(Adcondiciondepago adcondiciondepago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CondicionesDePago.Add(adcondiciondepago);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adcondiciondepago.id_condicion }, adcondiciondepago);
        }

        // DELETE: api/APICondicionDePago/5
        [ResponseType(typeof(Adcondiciondepago))]
        public IHttpActionResult DeleteAdcondiciondepago(int id)
        {
            Adcondiciondepago adcondiciondepago = db.CondicionesDePago.Find(id);
            if (adcondiciondepago == null)
            {
                return NotFound();
            }

            db.CondicionesDePago.Remove(adcondiciondepago);
            db.SaveChanges();

            return Ok(adcondiciondepago);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdcondiciondepagoExists(int id)
        {
            return db.CondicionesDePago.Count(e => e.id_condicion == id) > 0;
        }
    }
}