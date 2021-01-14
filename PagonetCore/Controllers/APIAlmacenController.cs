using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using PagonetCore.DAL;
using PagonetCore.Models;

namespace PagonetCore.Controllers
{
    public class APIAlmacenController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APIAlmacen
        [Route("Almacen/listarAlmacen")]
        public IQueryable<AdAlmacen> GetAlmacenes()
        {
            return db.Almacenes;
        }

        // GET: api/APIAlmacen/5
        [Route("Almacen/listarAlmacens/{id:int:min(1)}")]
        [ResponseType(typeof(AdAlmacen))]
        public IHttpActionResult GetAdAlmacen(int id)
        {
            AdAlmacen adAlmacen = db.Almacenes.Find(id);
            if (adAlmacen == null)
            {
                return NotFound();
            }

            return Ok(adAlmacen);
        }

        // PUT: api/APIAlmacen/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdAlmacen(int id, AdAlmacen adAlmacen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adAlmacen.cod_almacen)
            {
                return BadRequest();
            }

            db.Entry(adAlmacen).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdAlmacenExists(id))
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

        // Nota: Este método retorna el número de registros afectados por la petición.
        // POST: Almacen/guardarDatos
        [HttpPost]
        [Route("Almacen/guardarDatos")]
        [ResponseType(typeof(int))]
        public int CrearAlmacen(AdAlmacen adAlmacen)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }

            db.Almacenes.Add(adAlmacen);
            db.SaveChanges();

            return 1;
        }

        // POST: api/APIAlmacen
        [ResponseType(typeof(AdAlmacen))]
        public IHttpActionResult PostAdAlmacen(AdAlmacen adAlmacen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Almacenes.Add(adAlmacen);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adAlmacen.cod_almacen }, adAlmacen);
        }

        // DELETE: api/APIAlmacen/5
        [ResponseType(typeof(AdAlmacen))]
        public IHttpActionResult DeleteAdAlmacen(int id)
        {
            AdAlmacen adAlmacen = db.Almacenes.Find(id);
            if (adAlmacen == null)
            {
                return NotFound();
            }

            db.Almacenes.Remove(adAlmacen);
            db.SaveChanges();

            return Ok(adAlmacen);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdAlmacenExists(int id)
        {
            return db.Almacenes.Count(e => e.cod_almacen == id) > 0;
        }
    }
}