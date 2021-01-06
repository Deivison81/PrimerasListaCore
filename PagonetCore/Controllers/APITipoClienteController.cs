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
    public class APITipoClienteController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APITipoCliente
        public IQueryable<Adtipo_cliente> GetTiposCliente()
        {
            return db.TiposCliente;
        }

        // GET: api/APITipoCliente/5
        [ResponseType(typeof(Adtipo_cliente))]
        public IHttpActionResult GetAdtipo_cliente(int id)
        {
            Adtipo_cliente adtipo_cliente = db.TiposCliente.Find(id);
            if (adtipo_cliente == null)
            {
                return NotFound();
            }

            return Ok(adtipo_cliente);
        }

        // PUT: api/APITipoCliente/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdtipo_cliente(int id, Adtipo_cliente adtipo_cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adtipo_cliente.id_tipocliente)
            {
                return BadRequest();
            }

            db.Entry(adtipo_cliente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Adtipo_clienteExists(id))
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

        // POST: api/APITipoCliente
        [ResponseType(typeof(Adtipo_cliente))]
        public IHttpActionResult PostAdtipo_cliente(Adtipo_cliente adtipo_cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TiposCliente.Add(adtipo_cliente);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adtipo_cliente.id_tipocliente }, adtipo_cliente);
        }

        // DELETE: api/APITipoCliente/5
        [ResponseType(typeof(Adtipo_cliente))]
        public IHttpActionResult DeleteAdtipo_cliente(int id)
        {
            Adtipo_cliente adtipo_cliente = db.TiposCliente.Find(id);
            if (adtipo_cliente == null)
            {
                return NotFound();
            }

            db.TiposCliente.Remove(adtipo_cliente);
            db.SaveChanges();

            return Ok(adtipo_cliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Adtipo_clienteExists(int id)
        {
            return db.TiposCliente.Count(e => e.id_tipocliente == id) > 0;
        }
    }
}