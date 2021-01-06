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
    public class APITransporteController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APITransporte
        public IQueryable<Adtransporte> GetTransportes()
        {
            return db.Transportes;
        }

        // GET: api/APITransporte/5
        [ResponseType(typeof(Adtransporte))]
        public IHttpActionResult GetAdtransporte(int id)
        {
            Adtransporte adtransporte = db.Transportes.Find(id);
            if (adtransporte == null)
            {
                return NotFound();
            }

            return Ok(adtransporte);
        }

        // PUT: api/APITransporte/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdtransporte(int id, Adtransporte adtransporte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adtransporte.idtransporte)
            {
                return BadRequest();
            }

            db.Entry(adtransporte).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdtransporteExists(id))
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

        // POST: api/APITransporte
        [ResponseType(typeof(Adtransporte))]
        public IHttpActionResult PostAdtransporte(Adtransporte adtransporte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Transportes.Add(adtransporte);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adtransporte.idtransporte }, adtransporte);
        }

        // DELETE: api/APITransporte/5
        [ResponseType(typeof(Adtransporte))]
        public IHttpActionResult DeleteAdtransporte(int id)
        {
            Adtransporte adtransporte = db.Transportes.Find(id);
            if (adtransporte == null)
            {
                return NotFound();
            }

            db.Transportes.Remove(adtransporte);
            db.SaveChanges();

            return Ok(adtransporte);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdtransporteExists(int id)
        {
            return db.Transportes.Count(e => e.idtransporte == id) > 0;
        }
    }
}