using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using PagonetCore.DAL;
using PagonetCore.Models;

namespace PagonetCore.Controllers
{
    public class APICotizacionController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APICotizacion
        // GET: cotizacion/listarCotizacion
        [Route("cotizacion/listarCotizacion")]
        public IHttpActionResult GetCotizaciones()
        {
            var listarcotizacion = db.Cotizaciones.Select(p => new
            {
                p.id_doc_num,
                p.doc_num,
                p.descrip,
                p.id_clientes,
                p.co_cli,
                p.idtransporte,
                p.co_tran,
                p.co_mone,
                p.id_vendedor,
                p.co_ven,
                p.id_condicion,
                p.co_cond,
                p.fec_emis,
                p.fec_venc,
                p.fec_reg,
                // FECHAINI =  ((DateTime) p.fec_emis).ToShortDateString(),
                // FEVENC =((DateTime)p.fec_venc).ToShortDateString(),
                // FECREG = ((DateTime)p.fec_reg).ToShortDateString(),
                p.anulado,
                p.status,
                p.total_bruto,
                p.monto_imp,
                p.monto_imp2,
                p.monto_imp3,
                p.total_neto,
                p.saldo,
                p.Direcionop,
                p.importado_web,
                p.importado_pro,
                p.Diasvencimiento,
                p.nro_pedido,
                p.vencida
            }).ToList();

            return Ok(listarcotizacion);
        }

        // GET: api/APICotizacion/5
        [Route("cotizacion/listarCotizacionid/{id:int:min(1)}")]
        [ResponseType(typeof(Adcotizacion))]
        public IHttpActionResult GetAdcotizacion(int id)
        {
            var adcotizacion = db.Cotizaciones.Where(p => p.id_doc_num.Equals(id)).Select(p => new
            {
                p.id_doc_num,
                p.doc_num,
                p.descrip,
                p.id_clientes,
                p.co_cli,
                p.idtransporte,
                p.co_tran,
                p.co_mone,
                p.id_vendedor,
                p.co_ven,
                p.id_condicion,
                p.co_cond,
                p.fec_emis,
                p.fec_venc,
                p.fec_reg,
                //FECHAINI = ((DateTime)p.fec_emis).ToShortDateString(),
                //FEVENC = ((DateTime)p.fec_venc).ToShortDateString(),
                //FECREG = ((DateTime)p.fec_reg).ToShortDateString(),
                p.anulado,
                p.status,
                p.total_bruto,
                p.monto_imp,
                p.monto_imp2,
                p.monto_imp3,
                p.total_neto,
                p.saldo,
                p.Direcionop,
                p.importado_web,
                p.importado_pro,
                p.Diasvencimiento,
                p.nro_pedido,
                p.vencida
            }).ToList();

            if (adcotizacion == null)
            {
                return NotFound();
            }

            return Ok(adcotizacion);
        }

        [Route("cotizacion/listarCotizacioncli/{cliente:int:min(1)}")]
        public IHttpActionResult GetAdcotizacionCliente(int cliente)
        {
            var listarcotizacion = db.Cotizaciones.Where(p => p.id_clientes.Equals(cliente)).Select(p => new
            {
                p.id_doc_num,
                p.doc_num,
                p.descrip,
                p.id_clientes,
                p.co_cli,
                p.idtransporte,
                p.co_tran,
                p.co_mone,
                p.id_vendedor,
                p.co_ven,
                p.id_condicion,
                p.co_cond,
                p.fec_emis,
                p.fec_venc,
                p.fec_reg,
                //FECHAINI = ((DateTime)p.fec_emis).ToShortDateString(),
                //FEVENC = ((DateTime)p.fec_venc).ToShortDateString(),
                //FECREG = ((DateTime)p.fec_reg).ToShortDateString(),
                p.anulado,
                p.status,
                p.total_bruto,
                p.monto_imp,
                p.monto_imp2,
                p.monto_imp3,
                p.total_neto,
                p.saldo,
                p.Direcionop,
                p.importado_web,
                p.importado_pro,
                p.Diasvencimiento,
                p.nro_pedido,
                p.vencida
            }).ToList();

            return Ok(listarcotizacion);
        }

        [Route("cotizacion/listarCotizacionCompleta")]
        public object GetAdcotizacionCompleta()
        {
            return (from cabezas in db.Cotizaciones
                    join renglones in db.RenglonesCotizacion
                    on cabezas.doc_num equals renglones.doc_num
                    select new
                    {
                        cabezas.id_condicion,
                        cabezas.doc_num,
                        cabezas.descrip,
                        cabezas.id_clientes,
                        cabezas.co_cli,
                        idcondicion = cabezas.id_condicion,
                        cabezas.co_cond,
                        cabezas.Diasvencimiento,
                        cabezas.id_vendedor,
                        cabezas.co_ven,
                        cabezas.idtransporte,
                        cabezas.fec_emis,
                        cabezas.fec_venc,
                        cabezas.fec_reg,
                        cabezas.anulado,
                        cabezas.status,
                        cabezas.total_bruto,
                        cabezas.monto_imp,
                        cabezas.total_neto,
                        cabezas.saldo,
                        cabezas.Direcionop,
                        renglones.reng_num,
                        renglones.id_art,
                        renglones.co_art,
                        renglones.art_des,
                        renglones.cod_unidad,
                        renglones.cod_almacen,
                        renglones.co_alma,
                        renglones.total_art,
                        renglones.stotal_art,
                        renglones.id_preciosart,
                        renglones.co_precios,
                        renglones.prec_vta,
                        renglones.prec_vta_om,
                        renglones.tipo_imp,
                        renglones.porc_imp,
                        IVA = renglones.monto_imp,
                        renglones.reng_neto,
                        renglones.tipo_doc,
                        renglones.num_doc,
                        renglones.tasa_v,
                        renglones.importado_pro,
                        renglones.importado_web
                    }).OrderBy(p => p.reng_num).ToList();
        }

        [Route("cotizacion/listarCotizacionCompletaco/{codigo:int:min(1)}")]
        public object GetAdcotizacionCompletaCodigo(int codigo)
        {
            var CotizacionCompleta = db.Cotizaciones.Find(codigo);
            if (CotizacionCompleta == null)
            {
                return NotFound();
            }

            var RenglonesCotizacion = db.RenglonesCotizacion.Where(r => r.doc_num == CotizacionCompleta.doc_num).ToList();
            CotizacionCompleta.RenglonesCotizacion = RenglonesCotizacion;

            return Ok(CotizacionCompleta);
            /*return (from cabezas in db.Cotizaciones
                    join renglones in db.RenglonesCotizacion
                    on cabezas.doc_num equals renglones.doc_num
                    where cabezas.id_doc_num.Equals(codigo)
                    select new
                    {
                        cabezas.id_condicion,
                        cabezas.doc_num,
                        cabezas.descrip,
                        cabezas.id_clientes,
                        cabezas.co_cli,
                        idcondicion = cabezas.id_condicion,
                        cabezas.co_cond,
                        cabezas.Diasvencimiento,
                        cabezas.id_vendedor,
                        cabezas.co_ven,
                        cabezas.idtransporte,
                        cabezas.fec_emis,
                        cabezas.fec_venc,
                        cabezas.fec_reg,
                        cabezas.anulado,
                        cabezas.status,
                        cabezas.total_bruto,
                        cabezas.monto_imp,
                        cabezas.total_neto,
                        cabezas.saldo,
                        cabezas.Direcionop,
                        renglones.reng_num,
                        renglones.id_art,
                        renglones.co_art,
                        renglones.art_des,
                        renglones.cod_unidad,
                        renglones.cod_almacen,
                        renglones.co_alma,
                        renglones.total_art,
                        renglones.stotal_art,
                        renglones.id_preciosart,
                        renglones.co_precios,
                        renglones.prec_vta,
                        renglones.prec_vta_om,
                        renglones.tipo_imp,
                        renglones.porc_imp,
                        IVA = renglones.monto_imp,
                        renglones.reng_neto,
                        renglones.tipo_doc,
                        renglones.num_doc,
                        renglones.importado_pro,
                        renglones.importado_web
                    }).OrderBy(p => p.reng_num).ToList();*/
        }

        // PUT: api/APICotizacion/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdcotizacion(int id, Adcotizacion adcotizacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adcotizacion.id_doc_num)
            {
                return BadRequest();
            }

            db.Entry(adcotizacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdcotizacionExists(id))
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
        // POST: cotizacion/guardarDatos
        [ResponseType(typeof(int))]
        public int CrearCotizacion(Adcotizacion adcotizacion)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }

            db.Cotizaciones.Add(adcotizacion);
            db.SaveChanges();

            return 1;
        }

        // POST: cotizacion/Guardate
        [HttpPost]
        [Route("cotizacion/Guardate")]
        [ResponseType(typeof(int))]
        public int CrearCotizacionRenglon(Adcotizacion cotizacionRenglon)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }

            // Invocar métodos para guardar Cotizaciones y Renglones de Cotización por separado.
            Adcotizacion cotizacion = new Adcotizacion();
            cotizacion.doc_num = cotizacionRenglon.doc_num;
            cotizacion.descrip = cotizacionRenglon.descrip;
            cotizacion.co_cli = cotizacionRenglon.co_cli;
            cotizacion.co_tran = cotizacionRenglon.co_tran;
            cotizacion.co_mone = cotizacionRenglon.co_mone;
            cotizacion.co_ven = cotizacionRenglon.co_ven;
            cotizacion.co_cond = cotizacionRenglon.co_cond;
            cotizacion.fec_emis = DateTime.Now;
            cotizacion.fec_venc = cotizacion.fec_emis.Value.AddDays((double) cotizacionRenglon.Diasvencimiento);
            cotizacion.fec_reg = DateTime.Now;
            cotizacion.anulado = cotizacionRenglon.anulado;
            cotizacion.status = cotizacionRenglon.status;
            cotizacion.total_bruto = cotizacionRenglon.total_bruto;
            cotizacion.monto_imp = cotizacionRenglon.monto_imp;
            cotizacion.monto_imp2 = cotizacionRenglon.monto_imp2;
            cotizacion.monto_imp3 = cotizacionRenglon.monto_imp3;
            cotizacion.total_neto = cotizacionRenglon.total_neto;
            cotizacion.saldo = cotizacionRenglon.saldo;
            cotizacion.Direcionop = cotizacionRenglon.Direcionop;
            cotizacion.importado_web = cotizacionRenglon.importado_web;
            cotizacion.importado_pro = cotizacionRenglon.importado_pro;
            cotizacion.Diasvencimiento = cotizacionRenglon.Diasvencimiento;
            cotizacion.nro_pedido = cotizacionRenglon.nro_pedido;
            cotizacion.vencida = cotizacionRenglon.vencida;
            cotizacion.id_clientes = cotizacionRenglon.id_clientes;
            cotizacion.idtransporte = cotizacionRenglon.idtransporte;
            cotizacion.id_vendedor = cotizacionRenglon.id_vendedor;
            cotizacion.id_condicion = cotizacionRenglon.id_condicion;
            
            ICollection<AdCotizacionreg> renglonesCotizacion = cotizacionRenglon.RenglonesCotizacion;

            int numeroRegistrosAfectados = 0;

            var instanciaControladorRenglones = new APIRenglonCotizacionController();
            decimal baseNeta = 0, valorIva = 0, totalMontoImpuesto = 0, totalMontoNeto = 0;

            decimal tasaDelDia = db.Tasas
                .Where(t => t.fecha.Value.CompareTo(cotizacion.fec_emis.Value) <= 0)
                .Select(t => (decimal) t.tasa_v)
                .ToList()
                .LastOrDefault();

            foreach (AdCotizacionreg renglon in renglonesCotizacion)
            {
                renglon.doc_num = cotizacion.doc_num;
                renglon.reng_num = renglon.reng_num;
                baseNeta = (decimal)(renglon.total_art * renglon.prec_vta);
                valorIva = (decimal)(renglon.porc_imp);
                renglon.monto_imp = baseNeta * (valorIva / 100);
                renglon.reng_neto = baseNeta + renglon.monto_imp;
                totalMontoImpuesto += (decimal)renglon.monto_imp;
                totalMontoNeto += (decimal)renglon.reng_neto;
                renglon.tasa_v = tasaDelDia;
                renglon.prec_vta_om = (tasaDelDia != 0) ? (renglon.prec_vta / tasaDelDia) : null;
                numeroRegistrosAfectados += instanciaControladorRenglones.CrearRenglonCotizacion(renglon);
            }

            cotizacion.total_bruto = totalMontoNeto - totalMontoImpuesto;
            cotizacion.monto_imp = totalMontoImpuesto;
            cotizacion.total_neto = totalMontoNeto;
            cotizacion.saldo = totalMontoNeto;

            numeroRegistrosAfectados += CrearCotizacion(cotizacion);

            return cotizacion.id_doc_num;
        }

        // POST: api/APICotizacion
        [HttpPost]
        [Route("cotizacion/guardarDatos")]
        [ResponseType(typeof(Adcotizacion))]
        public IHttpActionResult PostAdcotizacion(Adcotizacion adcotizacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            adcotizacion.fec_emis = DateTime.Now;
            adcotizacion.fec_venc = adcotizacion.fec_emis.Value.AddDays((double)adcotizacion.Diasvencimiento);
            adcotizacion.fec_reg = DateTime.Now;

            db.Cotizaciones.Add(adcotizacion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adcotizacion.id_doc_num }, adcotizacion);
        }

        // DELETE: api/APICotizacion/5
        [ResponseType(typeof(Adcotizacion))]
        public IHttpActionResult DeleteAdcotizacion(int id)
        {
            Adcotizacion adcotizacion = db.Cotizaciones.Find(id);
            if (adcotizacion == null)
            {
                return NotFound();
            }

            db.Cotizaciones.Remove(adcotizacion);
            db.SaveChanges();

            return Ok(adcotizacion);
        }

        [HttpGet]
        [Route("cotizaciones/actualizar")]
        public IHttpActionResult ActualizarCotizacionesProfit()
        {
            ProfitEntities profitContext = new ProfitEntities();
            IQueryable<Adcotizacion> cotizaciones = db.Cotizaciones;

            foreach (Adcotizacion cotizacion in cotizaciones)
            {
                // Tablas de las que depende Cotización.
                saCotizacionCliente cotizacionProfit = profitContext.saCotizacionCliente.Where(c => c.doc_num == cotizacion.doc_num).FirstOrDefault();
                pSeleccionarTransporte_Result transporteProfit = profitContext.pSeleccionarTransporte(cotizacion.co_tran).FirstOrDefault();
                pSeleccionarMoneda_Result monedaProfit = profitContext.pSeleccionarMoneda(cotizacion.co_mone).FirstOrDefault();
                pSeleccionarCondicionPago_Result condicionPagoProfit = profitContext.pSeleccionarCondicionPago(cotizacion.co_cond).FirstOrDefault();

                Adtransporte transporte = cotizacion.Transporte;
                AdMoneda moneda = db.Monedas.Where(m => m.co_mone == cotizacion.co_mone).FirstOrDefault();
                Adcondiciondepago condicionPago = cotizacion.CondicionDePago;

                if (transporteProfit != null)
                {
                    byte[] validador = transporteProfit.validador;
                    profitContext.pActualizarTransporte(
                        transporte.co_tran, transporte.co_tran, transporte.des_tran, transporteProfit.resp_tra, transporteProfit.dis_cen, transporteProfit.campo1, transporteProfit.campo2,
                        transporteProfit.campo3, transporteProfit.campo4, transporteProfit.campo5, transporteProfit.campo6, transporteProfit.campo7, transporteProfit.campo8, transporteProfit.co_us_mo,
                        transporteProfit.co_sucu_mo, null, null, transporteProfit.revisado, transporteProfit.trasnfe, validador, null
                    );
                }
                else
                {
                    profitContext.pInsertarTransporte(
                        transporte.co_tran, transporte.des_tran, null, null, null, null, null, null, null, null, null, null, "", null, null, null, null
                    );
                }

                if (monedaProfit != null)
                {
                    byte[] validador = monedaProfit.validador;
                    profitContext.pActualizarMoneda(
                        moneda.co_mone, moneda.co_mone, moneda.mone_des, monedaProfit.cambio, monedaProfit.relacion, monedaProfit.campo1, monedaProfit.campo2, monedaProfit.campo3, monedaProfit.campo4,
                        monedaProfit.campo5, monedaProfit.campo6, monedaProfit.campo7, monedaProfit.campo8, monedaProfit.co_us_mo, monedaProfit.co_sucu_mo, null, null, monedaProfit.revisado,
                        monedaProfit.trasnfe, validador, null
                    );
                }
                else
                {
                    profitContext.pInsertarMoneda(
                        moneda.co_mone, moneda.mone_des, 0, false, null, null, null, null, null, null, null, null, "", null, null, null, null
                    );
                }

                if (condicionPagoProfit != null)
                {
                    byte[] validador = condicionPagoProfit.validador;
                    profitContext.pActualizarCondicionPago(
                        condicionPago.co_cond, condicionPago.co_cond, condicionPago.cond_des, condicionPago.dias_cred, condicionPagoProfit.dis_cen, condicionPagoProfit.campo1, condicionPagoProfit.campo2,
                        condicionPagoProfit.campo3, condicionPagoProfit.campo4, condicionPagoProfit.campo5, condicionPagoProfit.campo6, condicionPagoProfit.campo7, condicionPagoProfit.campo8,
                        condicionPagoProfit.co_us_mo, condicionPagoProfit.co_sucu_mo, null, null, condicionPagoProfit.revisado, condicionPagoProfit.trasnfe, validador, null
                    );
                }
                else
                {
                    profitContext.pInsertarCondicionPago(
                        condicionPago.co_cond, condicionPago.cond_des, condicionPago.dias_cred, null, null, null, null, null, null, null, null, null, "",
                        null, null, null, null
                    );
                }

                if (cotizacionProfit != null)
                {
                    byte[] validador = cotizacionProfit.validador;
                    profitContext.pActualizarCotizacionCliente(
                        cotizacion.doc_num, cotizacion.doc_num, cotizacion.descrip, cotizacion.co_cli, cotizacionProfit.co_cta_ingr_egr, cotizacion.co_tran, cotizacion.co_mone, cotizacion.co_ven,
                        cotizacion.co_cond, cotizacion.fec_emis, cotizacion.fec_venc, cotizacion.fec_reg, cotizacion.anulado == "1", cotizacion.status, cotizacionProfit.tasa, cotizacionProfit.n_control,
                        cotizacion.doc_num, cotizacionProfit.porc_desc_glob, cotizacionProfit.monto_desc_glob, cotizacionProfit.porc_reca, cotizacionProfit.monto_reca, cotizacion.saldo, cotizacion.total_bruto,
                        cotizacion.monto_imp, cotizacion.monto_imp2, cotizacion.monto_imp3, cotizacionProfit.otros1, cotizacionProfit.otros2, cotizacionProfit.otros3, cotizacion.total_neto, cotizacionProfit.comentario,
                        cotizacionProfit.dir_ent, cotizacionProfit.contrib, cotizacionProfit.impresa, cotizacionProfit.salestax, cotizacionProfit.impfis, cotizacionProfit.impfisfac, cotizacionProfit.ven_ter,
                        cotizacionProfit.dis_cen, cotizacionProfit.campo1, cotizacionProfit.campo2, cotizacionProfit.campo3, cotizacionProfit.campo4, cotizacionProfit.campo5, cotizacionProfit.campo6,
                        cotizacionProfit.campo7, cotizacionProfit.campo8, cotizacionProfit.co_us_mo, cotizacionProfit.co_sucu_mo, cotizacionProfit.revisado, cotizacionProfit.trasnfe, null, validador, null, null
                    );
                }
                else
                {
                    profitContext.pInsertarCotizacionCliente(
                        cotizacion.doc_num, cotizacion.descrip, cotizacion.co_cli, null, cotizacion.co_tran, cotizacion.co_mone, cotizacion.co_ven,
                        cotizacion.co_cond, cotizacion.fec_emis, cotizacion.fec_venc, cotizacion.fec_reg, cotizacion.anulado == "1", cotizacion.status, 1, null,
                        cotizacion.doc_num, null, 0, null, 0, cotizacion.saldo, cotizacion.total_bruto, cotizacion.monto_imp, cotizacion.monto_imp2, 
                        cotizacion.monto_imp3, 0, 0, 0, cotizacion.total_neto, null, null, null, false, false, null, null, null, false, null, 
                        null, null, null, null, null, null, null, "", null, null, null, null
                    );
                }
            }

            APIRenglonCotizacionController apiRenglonCotizacion = new APIRenglonCotizacionController();
            apiRenglonCotizacion.ActualizarRenglonesCotizacionesProfit();

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

        private bool AdcotizacionExists(int id)
        {
            return db.Cotizaciones.Count(e => e.id_doc_num == id) > 0;
        }
    }
}