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
    public class APIVendedorController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APIVendedor
        [Route("Vendedor/listarVendedor")]
        public IQueryable<Advendedor> GetVendedores()
        {
            return db.Vendedores;
        }

        // GET: Cotizacion/listarVendedor
        // NOTA:
        // Esto se colocó para compatibilidad con rutas anteriores, pero no es apropiado, puesto
        // que la ruta incluye 'Cotización' en su URL, y esto es completamente 
        // y únicamente relacionado a Vendedor.
        [Route("Cotizacion/listarVendedor")]
        public IHttpActionResult GetVendedoresCotizacion()
        {
            return Json(db.Vendedores.Select(x => new
            {
                IID = x.id_vendedor,
                CODIGO = x.co_ven,
                NOMBRE = x.ven_des
            }));
        }

        // GET: api/APIVendedor/5
        [Route("Vendedor/listarVendedores/{id:int:min(1)}")]
        [ResponseType(typeof(Advendedor))]
        public IHttpActionResult GetAdvendedor(int id)
        {
            Advendedor advendedor = db.Vendedores.Find(id);
            if (advendedor == null)
            {
                return NotFound();
            }

            return Ok(advendedor);
        }

        // PUT: api/APIVendedor/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdvendedor(int id, Advendedor advendedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != advendedor.id_vendedor)
            {
                return BadRequest();
            }

            db.Entry(advendedor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvendedorExists(id))
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

        // POST: api/APIVendedor
        [ResponseType(typeof(Advendedor))]
        public IHttpActionResult PostAdvendedor(Advendedor advendedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vendedores.Add(advendedor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = advendedor.id_vendedor }, advendedor);
        }

        // DELETE: api/APIVendedor/5
        [ResponseType(typeof(Advendedor))]
        public IHttpActionResult DeleteAdvendedor(int id)
        {
            Advendedor advendedor = db.Vendedores.Find(id);
            if (advendedor == null)
            {
                return NotFound();
            }

            db.Vendedores.Remove(advendedor);
            db.SaveChanges();

            return Ok(advendedor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdvendedorExists(int id)
        {
            return db.Vendedores.Count(e => e.id_vendedor == id) > 0;
        }
    }
}