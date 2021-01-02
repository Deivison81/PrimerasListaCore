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
    public class CondicionDePagoController : Controller
    {
        private PagonetContext db = new PagonetContext();

        // GET: CondicionDePago
        public ActionResult Index()
        {
            return View(db.CondicionesDePago.ToList());
        }

        // GET: CondicionDePago/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adcondiciondepago adcondiciondepago = db.CondicionesDePago.Find(id);
            if (adcondiciondepago == null)
            {
                return HttpNotFound();
            }
            return View(adcondiciondepago);
        }

        // GET: CondicionDePago/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CondicionDePago/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_condicion,co_cond,cond_des,dias_cred,importado_web,importado_pro")] Adcondiciondepago adcondiciondepago)
        {
            if (ModelState.IsValid)
            {
                db.CondicionesDePago.Add(adcondiciondepago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adcondiciondepago);
        }

        // GET: CondicionDePago/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adcondiciondepago adcondiciondepago = db.CondicionesDePago.Find(id);
            if (adcondiciondepago == null)
            {
                return HttpNotFound();
            }
            return View(adcondiciondepago);
        }

        // POST: CondicionDePago/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_condicion,co_cond,cond_des,dias_cred,importado_web,importado_pro")] Adcondiciondepago adcondiciondepago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adcondiciondepago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adcondiciondepago);
        }

        // GET: CondicionDePago/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adcondiciondepago adcondiciondepago = db.CondicionesDePago.Find(id);
            if (adcondiciondepago == null)
            {
                return HttpNotFound();
            }
            return View(adcondiciondepago);
        }

        // POST: CondicionDePago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adcondiciondepago adcondiciondepago = db.CondicionesDePago.Find(id);
            db.CondicionesDePago.Remove(adcondiciondepago);
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
