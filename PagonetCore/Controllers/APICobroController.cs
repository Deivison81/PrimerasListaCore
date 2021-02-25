﻿using System;
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
        [ResponseType(typeof(AdCobros))]
        public IHttpActionResult GetAdCobros(int id)
        {
            AdCobros adCobros = db.Cobros.Find(id);
            if (adCobros == null)
            {
                return NotFound();
            }

            return Ok(adCobros);
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

            return 1;
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

            return numeroRegistrosAfectados;
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