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
    public class ArticuloController : Controller
    {
        private PagonetContext db = new PagonetContext();

        // GET: Articulo
        public ActionResult Index()
        {
            return View(db.Articulos.ToList());
        }

        // GET: Articulo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdArticulo adArticulo = db.Articulos.Find(id);
            if (adArticulo == null)
            {
                return HttpNotFound();
            }
            return View(adArticulo);
        }

        // GET: Articulo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articulo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_art,co_art,art_des,co_lin,co_subl,co_cat,co_color,co_ubicacion,cod_proc,cod_unidad,referencia,tipo_imp,tipo_imp2,tipo_imp3,importado_web,importado_pro")] AdArticulo adArticulo)
        {
            if (ModelState.IsValid)
            {
                db.Articulos.Add(adArticulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adArticulo);
        }

        // GET: Articulo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdArticulo adArticulo = db.Articulos.Find(id);
            if (adArticulo == null)
            {
                return HttpNotFound();
            }
            return View(adArticulo);
        }

        // POST: Articulo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_art,co_art,art_des,co_lin,co_subl,co_cat,co_color,co_ubicacion,cod_proc,cod_unidad,referencia,tipo_imp,tipo_imp2,tipo_imp3,importado_web,importado_pro")] AdArticulo adArticulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adArticulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adArticulo);
        }

        // GET: Articulo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdArticulo adArticulo = db.Articulos.Find(id);
            if (adArticulo == null)
            {
                return HttpNotFound();
            }
            return View(adArticulo);
        }

        // POST: Articulo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdArticulo adArticulo = db.Articulos.Find(id);
            db.Articulos.Remove(adArticulo);
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
