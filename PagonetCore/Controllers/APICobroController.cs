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
    public class APICobroController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        
        // GET: api/APICobro
        public IQueryable<AdCobros> GetCobros()
        {
            return db.Cobros;
        }

        // GET: api/APICobro/5
        [Route("cobros/listarcobro/{id_cob:int:min(1)}")]
        [ResponseType(typeof(AdCobros))]
        public IHttpActionResult GetAdCobros(int id_cob)
        {
            AdCobros adCobros = db.Cobros.Find(id_cob);
            if (adCobros == null)
            {
                return NotFound();
            }
          
           return Ok(adCobros);
        }
        //cuerpo
        [HttpGet]
        [Route("cobros/listarrenglonescobro/{id_cob:int:min(1)}")]
        public object GetAdRenglonesCobroxcobro(int id_cob)

        {
            int cantidadrenglon = db.RenglonesCobro.Where(p => p.id_cob.Equals(id_cob)).Select(p => new { p.reng_num }).Count();


            var listarrenglonescobros = db.RenglonesCobro.Where(p => p.id_cob.Equals(id_cob)).Select(p => new {
                p.idrencob,
                p.reng_num,
                p.id_cob,
                p.cob_num_pro,
                p.co_tipo_doc,
                p.nro_doc,
                p.mont_cob,
                p.dpcobro_monto,
                p.tipo_doc,
                p.num_doc,
                p.saldo,
                p.importado_web,
                p.importado_pro

            }).OrderByDescending(p => p.reng_num).ToList();


            if (!ModelState.IsValid)
            {
                return NotFound();


            }

            return listarrenglonescobros;

        }
        //forma de pago

        [HttpGet]
        [Route("cobros/listarrenglonesformadecobro/{id_cob:int:min(1)}")]
        public object GetAdFormasCobroxcobro(int id_cob)
        {
            var listarformadepagos = db.FormasCobro.Where(p => p.id_cob.Equals(id_cob)).Select(p => new
            {

                p.forma_cob_id,
                p.nro_reng,
                p.id_cob,
                p.cob_num_pro,
                p.co_ban,
                p.forma_pag,
                p.cod_cta,
                p.cod_caja,
                p.mov_num_c,
                p.mov_num_b,
                p.mont_doc,
                p.dolar,
                p.importado_web,
                p.importado_pro

            }).OrderByDescending(p => p.id_cob).ToList();

            if (!ModelState.IsValid)
            {
                return NotFound();


            }

            return listarformadepagos;

        }

        [HttpGet]
        [Route("cobros/listarcobrocompleto/{id_cob:int:min(1)}")]
        [ResponseType(typeof(IHttpActionResult))]
        public IHttpActionResult GetAdCobroscompletos(int id_cob) 
        {
            //var Cabecera = GetAdCobros(id_cob);
            //var Cuerpo = GetAdRenglonesCobroxcobro(id_cob);
            //var forma = GetAdFormasCobroxcobro(id_cob);
            //var cobrototal = 0;
            //return cobrototal;

            var CobroCompleto = (from cabezas in db.Cobros
             join renglones in db.RenglonesCobro
             on cabezas.id_cob equals renglones.id_cob
             join formas in db.FormasCobro
             on cabezas.id_cob equals formas.id_cob
             select new
             {
                 cabezas.id_cob,
                 cabezas.cob_num_pro,
                 cabezas.id_clientes,
                 cabezas.co_cli,
                 cabezas.co_mone,
                 cabezas.id_vendedor,
                 cabezas.co_ven,
                 cabezas.tasa,
                 cabezas.fecha,
                 cabezas.anulado,
                 cabezas.monto,
                 cabezas.importado_web,
                 cabezas.importado_pro,
                 renglones.idrencob,
                 renglones.reng_num,
                 renglon_id_cob = renglones.id_cob,
                 renglon_cob_num_pro = renglones.cob_num_pro,
                 renglones.co_tipo_doc,
                 renglones.nro_doc,
                 renglones.mont_cob,
                 renglones.dpcobro_monto,
                 renglones.tipo_doc,
                 renglones.num_doc,
                 renglones.saldo,
                 renglones_importado_web = renglones.importado_web,
                 renglones_importado_pro = renglones.importado_pro,
                 formas.forma_cob_id,
                 formas.nro_reng,
                 forma_id_cob = formas.id_cob,
                 forma_cob_num_pro = formas.cob_num_pro,
                 formas.co_ban,
                 formas.forma_pag,
                 formas.cod_cta,
                 formas.cod_caja,
                 formas.mov_num_c,
                 formas.mov_num_b,
                 formas.mont_doc,
                 formas.dolar,
                 forma_importado_web = formas.importado_web,
                 forma_importado_pro = formas.importado_pro
             })
             .OrderByDescending(cobro => cobro.id_cob)
             .ToList();

            return Ok(CobroCompleto);
        }

        // PUT: api/APICobro/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdCobros(int id, AdCobros adCobros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adCobros.id_cob)
            {
                return BadRequest();
            }

            db.Entry(adCobros).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdCobrosExists(id))
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

        // POST: api/APICobro
        [ResponseType(typeof(AdCobros))]
        public IHttpActionResult PostAdCobros(AdCobros adCobros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cobros.Add(adCobros);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adCobros.id_cob }, adCobros);
        }

        // DELETE: api/APICobro/5
        [ResponseType(typeof(AdCobros))]
        public IHttpActionResult DeleteAdCobros(int id)
        {
            AdCobros adCobros = db.Cobros.Find(id);
            if (adCobros == null)
            {
                return NotFound();
            }

            db.Cobros.Remove(adCobros);
            db.SaveChanges();

            return Ok(adCobros);
        }

        // Nota: Este método retorna el número de registros afectados por la petición.
        // POST: cobros
        [HttpPost]
        [Route("cobros")]
        [ResponseType(typeof(int))]
        public int CrearCobro(AdCobros cobro)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }

            db.Cobros.Add(cobro);
            db.SaveChanges();

            return cobro.id_cob;
        }

        // Nota: Este método retorna el número de registros afectados por la petición.
        // POST: cobros/completo
        [HttpPost]
        [Route("cobros/completo")]
        [ResponseType(typeof(int))]
        public int CrearCobroCompleto(AdCobros cobroCompleto)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }

            AdCobros cobro = new AdCobros();
            cobro.cob_num_pro = cobroCompleto.cob_num_pro;
            cobro.id_clientes = cobroCompleto.id_clientes;
            cobro.co_cli = cobroCompleto.co_cli;
            cobro.co_mone = cobroCompleto.co_mone;
            cobro.id_vendedor = cobroCompleto.id_vendedor;
            cobro.co_ven = cobroCompleto.co_ven;
            cobro.tasa = cobroCompleto.tasa;
            cobro.fecha = cobroCompleto.fecha;
            cobro.anulado = cobroCompleto.anulado;
            cobro.monto = cobroCompleto.monto;
            cobro.importado_web = cobroCompleto.importado_web;
            cobro.importado_pro = cobroCompleto.importado_pro;

            int numeroRegistrosAfectados = 0;
            var instanciaControladorRenglones = new APIRenglonCobroController();
            var instanciaControladorFormasCobro = new APIFormaCobroController();

            numeroRegistrosAfectados += this.CrearCobro(cobro);

            ICollection<AdRenglonesCobro> renglonesCobro = cobroCompleto.RenglonesCobro;
            ICollection<AdFormasCobro> formasCobro = cobroCompleto.FormasCobro;

            foreach (AdRenglonesCobro renglon in renglonesCobro)
            {
                numeroRegistrosAfectados += instanciaControladorRenglones.CrearRenglonCobro(renglon);
            }

            foreach (AdFormasCobro forma in formasCobro)
            {
                numeroRegistrosAfectados += instanciaControladorFormasCobro.CrearFormaCobro(forma);
            }

            return cobro.id_cob;
        }

        [HttpGet]
        [Route("cobros/actualizar")]
        public IHttpActionResult ActualizarCobrosProfit()
        {
            ProfitEntities profitContext = new ProfitEntities();
            IQueryable<AdCobros> cobros = db.Cobros;

            foreach (AdCobros cobro in cobros)
            {
                pSeleccionarCobro_Result cobroProfit = profitContext.pSeleccionarCobro(cobro.cob_num_pro).FirstOrDefault();

                if (cobroProfit != null)
                {
                    byte[] validador = cobroProfit.validador;
                    profitContext.pActualizarCobro(
                        cobro.cob_num_pro, cobro.cob_num_pro, cobroProfit.recibo, cobro.co_cli, cobro.co_ven, cobro.co_mone, cobro.tasa, cobro.fecha, cobro.anulado == "1", cobro.monto, cobroProfit.dis_cen,
                        cobroProfit.descrip, cobroProfit.campo1, cobroProfit.campo2, cobroProfit.campo3, cobroProfit.campo4, cobroProfit.campo5, cobroProfit.campo6, cobroProfit.campo7, cobroProfit.campo8,
                        cobroProfit.co_us_mo, cobroProfit.co_sucu_mo, cobroProfit.revisado, cobroProfit.trasnfe, validador, null, null, null
                    );
                }
                else
                {
                    profitContext.pInsertarCobro(
                        cobro.cob_num_pro, null, cobro.co_cli, cobro.co_ven, cobro.co_mone, cobro.tasa, cobro.fecha, cobro.anulado == "1", cobro.monto, null, 
                        null, null, null, null, null, null, null, null, null, "", null, null, null, null
                    );
                }
            }

            APIRenglonCobroController apiRenglonCobro = new APIRenglonCobroController();
            APIFormaCobroController apiFormaCobro = new APIFormaCobroController();
            apiRenglonCobro.ActualizarRenglonesCobrosProfit();
            apiFormaCobro.ActualizarFormasCobrosProfit();

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

        private bool AdCobrosExists(int id)
        {
            return db.Cobros.Count(e => e.id_cob == id) > 0;
        }
    }
}