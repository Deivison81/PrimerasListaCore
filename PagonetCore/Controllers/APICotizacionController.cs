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
        [HttpPost]
        [Route("cotizacion/guardarDatos")]
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

        // Nota: Este método retorna el número de registros afectados por la petición.
        // POST: CotizacionCompleta/Create
        [HttpPost]
        [Route("CotizacionCompleta/Create")]
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

            return numeroRegistrosAfectados;
        }

        // POST: api/APICotizacion
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