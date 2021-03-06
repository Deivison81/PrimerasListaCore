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
                saCobroTPReng formaCobroProfit = profitContext.saCobroTPReng.Where(f => (f.cob_num == forma.cob_num_pro) && (f.reng_num == forma.nro_reng)).FirstOrDefault();
                pSeleccionarMovimientoBanco_Result movBancoProfit = profitContext.pSeleccionarMovimientoBanco(forma.mov_num_b).FirstOrDefault();

                if (movBancoProfit != null)
                {
                    byte[] validador = movBancoProfit.validador;
                    profitContext.pActualizarMovimientoBanco(
                        forma.mov_num_b, forma.mov_num_b, movBancoProfit.descrip, forma.cod_cta, movBancoProfit.fecha, movBancoProfit.tasa, movBancoProfit.tipo_op,
                        movBancoProfit.doc_num, movBancoProfit.monto, movBancoProfit.co_cta_ingr_egr, movBancoProfit.origen, movBancoProfit.cob_pag, movBancoProfit.idb,
                        movBancoProfit.dep_num, movBancoProfit.conciliado, movBancoProfit.anulado, movBancoProfit.ori_dep, movBancoProfit.dep_con, movBancoProfit.saldo_ini,
                        movBancoProfit.fec_con, movBancoProfit.cod_ingben, movBancoProfit.fecha_che, movBancoProfit.dis_cen, movBancoProfit.nro_transf_nomi, movBancoProfit.campo1,
                        movBancoProfit.campo2, movBancoProfit.campo3, movBancoProfit.campo4, movBancoProfit.campo5, movBancoProfit.campo6, movBancoProfit.campo7, movBancoProfit.campo8,
                        movBancoProfit.co_us_mo, movBancoProfit.co_sucu_mo, null, null, movBancoProfit.revisado, movBancoProfit.trasnfe, validador, null
                    );
                }
                else
                {
                    AdMovimientoBanco movBanco = db.MovimientosBancos.Where(m => m.mov_num == forma.mov_num_b).FirstOrDefault();
                    profitContext.pInsertarMovimientoBanco(
                        movBanco.mov_num, movBanco.descrip, movBanco.cod_cta, movBanco.fecha, movBanco.tasa, movBanco.tipo_op, movBanco.doc_num, movBanco.monto_d, movBanco.co_cta_ingr_egr,
                        movBanco.origen, movBanco.cob_pag, movBanco.idb, movBanco.dep_num, movBanco.anulado, movBanco.saldo_ini, movBanco.conciliado, movBanco.ori_dep, movBanco.dep_con,
                        movBanco.fec_con, movBanco.cod_ingben, movBanco.fecha_che, movBanco.dis_cen, movBanco.nro_transf_nomi, movBanco.campo1, movBanco.campo2, movBanco.campo3, movBanco.campo4,
                        movBanco.campo5, movBanco.campo6, movBanco.campo7, movBanco.campo8, movBanco.co_us_in, movBanco.co_sucu_in, null, movBanco.revisado, movBanco.trasnfe
                    );
                }

                if (formaCobroProfit != null)
                {
                    profitContext.pActualizarRenglonesTPCobro(
                        forma.nro_reng, forma.nro_reng, forma.cob_num_pro, forma.cob_num_pro, forma.forma_pag, forma.cod_cta, forma.co_ban, formaCobroProfit.co_tar, formaCobroProfit.co_vale,
                        forma.cod_caja, forma.mov_num_c, forma.mov_num_b, formaCobroProfit.num_doc, formaCobroProfit.devuelto, forma.mont_doc, formaCobroProfit.fecha_che, formaCobroProfit.co_sucu_mo,
                        formaCobroProfit.co_us_mo, formaCobroProfit.trasnfe, formaCobroProfit.revisado, Guid.NewGuid(), null, null
                    );
                }
                else
                {
                    profitContext.pInsertarRenglonesTPCobro(
                        forma.nro_reng, forma.cob_num_pro, forma.forma_pag, forma.mov_num_c, forma.mov_num_b, null, false, forma.mont_doc, forma.cod_cta, forma.co_ban, null, null,
                        forma.cod_caja, DateTime.Now, null, "", null, null, null
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

        private bool AdFormasCobroExists(int id)
        {
            return db.FormasCobro.Count(e => e.forma_cob_id == id) > 0;
        }
    }
}