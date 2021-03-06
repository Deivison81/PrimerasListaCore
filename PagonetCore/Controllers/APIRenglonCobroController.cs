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
    public class APIRenglonCobroController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APIRenglonCobro
        public IQueryable<AdRenglonesCobro> GetRenglonesCobro()
        {
            return db.RenglonesCobro;
        }

        // GET: api/APIRenglonCobro/5
        [ResponseType(typeof(AdRenglonesCobro))]
        public IHttpActionResult GetAdRenglonesCobro(int id)
        {
            AdRenglonesCobro adRenglonesCobro = db.RenglonesCobro.Find(id);
            if (adRenglonesCobro == null)
            {
                return NotFound();
            }

            return Ok(adRenglonesCobro);
        }

        // PUT: api/APIRenglonCobro/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdRenglonesCobro(int id, AdRenglonesCobro adRenglonesCobro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adRenglonesCobro.idrencob)
            {
                return BadRequest();
            }

            db.Entry(adRenglonesCobro).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdRenglonesCobroExists(id))
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
        // POST: cobros/renglones
        [ResponseType(typeof(int))]
        public int CrearRenglonCobro(AdRenglonesCobro renglonCobro)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }

            db.RenglonesCobro.Add(renglonCobro);
            db.SaveChanges();

            return 1;
        }

        // POST: api/APIRenglonCobro
        [HttpPost]
        [Route("cobros/renglones")]
        [ResponseType(typeof(AdRenglonesCobro))]
        public IHttpActionResult PostAdRenglonesCobro(AdRenglonesCobro adRenglonesCobro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RenglonesCobro.Add(adRenglonesCobro);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AdRenglonesCobroExists(adRenglonesCobro.idrencob))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = adRenglonesCobro.idrencob }, adRenglonesCobro);
        }

        // DELETE: api/APIRenglonCobro/5
        [ResponseType(typeof(AdRenglonesCobro))]
        public IHttpActionResult DeleteAdRenglonesCobro(int id)
        {
            AdRenglonesCobro adRenglonesCobro = db.RenglonesCobro.Find(id);
            if (adRenglonesCobro == null)
            {
                return NotFound();
            }

            db.RenglonesCobro.Remove(adRenglonesCobro);
            db.SaveChanges();

            return Ok(adRenglonesCobro);
        }

        [HttpGet]
        [Route("renglones-cobros/actualizar")]
        public IHttpActionResult ActualizarRenglonesCobrosProfit()
        {
            ProfitEntities profitContext = new ProfitEntities();
            IQueryable<AdRenglonesCobro> renglonesCobros = db.RenglonesCobro;

            foreach (AdRenglonesCobro renglon in renglonesCobros)
            {
                // TODO: Falta calcular el IVA en cada renglón al insertar.
                pSeleccionarRenglonesCobro_Result renglonCobroProfit = profitContext.pSeleccionarRenglonesCobro(renglon.cob_num_pro).FirstOrDefault();

                if (renglonCobroProfit != null)
                {
                    profitContext.pActualizarRenglonesDocCobro(
                        renglon.reng_num, renglon.cob_num_pro, renglon.reng_num, renglon.cob_num_pro, renglon.co_tipo_doc, renglon.nro_doc, renglon.mont_cob, renglonCobroProfit.dpcobro_porc_desc,
                        renglon.dpcobro_monto, renglonCobroProfit.monto_retencion_iva, renglonCobroProfit.monto_retencion, renglonCobroProfit.reten_tercero_rowguid_ori, 
                        renglonCobroProfit.rowguid_reng_ori, renglon.tipo_doc, renglon.num_doc, renglonCobroProfit.tipo_origen, renglonCobroProfit.gen_origen, renglonCobroProfit.co_sucu_mo,
                        renglonCobroProfit.co_us_mo, renglonCobroProfit.trasnfe, renglonCobroProfit.revisado, null, null, null
                    );
                }
                else
                {
                    profitContext.pInsertarRenglonesDocCobro(
                        renglon.reng_num, renglon.cob_num_pro, renglon.co_tipo_doc, renglon.nro_doc, renglon.mont_cob, 0, renglon.dpcobro_monto, 0, 0, renglon.tipo_doc, renglon.num_doc, 
                        null, null, null, 0, null, null, "", null, null, null
                    );
                }
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

        private bool AdRenglonesCobroExists(int id)
        {
            return db.RenglonesCobro.Count(e => e.idrencob == id) > 0;
        }
    }
}