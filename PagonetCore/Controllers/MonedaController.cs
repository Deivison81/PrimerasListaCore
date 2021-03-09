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
    public class MonedaController : Controller
    {
        private PagonetContext db = new PagonetContext();

        // GET: Moneda
        public ActionResult Index()
        {
            return View(db.Monedas.ToList());
        }

        // GET: Moneda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdMoneda adMoneda = db.Monedas.Find(id);
            if (adMoneda == null)
            {
                return HttpNotFound();
            }
            return View(adMoneda);
        }

        // GET: Moneda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Moneda/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_moneda,co_mone,mone_des,importado_web,importado_pro")] AdMoneda adMoneda)
        {
            if (ModelState.IsValid)
            {
                db.Monedas.Add(adMoneda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adMoneda);
        }

        // GET: Moneda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdMoneda adMoneda = db.Monedas.Find(id);
            if (adMoneda == null)
            {
                return HttpNotFound();
            }
            return View(adMoneda);
        }

        // POST: Moneda/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_moneda,co_mone,mone_des,importado_web,importado_pro")] AdMoneda adMoneda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adMoneda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adMoneda);
        }

        // GET: Moneda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdMoneda adMoneda = db.Monedas.Find(id);
            if (adMoneda == null)
            {
                return HttpNotFound();
            }
            return View(adMoneda);
        }

        // POST: Moneda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdMoneda adMoneda = db.Monedas.Find(id);
            db.Monedas.Remove(adMoneda);
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
