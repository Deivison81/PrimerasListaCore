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
    public class APIRenglonCotizacionController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APIRenglonCotizacion
        // GET: cotizacion/listarRenglones
        [Route("cotizacion/listarRenglones")]
        public IQueryable<AdCotizacionreg> GetRenglonesCotizacion()
        {
            return db.RenglonesCotizacion;
        }

        // GET: api/APIRenglonCotizacion/5
        [Route("cotizacion/listarRenglonesid/{id:int:min(1)}")]
        [ResponseType(typeof(AdCotizacionreg))]
        public IHttpActionResult GetAdCotizacionreg(int id)
        {
            AdCotizacionreg adCotizacionreg = db.RenglonesCotizacion.Find(id);
            if (adCotizacionreg == null)
            {
                return NotFound();
            }

            return Ok(adCotizacionreg);
        }

        // PUT: api/APIRenglonCotizacion/5
        public IHttpActionResult PutAdCotizacionreg(int id, AdCotizacionreg adCotizacionreg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!id.Equals(adCotizacionreg.id_doc_num))
            {
                return BadRequest("id_doc_num no coincide con el ID del parámetro del URL.");
            }

            db.Entry(adCotizacionreg).State = EntityState.Modified;

            try
            {
                DateTime fechaEmisionCotizacion = db.Cotizaciones
                .Where(c => c.doc_num.Equals(adCotizacionreg.doc_num))
                .Select(c => (DateTime)c.fec_emis)
                .FirstOrDefault();

                decimal baseNeta = 0, valorIva = 0, totalMontoImpuesto = 0, totalMontoNeto = 0;

                decimal tasaDelDia = db.Tasas
                    .Where(t => t.fecha.Value.CompareTo(fechaEmisionCotizacion) <= 0)
                    .Select(t => (decimal)t.tasa_v)
                    .ToList()
                    .LastOrDefault();

                baseNeta = (decimal)(adCotizacionreg.total_art * adCotizacionreg.prec_vta);
                valorIva = (decimal)(adCotizacionreg.porc_imp);
                adCotizacionreg.monto_imp = baseNeta * (valorIva / 100);
                adCotizacionreg.reng_neto = baseNeta + adCotizacionreg.monto_imp;
                totalMontoImpuesto += (decimal)adCotizacionreg.monto_imp;
                totalMontoNeto += (decimal)adCotizacionreg.reng_neto;
                adCotizacionreg.tasa_v = tasaDelDia;
                adCotizacionreg.prec_vta_om = (tasaDelDia != 0) ? (adCotizacionreg.prec_vta / tasaDelDia) : null;

                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdCotizacionregExists(id))
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
        // POST: cotizacion/guardarDatosreng
        [HttpPost]
        [Route("cotizacion/guardarDatosreng")]
        [ResponseType(typeof(int))]
        public int CrearRenglonCotizacion(AdCotizacionreg adCotizacionreg)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }

            DateTime fechaEmisionCotizacion = db.Cotizaciones
                .Where(c => c.doc_num == adCotizacionreg.doc_num)
                .Select(c => (DateTime)c.fec_emis)
                .FirstOrDefault();

            decimal baseNeta = 0, valorIva = 0, totalMontoImpuesto = 0, totalMontoNeto = 0;

            decimal tasaDelDia = db.Tasas
                .Where(t => t.fecha.Value.CompareTo(fechaEmisionCotizacion) <= 0)
                .Select(t => (decimal)t.tasa_v)
                .ToList()
                .LastOrDefault();

            baseNeta = (decimal)(adCotizacionreg.total_art * adCotizacionreg.prec_vta);
            valorIva = (decimal)(adCotizacionreg.porc_imp);
            adCotizacionreg.monto_imp = baseNeta * (valorIva / 100);
            adCotizacionreg.reng_neto = baseNeta + adCotizacionreg.monto_imp;
            totalMontoImpuesto += (decimal)adCotizacionreg.monto_imp;
            totalMontoNeto += (decimal)adCotizacionreg.reng_neto;
            adCotizacionreg.tasa_v = tasaDelDia;
            adCotizacionreg.prec_vta_om = (tasaDelDia != 0) ? (adCotizacionreg.prec_vta / tasaDelDia) : null;

            db.RenglonesCotizacion.Add(adCotizacionreg);
            db.SaveChanges();

            return adCotizacionreg.reng_num;
        }

        // POST: api/APIRenglonCotizacion
        [ResponseType(typeof(AdCotizacionreg))]
        public IHttpActionResult PostAdCotizacionreg(AdCotizacionreg adCotizacionreg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DateTime fechaEmisionCotizacion = db.Cotizaciones
                .Where(c => c.doc_num.Equals(adCotizacionreg.doc_num))
                .Select(c => (DateTime)c.fec_emis)
                .FirstOrDefault();

            decimal baseNeta = 0, valorIva = 0, totalMontoImpuesto = 0, totalMontoNeto = 0;

            decimal tasaDelDia = db.Tasas
                .Where(t => t.fecha.Value.CompareTo(fechaEmisionCotizacion) <= 0)
                .Select(t => (decimal)t.tasa_v)
                .ToList()
                .LastOrDefault();

            baseNeta = (decimal)(adCotizacionreg.total_art * adCotizacionreg.prec_vta);
            valorIva = (decimal)(adCotizacionreg.porc_imp);
            adCotizacionreg.monto_imp = baseNeta * (valorIva / 100);
            adCotizacionreg.reng_neto = baseNeta + adCotizacionreg.monto_imp;
            totalMontoImpuesto += (decimal)adCotizacionreg.monto_imp;
            totalMontoNeto += (decimal)adCotizacionreg.reng_neto;
            adCotizacionreg.tasa_v = tasaDelDia;
            adCotizacionreg.prec_vta_om = (tasaDelDia != 0) ? (adCotizacionreg.prec_vta / tasaDelDia) : null;

            db.RenglonesCotizacion.Add(adCotizacionreg);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adCotizacionreg.id_doc_num }, adCotizacionreg);
        }

        // DELETE: api/APIRenglonCotizacion/5
        [ResponseType(typeof(AdCotizacionreg))]
        public IHttpActionResult DeleteAdCotizacionreg(int id)
        {
            AdCotizacionreg adCotizacionreg = db.RenglonesCotizacion.Find(id);
            if (adCotizacionreg == null)
            {
                return NotFound();
            }

            db.RenglonesCotizacion.Remove(adCotizacionreg);
            db.SaveChanges();

            return Ok(adCotizacionreg);
        }

        [HttpGet]
        public IHttpActionResult ActualizarRenglonesCotizacionesProfit()
        {
            ProfitEntities profitContext = new ProfitEntities();
            IQueryable<AdCotizacionreg> renglonesCotizacion = db.RenglonesCotizacion;

            foreach (AdCotizacionreg renglon in renglonesCotizacion)
            {
                // Tablas de las que depende Renglón de Cotización.
                // TODO: Falta co_sucur para insertar el almacén.
                pSeleccionarRenglonesCotizacionCliente_Result renglonesCotizacionProfit = profitContext.pSeleccionarRenglonesCotizacionCliente(renglon.num_doc).FirstOrDefault();
                pSeleccionarArticulo_Result articuloProfit = profitContext.pSeleccionarArticulo(renglon.co_art).FirstOrDefault();
                pSeleccionarAlmacen_Result almacenProfit = profitContext.pSeleccionarAlmacen(renglon.co_alma).FirstOrDefault();

                AdArticulo articulo = renglon.Articulo;
                AdAlmacen almacen = renglon.Almacen;

                if (articuloProfit != null)
                {
                    byte[] validador = articuloProfit.validador;
                    profitContext.pActualizarArticulo(
                        articulo.co_art, articulo.co_art, articuloProfit.fecha_reg, articulo.art_des, articuloProfit.tipo, articuloProfit.anulado, articuloProfit.fecha_inac, articulo.co_lin, articulo.co_cat, 
                        articulo.co_subl, articulo.co_color, articulo.co_ubicacion, articuloProfit.item, articuloProfit.modelo, articuloProfit.@ref, articuloProfit.generico, articuloProfit.maneja_serial,
                        articuloProfit.maneja_lote, articuloProfit.maneja_lote_venc, articuloProfit.margen_min, articuloProfit.margen_max, articulo.tipo_imp, articulo.tipo_imp2, articulo.tipo_imp3,
                        articuloProfit.co_reten, articuloProfit.cod_proc, articuloProfit.garantia, articuloProfit.volumen, articuloProfit.peso, articuloProfit.stock_min, articuloProfit.stock_max,
                        articuloProfit.stock_pedido, articuloProfit.relac_unidad, articuloProfit.punt_ven, articuloProfit.punt_cli, articuloProfit.lic_mon_ilc, articuloProfit.lic_capacidad,
                        articuloProfit.lic_grado_al, articuloProfit.lic_tipo, articuloProfit.prec_om, articuloProfit.comentario, articuloProfit.tipo_cos, articuloProfit.porc_margen_minimo,
                        articuloProfit.porc_margen_maximo, articuloProfit.mont_comi, articuloProfit.porc_arancel, articuloProfit.dis_cen, articuloProfit.reten_iva_tercero, articuloProfit.campo1,
                        articuloProfit.campo2, articuloProfit.campo3, articuloProfit.campo4, articuloProfit.campo5, articuloProfit.campo6, articuloProfit.campo7, articuloProfit.campo8, articuloProfit.co_us_mo,
                        articuloProfit.co_sucu_mo, null, null, articuloProfit.revisado, articuloProfit.trasnfe, validador, null
                    );
                } else
                {
                    profitContext.pInsertarArticulo(
                        articulo.co_art, DateTime.Now, articulo.art_des, "", false, null, articulo.co_lin, articulo.co_cat,
                        articulo.co_subl, articulo.co_color, articulo.co_ubicacion, null, null, articulo.referencia, false, false, false, false, 0, 0, articulo.tipo_imp, articulo.tipo_imp2, 
                        articulo.tipo_imp3, null, null, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, null, false, null, null, 0, 0, 0, 0, null, null, null, null, null, null, null, null, null, null, null, "", null, null,
                        null, null
                    );
                }

                if (almacenProfit != null)
                {
                    byte[] validador = almacenProfit.validador;
                    profitContext.pActualizarAlmacen(
                        almacen.co_alma, almacen.co_alma, almacen.des_alamacen, almacenProfit.co_sucur, almacenProfit.noventa, almacenProfit.nocompra, almacenProfit.materiales, almacenProfit.produccion, 
                        almacenProfit.alm_temp, almacenProfit.campo1, almacenProfit.campo2, almacenProfit.campo3, almacenProfit.campo4, almacenProfit.campo5, almacenProfit.campo6, almacenProfit.campo7, 
                        almacenProfit.campo8, almacenProfit.co_us_mo, almacenProfit.co_sucu_mo, null, null, almacenProfit.revisado, almacenProfit.trasnfe, validador, null
                    );
                }
                else
                {
                    profitContext.pInsertarAlmacen(
                        almacen.co_alma, almacen.des_alamacen, "", false, false, false, false, false, null, null, null, null, null, null, null, null, "",
                        null, null, null, null
                    );
                }

                if (renglonesCotizacionProfit != null)
                {
                    profitContext.pActualizarRenglonesCotizacionCliente(
                        renglon.reng_num, renglon.num_doc, renglon.reng_num, renglon.num_doc, renglon.co_art, renglon.art_des, renglon.cod_unidad, renglonesCotizacionProfit.sco_uni, renglon.co_alma, 
                        renglon.co_precios, renglon.tipo_imp, renglon.tipo_imp2, renglon.tipo_imp3, renglon.total_art, renglon.stotal_art, renglon.prec_vta, renglonesCotizacionProfit.porc_desc, 
                        renglonesCotizacionProfit.monto_desc, renglon.reng_neto, renglonesCotizacionProfit.pendiente, renglon.tipo_doc, renglonesCotizacionProfit.rowguid_doc, renglon.num_doc, 
                        renglon.porc_imp, renglon.porc_imp2, renglon.porc_imp3, renglon.monto_imp, renglon.monto_imp2, renglon.monto_imp3, renglonesCotizacionProfit.otros, renglonesCotizacionProfit.total_dev,
                        renglonesCotizacionProfit.monto_dev, renglonesCotizacionProfit.comentario, renglonesCotizacionProfit.pendiente2, renglonesCotizacionProfit.monto_desc_glob, 
                        renglonesCotizacionProfit.monto_reca_glob, renglonesCotizacionProfit.otros1_glob, renglonesCotizacionProfit.otros2_glob, renglonesCotizacionProfit.otros3_glob,
                        renglonesCotizacionProfit.monto_imp_afec_glob, renglonesCotizacionProfit.monto_imp2_afec_glob, renglonesCotizacionProfit.monto_imp3_afec_glob, renglonesCotizacionProfit.dis_cen,
                        renglonesCotizacionProfit.co_sucu_mo, renglonesCotizacionProfit.co_us_mo, renglonesCotizacionProfit.revisado, renglonesCotizacionProfit.trasnfe, null, null, null
                    );
                }
                else
                {
                    profitContext.pInsertarRenglonesCotizacionCliente(
                        renglon.reng_num, renglon.num_doc, renglon.co_art, renglon.art_des, renglon.cod_unidad, null, renglon.co_alma, renglon.co_precios, renglon.tipo_imp,
                        renglon.tipo_imp2, renglon.tipo_imp3, renglon.total_art, renglon.stotal_art, renglon.prec_vta, null, 0, renglon.reng_neto, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, renglon.tipo_doc, null,
                        renglon.num_doc, renglon.porc_imp, renglon.porc_imp2, renglon.porc_imp3, renglon.monto_imp, renglon.monto_imp2, renglon.monto_imp3, 0, 0, 0, null, null, null, "", null, null, null
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

        private bool AdCotizacionregExists(int id)
        {
            return db.RenglonesCotizacion.Count(e => e.id_doc_num == id) > 0;
        }
    }
}