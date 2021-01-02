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
    public class PrecioArticuloController : Controller
    {
        private PagonetContext db = new PagonetContext();

        // GET: PrecioArticulos
        public ActionResult Index()
        {
            return View(db.PreciosArticulo.ToList());
        }

        // GET: PrecioArticulos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            adpreciosart adpreciosart = db.PreciosArticulo.Find(id);
            if (adpreciosart == null)
            {
                return HttpNotFound();
            }
            return View(adpreciosart);
        }

        // GET: PrecioArticulos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrecioArticulos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_preciosart,co_art,co_precios,desde,hasta,co_alma,monto,montoadi1,montoadi2,montoadi3,montoadi4,montoadi5,precioOm,importado_web,importado_pro")] adpreciosart adpreciosart)
        {
            if (ModelState.IsValid)
            {
                db.PreciosArticulo.Add(adpreciosart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adpreciosart);
        }

        // GET: PrecioArticulos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            adpreciosart adpreciosart = db.PreciosArticulo.Find(id);
            if (adpreciosart == null)
            {
                return HttpNotFound();
            }
            return View(adpreciosart);
        }

        // POST: PrecioArticulos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_preciosart,co_art,co_precios,desde,hasta,co_alma,monto,montoadi1,montoadi2,montoadi3,montoadi4,montoadi5,precioOm,importado_web,importado_pro")] adpreciosart adpreciosart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adpreciosart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adpreciosart);
        }

        // GET: PrecioArticulos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            adpreciosart adpreciosart = db.PreciosArticulo.Find(id);
            if (adpreciosart == null)
            {
                return HttpNotFound();
            }
            return View(adpreciosart);
        }

        // POST: PrecioArticulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            adpreciosart adpreciosart = db.PreciosArticulo.Find(id);
            db.PreciosArticulo.Remove(adpreciosart);
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
