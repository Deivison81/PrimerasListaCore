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
    public class SerialController : Controller
    {
        private PagonetContext db = new PagonetContext();

        // GET: Serial
        public ActionResult Index()
        {
            var seriales = db.Seriales.Include(a => a.Almacen).Include(a => a.Articulo);
            return View(seriales.ToList());
        }

        // GET: Serial/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdSerial adSerial = db.Seriales.Find(id);
            if (adSerial == null)
            {
                return HttpNotFound();
            }
            return View(adSerial);
        }

        // GET: Serial/Create
        public ActionResult Create()
        {
            ViewBag.cod_almacen = new SelectList(db.Almacenes, "cod_almacen", "co_alma");
            ViewBag.id_art = new SelectList(db.Articulos, "id_art", "co_art");
            return View();
        }

        // POST: Serial/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "reng_num,co_art,co_alma,serial,tip_dispositivo,importado_web,importado_pro,id_art,cod_almacen")] AdSerial adSerial)
        {
            if (ModelState.IsValid)
            {
                db.Seriales.Add(adSerial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_almacen = new SelectList(db.Almacenes, "cod_almacen", "co_alma", adSerial.cod_almacen);
            ViewBag.id_art = new SelectList(db.Articulos, "id_art", "co_art", adSerial.id_art);
            return View(adSerial);
        }

        // GET: Serial/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdSerial adSerial = db.Seriales.Find(id);
            if (adSerial == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_almacen = new SelectList(db.Almacenes, "cod_almacen", "co_alma", adSerial.cod_almacen);
            ViewBag.id_art = new SelectList(db.Articulos, "id_art", "co_art", adSerial.id_art);
            return View(adSerial);
        }

        // POST: Serial/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "reng_num,co_art,co_alma,serial,tip_dispositivo,importado_web,importado_pro,id_art,cod_almacen")] AdSerial adSerial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adSerial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_almacen = new SelectList(db.Almacenes, "cod_almacen", "co_alma", adSerial.cod_almacen);
            ViewBag.id_art = new SelectList(db.Articulos, "id_art", "co_art", adSerial.id_art);
            return View(adSerial);
        }

        // GET: Serial/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdSerial adSerial = db.Seriales.Find(id);
            if (adSerial == null)
            {
                return HttpNotFound();
            }
            return View(adSerial);
        }

        // POST: Serial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdSerial adSerial = db.Seriales.Find(id);
            db.Seriales.Remove(adSerial);
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
