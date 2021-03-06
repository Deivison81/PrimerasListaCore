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
                saCobroDocReng renglonCobroProfit = profitContext.saCobroDocReng.Where(r => (r.cob_num == renglon.cob_num_pro) && (r.reng_num == renglon.reng_num)).FirstOrDefault();
                pSeleccionarDocumentoVenta_Result documentoVentaProfit = profitContext.pSeleccionarDocumentoVenta(renglon.co_tipo_doc, renglon.nro_doc).FirstOrDefault();
                pSeleccionarTipoDocumento_Result tipoDocumentoProfit = profitContext.pSeleccionarTipoDocumento(renglon.co_tipo_doc).FirstOrDefault();
                pSeleccionarCobro_Result cobroProfit = profitContext.pSeleccionarCobro(renglon.cob_num_pro).First();

                if (tipoDocumentoProfit != null)
                {
                    byte[] validador = tipoDocumentoProfit.validador;
                    profitContext.pActualizarTipoDocumento(
                        renglon.co_tipo_doc, renglon.co_tipo_doc, tipoDocumentoProfit.descrip, tipoDocumentoProfit.tipo_mov, tipoDocumentoProfit.usar_ventas, tipoDocumentoProfit.usar_compras,
                        tipoDocumentoProfit.registro_sistema, tipoDocumentoProfit.num_fact_fis_venta, tipoDocumentoProfit.num_cont_venta, tipoDocumentoProfit.serial_imp_fis_venta,
                        tipoDocumentoProfit.num_iva_venta, tipoDocumentoProfit.reac_doc_Compra, tipoDocumentoProfit.reac_doc_Venta, tipoDocumentoProfit.anul_doc_venta, tipoDocumentoProfit.anul_doc_compra,
                        tipoDocumentoProfit.doc_prov_compra, tipoDocumentoProfit.num_control_compra, tipoDocumentoProfit.reng_compra, tipoDocumentoProfit.reng_venta, tipoDocumentoProfit.num_iva_compra,
                        tipoDocumentoProfit.manual_venta, tipoDocumentoProfit.manual_compra, tipoDocumentoProfit.doc_asoc_compra, tipoDocumentoProfit.doc_asoc_venta, tipoDocumentoProfit.act_prog_pago,
                        tipoDocumentoProfit.aplica_dxpp_venta, tipoDocumentoProfit.aplica_dxpp_compra, tipoDocumentoProfit.aplica_riva_venta, tipoDocumentoProfit.aplica_riva_compra,
                        tipoDocumentoProfit.tipo_imp, tipoDocumentoProfit.campo1, tipoDocumentoProfit.campo2, tipoDocumentoProfit.campo3, tipoDocumentoProfit.campo4, tipoDocumentoProfit.campo5,
                        tipoDocumentoProfit.campo6, tipoDocumentoProfit.campo7, tipoDocumentoProfit.campo8, tipoDocumentoProfit.co_us_mo, tipoDocumentoProfit.co_sucu_mo, null, null, null,
                        tipoDocumentoProfit.trasnfe, validador, null
                    );
                }
                else
                {
                    profitContext.pInsertarTipoDocumento(
                        renglon.co_tipo_doc, "", "CR", false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, 
                        false, false, false, false, false, false, false, false, "", null, null, null, null, null, null, null, null, "", null, null, null, null
                    );
                }

                if (documentoVentaProfit != null)
                {
                    byte[] validador = documentoVentaProfit.validador;
                    profitContext.pActualizarDocumentoVenta(
                        renglon.co_tipo_doc, renglon.co_tipo_doc, renglon.nro_doc, renglon.nro_doc, documentoVentaProfit.co_cli, documentoVentaProfit.co_ven, documentoVentaProfit.co_mone,
                        documentoVentaProfit.co_cta_ingr_egr, documentoVentaProfit.mov_ban, documentoVentaProfit.tasa, documentoVentaProfit.observa, documentoVentaProfit.fec_reg,
                        documentoVentaProfit.fec_emis, documentoVentaProfit.fec_venc, documentoVentaProfit.anulado, documentoVentaProfit.aut, documentoVentaProfit.contrib, documentoVentaProfit.doc_orig,
                        documentoVentaProfit.nro_orig, documentoVentaProfit.nro_che, documentoVentaProfit.monto_imp, renglon.saldo, documentoVentaProfit.total_bruto, documentoVentaProfit.monto_desc_glob,
                        documentoVentaProfit.porc_desc_glob, documentoVentaProfit.porc_reca, documentoVentaProfit.monto_reca, documentoVentaProfit.total_neto, documentoVentaProfit.monto_imp2,
                        documentoVentaProfit.monto_imp3, documentoVentaProfit.tipo_imp, documentoVentaProfit.porc_imp, documentoVentaProfit.porc_imp2, documentoVentaProfit.porc_imp3,
                        documentoVentaProfit.num_comprobante, documentoVentaProfit.tipo_origen, documentoVentaProfit.n_control, documentoVentaProfit.dis_cen, documentoVentaProfit.comis1,
                        documentoVentaProfit.comis2, documentoVentaProfit.comis3, documentoVentaProfit.comis4, documentoVentaProfit.comis5, documentoVentaProfit.comis6, documentoVentaProfit.adicional,
                        documentoVentaProfit.salestax, documentoVentaProfit.ven_ter, documentoVentaProfit.impfis, documentoVentaProfit.impfisfac, documentoVentaProfit.imp_nro_z, documentoVentaProfit.otros1,
                        documentoVentaProfit.otros2, documentoVentaProfit.otros3, documentoVentaProfit.campo1, documentoVentaProfit.campo2, documentoVentaProfit.campo3, documentoVentaProfit.campo4,
                        documentoVentaProfit.campo5, documentoVentaProfit.campo6, documentoVentaProfit.campo7, documentoVentaProfit.campo8, documentoVentaProfit.co_us_mo, documentoVentaProfit.co_sucu_mo,
                        documentoVentaProfit.revisado, documentoVentaProfit.trasnfe, null, null, validador, null
                    );
                }
                else
                {
                    profitContext.pInsertarDocumentoVenta(
                        renglon.co_tipo_doc, renglon.nro_doc, cobroProfit.co_cli, cobroProfit.co_ven, cobroProfit.co_mone, null, cobroProfit.co_cta_ingr_egr, cobroProfit.tasa, 
                        null, DateTime.Now, DateTime.Now, DateTime.Now, cobroProfit.anulado, false, false, renglon.co_tipo_doc, null, null, 0, renglon.saldo, 0, 0, null, null, 0, 
                        renglon.saldo, 0, 0, null, 0, 0, 0, 0, null, null, null, 0, 0, 0, 0, 0, 0, 0, null, false, null, null, null, 0, 0, 0, null, null, null, null, null, null, null, null, null, 
                        null, null, "", null
                    );
                }

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
                        null, null, Guid.NewGuid(), 0, null, null, "", null, null, null
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