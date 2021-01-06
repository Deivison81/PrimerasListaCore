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
    public class IngresoController : Controller
    {
        private PagonetContext db = new PagonetContext();

        // GET: Ingreso
        public ActionResult Index()
        {
            return View(db.Ingresos.ToList());
        }

        // GET: Ingreso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdIngreso adIngreso = db.Ingresos.Find(id);
            if (adIngreso == null)
            {
                return HttpNotFound();
            }
            return View(adIngreso);
        }

        // GET: Ingreso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ingreso/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,co_ctaIng_egr,descrip_ingre,co_user_prof,importado_web,importado_pro")] AdIngreso adIngreso)
        {
            if (ModelState.IsValid)
            {
                db.Ingresos.Add(adIngreso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adIngreso);
        }

        // GET: Ingreso/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdIngreso adIngreso = db.Ingresos.Find(id);
            if (adIngreso == null)
            {
                return HttpNotFound();
            }
            return View(adIngreso);
        }

        // POST: Ingreso/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,co_ctaIng_egr,descrip_ingre,co_user_prof,importado_web,importado_pro")] AdIngreso adIngreso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adIngreso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adIngreso);
        }

        // GET: Ingreso/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdIngreso adIngreso = db.Ingresos.Find(id);
            if (adIngreso == null)
            {
                return HttpNotFound();
            }
            return View(adIngreso);
        }

        // POST: Ingreso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdIngreso adIngreso = db.Ingresos.Find(id);
            db.Ingresos.Remove(adIngreso);
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
