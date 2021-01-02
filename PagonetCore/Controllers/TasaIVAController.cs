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
    public class TasaIVAController : Controller
    {
        private PagonetContext db = new PagonetContext();

        // GET: TasaIVA
        public ActionResult Index()
        {
            return View(db.TasasIVA.ToList());
        }

        // GET: TasaIVA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasa_IVA tasa_IVA = db.TasasIVA.Find(id);
            if (tasa_IVA == null)
            {
                return HttpNotFound();
            }
            return View(tasa_IVA);
        }

        // GET: TasaIVA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TasaIVA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_impuesto,fechapubli,nro_reng,tip_impu,ventas,consumosuntuario,porcentajetaza,porcentajesuntuario,importado_web,importado_pro")] Tasa_IVA tasa_IVA)
        {
            if (ModelState.IsValid)
            {
                db.TasasIVA.Add(tasa_IVA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tasa_IVA);
        }

        // GET: TasaIVA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasa_IVA tasa_IVA = db.TasasIVA.Find(id);
            if (tasa_IVA == null)
            {
                return HttpNotFound();
            }
            return View(tasa_IVA);
        }

        // POST: TasaIVA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_impuesto,fechapubli,nro_reng,tip_impu,ventas,consumosuntuario,porcentajetaza,porcentajesuntuario,importado_web,importado_pro")] Tasa_IVA tasa_IVA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tasa_IVA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tasa_IVA);
        }

        // GET: TasaIVA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasa_IVA tasa_IVA = db.TasasIVA.Find(id);
            if (tasa_IVA == null)
            {
                return HttpNotFound();
            }
            return View(tasa_IVA);
        }

        // POST: TasaIVA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tasa_IVA tasa_IVA = db.TasasIVA.Find(id);
            db.TasasIVA.Remove(tasa_IVA);
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
