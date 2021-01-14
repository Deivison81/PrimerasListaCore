using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using PagonetCore.DAL;
using PagonetCore.Models;

namespace PagonetCore.Controllers
{
    public class APICotizacionRenglonController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // NOTA:
        // Este Controlador se utiliza como utilidad para guardar cotizaciones y renglones
        // en una misma petición HTTP.

        // PUT: api/APICotizacionRenglon/5
        /*[ResponseType(typeof(void))]
        public IHttpActionResult PutCotizacionRenglon(int id, CotizacionRenglon cotizacionRenglon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cotizacionRenglon.id)
            {
                return BadRequest();
            }

            db.Entry(cotizacionRenglon).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CotizacionRenglonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }*/

        // POST: api/APICotizacionRenglon
        [ResponseType(typeof(JsonResult<CotizacionRenglon>))]
        public IHttpActionResult PostCotizacionRenglon(CotizacionRenglon cotizacionRenglon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
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
            cotizacion.fec_emis = cotizacionRenglon.fec_emis;
            cotizacion.fec_venc = cotizacionRenglon.fec_venc;
            cotizacion.fec_reg = cotizacionRenglon.fec_reg;
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

            new APICotizacionController().PostAdcotizacion(cotizacion);

            var instanciaControladorRenglones = new APIRenglonCotizacionController();
            foreach (AdCotizacionreg renglon in renglonesCotizacion)
            {
                instanciaControladorRenglones.PostAdCotizacionreg(renglon);
            }

            return Json(cotizacionRenglon);
        }

        /*private bool CotizacionRenglonExists(int id)
        {
            return db.CotizacionRenglons.Count(e => e.id == id) > 0;
        }*/
    }
}