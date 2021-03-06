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
    public class APIFormaCobroController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APIFormaCobro
        public IQueryable<AdFormasCobro> GetFormasCobro()
        {
            return db.FormasCobro;
        }

        // GET: api/APIFormaCobro/5
        [ResponseType(typeof(AdFormasCobro))]
        public IHttpActionResult GetAdFormasCobro(int id)
        {
            AdFormasCobro adFormasCobro = db.FormasCobro.Find(id);
            if (adFormasCobro == null)
            {
                return NotFound();
            }

            return Ok(adFormasCobro);
        }

        // PUT: api/APIFormaCobro/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdFormasCobro(int id, AdFormasCobro adFormasCobro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adFormasCobro.forma_cob_id)
            {
                return BadRequest();
            }

            db.Entry(adFormasCobro).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdFormasCobroExists(id))
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
        // POST: cobros/formas
        [HttpPost]
        [Route("cobros/formas")]
        [ResponseType(typeof(int))]
        public int CrearFormaCobro(AdFormasCobro formaCobro)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }

            db.FormasCobro.Add(formaCobro);
            db.SaveChanges();

            return 1;
        }

        // POST: api/APIFormaCobro
        [ResponseType(typeof(AdFormasCobro))]
        public IHttpActionResult PostAdFormasCobro(AdFormasCobro adFormasCobro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FormasCobro.Add(adFormasCobro);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AdFormasCobroExists(adFormasCobro.forma_cob_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = adFormasCobro.forma_cob_id }, adFormasCobro);
        }

        // DELETE: api/APIFormaCobro/5
        [ResponseType(typeof(AdFormasCobro))]
        public IHttpActionResult DeleteAdFormasCobro(int id)
        {
            AdFormasCobro adFormasCobro = db.FormasCobro.Find(id);
            if (adFormasCobro == null)
            {
                return NotFound();
            }

            db.FormasCobro.Remove(adFormasCobro);
            db.SaveChanges();

            return Ok(adFormasCobro);
        }

        [HttpGet]
        [Route("formas-cobros/actualizar")]
        public IHttpActionResult ActualizarFormasCobrosProfit()
        {
            ProfitEntities profitContext = new ProfitEntities();
            IQueryable<AdFormasCobro> formasCobros = db.FormasCobro;

            foreach (AdFormasCobro forma in formasCobros)
            {
                // Tablas de las que depende Formas de Cobro.
                // TODO: Incompleto.
                // TODO: ¿A cuál tabla de Profit se inserta esto?

                /*if (clienteProfit != null)
                {
                    byte[] validador = clienteProfit.validador;
                    profitContext.pActualizarCliente(
                        cliente.co_cli, cliente.co_cli, null, null, null, cliente.cli_des, cliente.co_seg, cliente.co_zon, cliente.co_ven, null, false, true, false, false, false, false, false, false,
                        false, false, cliente.direc1, null, cliente.dir_ent2, null, null, cliente.telefonos, null, cliente.respons, DateTime.Now, cliente.tip_cli, null, null, null, null,
                        null, null, null, null, null, cliente.rif, false, null, null, cliente.email, cliente.co_cta_ingr_egr, null, null, null, null, null, null, null, null, null, null, null, null,
                        null, null, null, cliente.juridico == "1", null, null, null, null, cliente.co_pais, cliente.ciudad, cliente.zip, null, null, null, null, validador, null, null,
                        null, null, null
                    );
                }
                else
                {
                    profitContext.pInsertarCliente(
                        cliente.co_cli, null, null, null, cliente.cli_des, cliente.co_seg, cliente.co_zon, cliente.co_ven, null, false, false, false, false, false, false, false, false,
                        false, false, cliente.direc1, null, cliente.dir_ent2, null, null, cliente.telefonos, null, cliente.respons, DateTime.Now, cliente.tip_cli, null, 0, 0, 0, null, null, 0,
                        0, 0, null, 0, cliente.rif, false, null, null, cliente.email, cliente.co_cta_ingr_egr, null, null, null, null, null, null, null, null, null, "", null, null,
                        null, null, cliente.juridico == "1", 1, null, null, null, cliente.co_pais, cliente.ciudad, cliente.zip, null, false, false, 0, null, null, null, null
                    );
                }*/
            }

            return Ok(true);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdFormasCobroExists(int id)
        {
            return db.FormasCobro.Count(e => e.forma_cob_id == id) > 0;
        }
    }
}