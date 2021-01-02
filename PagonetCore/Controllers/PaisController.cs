using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagonetCore.DAL;
using PagonetCore.Models;

namespace PagonetCore.Controllers
{
    public class PaisController : Controller
    {
        private PagonetContext db = new PagonetContext();

        // GET: Pais
        public ActionResult Index()
        {
            return View(db.Paises.ToList());
        }

        // GET: Pais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adpais adpais = db.Paises.Find(id);
            if (adpais == null)
            {
                return HttpNotFound();
            }
            return View(adpais);
        }

        // GET: Pais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pais/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_pais,co_pais,pais_des,importado_web,importado_pro")] Adpais adpais)
        {
            if (ModelState.IsValid)
            {
                db.Paises.Add(adpais);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adpais);
        }

        // GET: Pais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adpais adpais = db.Paises.Find(id);
            if (adpais == null)
            {
                return HttpNotFound();
            }
            return View(adpais);
        }

        // POST: Pais/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_pais,co_pais,pais_des,importado_web,importado_pro")] Adpais adpais)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adpais).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adpais);
        }

        // GET: Pais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adpais adpais = db.Paises.Find(id);
            if (adpais == null)
            {
                return HttpNotFound();
            }
            return View(adpais);
        }

        // POST: Pais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adpais adpais = db.Paises.Find(id);
            db.Paises.Remove(adpais);
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
