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
    public class StockAlmacenController : Controller
    {
        private PagonetContext db = new PagonetContext();

        // GET: StockAlmacen
        public ActionResult Index()
        {
            return View(db.StockAlmacenes.ToList());
        }

        // GET: StockAlmacen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockAlma stockAlma = db.StockAlmacenes.Find(id);
            if (stockAlma == null)
            {
                return HttpNotFound();
            }
            return View(stockAlma);
        }

        // GET: StockAlmacen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StockAlmacen/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StockAlmacenID,stock")] StockAlma stockAlma)
        {
            if (ModelState.IsValid)
            {
                db.StockAlmacenes.Add(stockAlma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stockAlma);
        }

        // GET: StockAlmacen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockAlma stockAlma = db.StockAlmacenes.Find(id);
            if (stockAlma == null)
            {
                return HttpNotFound();
            }
            return View(stockAlma);
        }

        // POST: StockAlmacen/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StockAlmacenID,stock")] StockAlma stockAlma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockAlma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stockAlma);
        }

        // GET: StockAlmacen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockAlma stockAlma = db.StockAlmacenes.Find(id);
            if (stockAlma == null)
            {
                return HttpNotFound();
            }
            return View(stockAlma);
        }

        // POST: StockAlmacen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockAlma stockAlma = db.StockAlmacenes.Find(id);
            db.StockAlmacenes.Remove(stockAlma);
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
