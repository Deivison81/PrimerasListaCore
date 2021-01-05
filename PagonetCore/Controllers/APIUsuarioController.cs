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
    public class APIUsuarioController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APIUsuario
        public IQueryable<Adusuarios> GetUsuarios()
        {
            return db.Usuarios;
        }

        // GET: api/APIUsuario/5
        [ResponseType(typeof(Adusuarios))]
        public IHttpActionResult GetAdusuarios(int id)
        {
            Adusuarios adusuarios = db.Usuarios.Find(id);
            if (adusuarios == null)
            {
                return NotFound();
            }

            return Ok(adusuarios);
        }

        // PUT: api/APIUsuario/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdusuarios(int id, Adusuarios adusuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adusuarios.id)
            {
                return BadRequest();
            }

            db.Entry(adusuarios).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdusuariosExists(id))
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

        // POST: api/APIUsuario
        [ResponseType(typeof(Adusuarios))]
        public IHttpActionResult PostAdusuarios(Adusuarios adusuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Usuarios.Add(adusuarios);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AdusuariosExists(adusuarios.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = adusuarios.id }, adusuarios);
        }

        // DELETE: api/APIUsuario/5
        [ResponseType(typeof(Adusuarios))]
        public IHttpActionResult DeleteAdusuarios(int id)
        {
            Adusuarios adusuarios = db.Usuarios.Find(id);
            if (adusuarios == null)
            {
                return NotFound();
            }

            db.Usuarios.Remove(adusuarios);
            db.SaveChanges();

            return Ok(adusuarios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdusuariosExists(int id)
        {
            return db.Usuarios.Count(e => e.id == id) > 0;
        }
    }
}