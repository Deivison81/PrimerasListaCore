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
    public class SegmentoController : Controller
    {
        private PagonetContext db = new PagonetContext();

        // GET: Segmento
        public ActionResult Index()
        {
            return View(db.Segmentos.ToList());
        }

        // GET: Segmento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdSegmento adSegmento = db.Segmentos.Find(id);
            if (adSegmento == null)
            {
                return HttpNotFound();
            }
            return View(adSegmento);
        }

        // GET: Segmento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Segmento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_segmento,co_seg,seg_des,importado_web,importado_pro")] AdSegmento adSegmento)
        {
            if (ModelState.IsValid)
            {
                db.Segmentos.Add(adSegmento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adSegmento);
        }

        // GET: Segmento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdSegmento adSegmento = db.Segmentos.Find(id);
            if (adSegmento == null)
            {
                return HttpNotFound();
            }
            return View(adSegmento);
        }

        // POST: Segmento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_segmento,co_seg,seg_des,importado_web,importado_pro")] AdSegmento adSegmento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adSegmento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adSegmento);
        }

        // GET: Segmento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdSegmento adSegmento = db.Segmentos.Find(id);
            if (adSegmento == null)
            {
                return HttpNotFound();
            }
            return View(adSegmento);
        }

        // POST: Segmento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdSegmento adSegmento = db.Segmentos.Find(id);
            db.Segmentos.Remove(adSegmento);
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
