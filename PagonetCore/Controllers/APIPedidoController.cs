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
    public class APIPedidoController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APIPedido
        public IQueryable<Adpedidos> GetPedidos()
        {
            return db.Pedidos;
        }

        // GET: api/APIPedido/5
        [ResponseType(typeof(Adpedidos))]
        public IHttpActionResult GetAdpedidos(int id)
        {
            Adpedidos adpedidos = db.Pedidos.Find(id);
            if (adpedidos == null)
            {
                return NotFound();
            }

            return Ok(adpedidos);
        }

        // PUT: api/APIPedido/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdpedidos(int id, Adpedidos adpedidos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adpedidos.id_doc_num)
            {
                return BadRequest();
            }

            db.Entry(adpedidos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdpedidosExists(id))
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

        // POST: api/APIPedido
        [ResponseType(typeof(Adpedidos))]
        public IHttpActionResult PostAdpedidos(Adpedidos adpedidos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pedidos.Add(adpedidos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adpedidos.id_doc_num }, adpedidos);
        }

        // DELETE: api/APIPedido/5
        [ResponseType(typeof(Adpedidos))]
        public IHttpActionResult DeleteAdpedidos(int id)
        {
            Adpedidos adpedidos = db.Pedidos.Find(id);
            if (adpedidos == null)
            {
                return NotFound();
            }

            db.Pedidos.Remove(adpedidos);
            db.SaveChanges();

            return Ok(adpedidos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdpedidosExists(int id)
        {
            return db.Pedidos.Count(e => e.id_doc_num == id) > 0;
        }
    }
}