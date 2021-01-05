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
    public class APIClienteController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APICliente
        public IQueryable<Adclientes> GetClientes()
        {
            return db.Clientes;
        }

        // GET: api/APICliente/5
        [ResponseType(typeof(Adclientes))]
        public IHttpActionResult GetAdclientes(int id)
        {
            Adclientes adclientes = db.Clientes.Find(id);
            if (adclientes == null)
            {
                return NotFound();
            }

            return Ok(adclientes);
        }

        // PUT: api/APICliente/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdclientes(int id, Adclientes adclientes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adclientes.id_clientes)
            {
                return BadRequest();
            }

            db.Entry(adclientes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdclientesExists(id))
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

        // POST: api/APICliente
        [ResponseType(typeof(Adclientes))]
        public IHttpActionResult PostAdclientes(Adclientes adclientes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clientes.Add(adclientes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adclientes.id_clientes }, adclientes);
        }

        // DELETE: api/APICliente/5
        [ResponseType(typeof(Adclientes))]
        public IHttpActionResult DeleteAdclientes(int id)
        {
            Adclientes adclientes = db.Clientes.Find(id);
            if (adclientes == null)
            {
                return NotFound();
            }

            db.Clientes.Remove(adclientes);
            db.SaveChanges();

            return Ok(adclientes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdclientesExists(int id)
        {
            return db.Clientes.Count(e => e.id_clientes == id) > 0;
        }
    }
}