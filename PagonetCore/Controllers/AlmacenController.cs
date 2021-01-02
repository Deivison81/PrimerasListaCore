using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagonetCore.DAL;
using PagonetCore.Models;

namespace PagonetCore.Controllers
{
    public class AlmacenController : Controller
    {
        private PagonetContext db = new PagonetContext();

        // GET: Almacen
        public ActionResult Index()
        {
            return View(db.Almacenes.ToList());
        }

        // GET: Almacen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdAlmacen adAlmacen = db.Almacenes.Find(id);
            if (adAlmacen == null)
            {
                return HttpNotFound();
            }
            return View(adAlmacen);
        }

        // GET: Almacen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Almacen/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_almacen,co_alma,des_alamacen,web,co_user_prof,importado_web,importado_pro")] AdAlmacen adAlmacen)
        {
            if (ModelState.IsValid)
            {
                db.Almacenes.Add(adAlmacen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adAlmacen);
        }

        // GET: Almacen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdAlmacen adAlmacen = db.Almacenes.Find(id);
            if (adAlmacen == null)
            {
                return HttpNotFound();
            }
            return View(adAlmacen);
        }

        // POST: Almacen/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_almacen,co_alma,des_alamacen,web,co_user_prof,importado_web,importado_pro")] AdAlmacen adAlmacen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adAlmacen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adAlmacen);
        }

        // GET: Almacen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdAlmacen adAlmacen = db.Almacenes.Find(id);
            if (adAlmacen == null)
            {
                return HttpNotFound();
            }
            return View(adAlmacen);
        }

        // POST: Almacen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdAlmacen adAlmacen = db.Almacenes.Find(id);
            db.Almacenes.Remove(adAlmacen);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
