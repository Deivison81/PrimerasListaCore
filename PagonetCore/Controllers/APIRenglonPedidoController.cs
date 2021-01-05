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
    public class APIRenglonPedidoController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APIRenglonPedido
        public IQueryable<AdPedidosreg> GetRenglonesPedidos()
        {
            return db.RenglonesPedidos;
        }

        // GET: api/APIRenglonPedido/5
        [ResponseType(typeof(AdPedidosreg))]
        public IHttpActionResult GetAdPedidosreg(int id)
        {
            AdPedidosreg adPedidosreg = db.RenglonesPedidos.Find(id);
            if (adPedidosreg == null)
            {
                return NotFound();
            }

            return Ok(adPedidosreg);
        }

        // PUT: api/APIRenglonPedido/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdPedidosreg(int id, AdPedidosreg adPedidosreg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adPedidosreg.reng_num)
            {
                return BadRequest();
            }

            db.Entry(adPedidosreg).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdPedidosregExists(id))
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

        // POST: api/APIRenglonPedido
        [ResponseType(typeof(AdPedidosreg))]
        public IHttpActionResult PostAdPedidosreg(AdPedidosreg adPedidosreg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RenglonesPedidos.Add(adPedidosreg);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adPedidosreg.reng_num }, adPedidosreg);
        }

        // DELETE: api/APIRenglonPedido/5
        [ResponseType(typeof(AdPedidosreg))]
        public IHttpActionResult DeleteAdPedidosreg(int id)
        {
            AdPedidosreg adPedidosreg = db.RenglonesPedidos.Find(id);
            if (adPedidosreg == null)
            {
                return NotFound();
            }

            db.RenglonesPedidos.Remove(adPedidosreg);
            db.SaveChanges();

            return Ok(adPedidosreg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdPedidosregExists(int id)
        {
            return db.RenglonesPedidos.Count(e => e.reng_num == id) > 0;
        }
    }
}