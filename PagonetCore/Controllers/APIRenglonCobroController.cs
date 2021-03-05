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

        /*[HttpGet]
        [Route("renglones-cobros/actualizar")]
        public IHttpActionResult ActualizarRenglonesCobrosProfit()
        {
            ProfitEntities profitContext = new ProfitEntities();
            IQueryable<AdRenglonesCobro> renglonesCobros = db.RenglonesCobro;

            foreach (AdRenglonesCobro renglon in renglonesCobros)
            {
                // Tablas de las que depende Renglones de Cobro.
                // TODO: Incompleto.
                // TODO: Importar Cobro de Profit (Stored Procedures).
                // TODO: Esto requiere co_tipo_doc y nro_doc (de saDocumentoVenta).
                pSeleccionarCliente_Result clienteProfit = profitContext.pSeleccionarCliente(cobro.co_cli).FirstOrDefault();
                pSeleccionarVendedor_Result vendedorProfit = profitContext.pSeleccionarVendedor(cobro.co_ven).FirstOrDefault();
                pSeleccionarMoneda_Result monedaProfit = profitContext.pSeleccionarMoneda(cobro.co_mone).FirstOrDefault();

                Adclientes cliente = db.Clientes.Where(c => c.co_cli == cobro.co_cli).FirstOrDefault();
                Advendedor vendedor = db.Vendedores.Where(v => v.co_ven == cobro.co_ven).FirstOrDefault();
                AdMoneda moneda = db.Monedas.Where(m => m.co_mone == cobro.co_mone).FirstOrDefault();

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
            }

            return Ok(true);
        }*/

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