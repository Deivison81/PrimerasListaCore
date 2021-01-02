using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagonetCore.DAL;
using PagonetCore.Models;

namespace PagonetCore.Controllers
{
    public class SaZonaController : Controller
    {
        private PagonetContext db = new PagonetContext();

        // GET: SaZona
        public ActionResult Index()
        {
            return View(db.Sazonas.ToList());
        }

        // GET: SaZona/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sazona sazona = db.Sazonas.Find(id);
            if (sazona == null)
            {
                return HttpNotFound();
            }
            return View(sazona);
        }

        // GET: SaZona/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SaZona/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "co_zon,zon_des,numcom,feccom,campo1,campo2,campo3,campo4,campo5,campo6,campo7,campo8,fe_us_in,fe_us_mo")] sazona sazona)
        {
            if (ModelState.IsValid)
            {
                db.Sazonas.Add(sazona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sazona);
        }

        // GET: SaZona/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sazona sazona = db.Sazonas.Find(id);
            if (sazona == null)
            {
                return HttpNotFound();
            }
            return View(sazona);
        }

        // POST: SaZona/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "co_zon,zon_des,numcom,feccom,campo1,campo2,campo3,campo4,campo5,campo6,campo7,campo8,fe_us_in,fe_us_mo")] sazona sazona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sazona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sazona);
        }

        // GET: SaZona/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sazona sazona = db.Sazonas.Find(id);
            if (sazona == null)
            {
                return HttpNotFound();
            }
            return View(sazona);
        }

        // POST: SaZona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            sazona sazona = db.Sazonas.Find(id);
            db.Sazonas.Remove(sazona);
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
