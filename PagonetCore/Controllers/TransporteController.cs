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
    public class TransporteController : Controller
    {
        private PagonetContext db = new PagonetContext();

        // GET: Transporte
        public ActionResult Index()
        {
            return View(db.Transportes.ToList());
        }

        // GET: Transporte/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adtransporte adtransporte = db.Transportes.Find(id);
            if (adtransporte == null)
            {
                return HttpNotFound();
            }
            return View(adtransporte);
        }

        // GET: Transporte/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transporte/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idtransporte,co_tran,des_tran,importado_web,importado_pro")] Adtransporte adtransporte)
        {
            if (ModelState.IsValid)
            {
                db.Transportes.Add(adtransporte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adtransporte);
        }

        // GET: Transporte/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adtransporte adtransporte = db.Transportes.Find(id);
            if (adtransporte == null)
            {
                return HttpNotFound();
            }
            return View(adtransporte);
        }

        // POST: Transporte/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idtransporte,co_tran,des_tran,importado_web,importado_pro")] Adtransporte adtransporte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adtransporte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adtransporte);
        }

        // GET: Transporte/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adtransporte adtransporte = db.Transportes.Find(id);
            if (adtransporte == null)
            {
                return HttpNotFound();
            }
            return View(adtransporte);
        }

        // POST: Transporte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adtransporte adtransporte = db.Transportes.Find(id);
            db.Transportes.Remove(adtransporte);
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
