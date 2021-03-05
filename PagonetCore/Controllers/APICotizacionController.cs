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
        public IQueryable<Adcotizacion> GetCotizaciones()
        {
            return db.Cotizaciones;
        }

        // GET: api/APICotizacion/5
        [Route("cotizacion/listarcotizacionid/{id:int:min(1)}")]
        [ResponseType(typeof(Adcotizacion))]
        public IHttpActionResult GetAdcotizacion(int id)
        {
            Adcotizacion adcotizacion = db.Cotizaciones.Find(id);
            if (adcotizacion == null)
            {
                return NotFound();
            }

            return Ok(adcotizacion);
        }

        [Route("cotizacion/listarCotizacioncli/{cliente:int:min(1)}")]
        public object GetAdcotizacionCliente(int cliente)
        {
            return db.Cotizaciones.Where(p => p.id_clientes.Equals(cliente)).Select(p => new
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
                p.anulado,
                p.status,
                p.total_bruto,
                p.monto_imp,
                p.monto_imp2,
                p.monto_imp3,
                p.total_neto,
                p.saldo,
                p.importado_web,
                p.importado_pro,
                p.Diasvencimiento,
                p.nro_pedido,
                p.vencida
            }).ToList();
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
                    }).OrderBy(p => p.reng_num).ToList();
        }

        [Route("cotizacion/listarCotizacionCompletaco/{codigo:int:min(1)}")]
        public object GetAdcotizacionCompletaCodigo(int codigo)
        {
            return (from cabezas in db.Cotizaciones
                    join renglones in db.RenglonesCotizacion
                    on cabezas.id_doc_num equals (renglones.doc_num)
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
                    }).OrderBy(p => p.reng_num).ToList();
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

            // TODO: Actualizar Renglones de Cotización.
            foreach (Adcotizacion cotizacion in cotizaciones)
            {
                // Tablas de las que depende Cotización.
                pSeleccionarCliente_Result clienteProfit = profitContext.pSeleccionarCliente(cotizacion.co_cli).FirstOrDefault();
                pSeleccionarTransporte_Result transporteProfit = profitContext.pSeleccionarTransporte(cotizacion.co_tran).FirstOrDefault();
                pSeleccionarMoneda_Result monedaProfit = profitContext.pSeleccionarMoneda(cotizacion.co_mone).FirstOrDefault();
                pSeleccionarVendedor_Result vendedorProfit = profitContext.pSeleccionarVendedor(cotizacion.co_ven).FirstOrDefault();
                pSeleccionarCondicionPago_Result condicionPagoProfit = profitContext.pSeleccionarCondicionPago(cotizacion.co_cond).FirstOrDefault();

                Adclientes cliente = cotizacion.Cliente;
                Adtransporte transporte = cotizacion.Transporte;
                AdMoneda moneda = db.Monedas.Where(m => m.co_mone == cotizacion.co_mone).FirstOrDefault();
                Advendedor vendedor = cotizacion.Vendedor;
                Adcondiciondepago condicionPago = cotizacion.CondicionDePago;

                if (clienteProfit != null)
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
                }

                if (transporteProfit != null)
                {
                    byte[] validador = transporteProfit.validador;
                    profitContext.pActualizarTransporte(
                        transporte.co_tran, transporte.co_tran, transporte.des_tran, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, validador, null
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
                        moneda.co_mone, moneda.co_mone, moneda.mone_des, 0, false, null, null, null, null, null, null, null, null, null, null, null, null, null, null, validador, null
                    );
                }
                else
                {
                    profitContext.pInsertarMoneda(
                        moneda.co_mone, moneda.mone_des, 0, false, null, null, null, null, null, null, null, null, "", null, null, null, null
                    );
                }

                if (vendedorProfit != null)
                {
                    byte[] validador = vendedorProfit.validador;
                    profitContext.pActualizarVendedor(
                        vendedor.co_ven, vendedor.co_ven, vendedor.tipo, vendedor.ven_des, null, null, null, null, null, DateTime.Now, false, 0, null, false, false, 0, null, null, null, null,
                        null, null, null, null, null, null, null, null, null, null, null, null, null, null, validador, null, vendedor.co_zon
                    );
                }
                else
                {
                    profitContext.pInsertarVendedor(
                        vendedor.co_ven, vendedor.tipo, vendedor.ven_des, null, null, null, null, null, DateTime.Now, false, 0, null, false, false, 0, null, null, null, null,
                        null, null, null, null, null, null, null, null, "", null, null, null, null, vendedor.co_zon
                    );
                }

                if (condicionPagoProfit != null)
                {
                    byte[] validador = condicionPagoProfit.validador;
                    profitContext.pActualizarCondicionPago(
                        condicionPago.co_cond, condicionPago.co_cond, condicionPago.cond_des, condicionPago.dias_cred, null, null, null, null, null, null, null, null, null, null,
                        null, null, null, null, null, validador, null
                    );
                }
                else
                {
                    profitContext.pInsertarCondicionPago(
                        condicionPago.co_cond, condicionPago.cond_des, condicionPago.dias_cred, null, null, null, null, null, null, null, null, null, "",
                        null, null, null, null
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

        private bool AdcotizacionExists(int id)
        {
            return db.Cotizaciones.Count(e => e.id_doc_num == id) > 0;
        }
    }
}