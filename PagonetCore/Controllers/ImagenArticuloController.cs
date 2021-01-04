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
    public class ImagenArticuloController : Controller
    {
        private PagonetContext db = new PagonetContext();

        // GET: ImagenArticulo
        public ActionResult Index()
        {
            return View(db.ImagenesArticulo.ToList());
        }

        // GET: ImagenArticulo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adimg_art adimg_art = db.ImagenesArticulo.Find(id);
            if (adimg_art == null)
            {
                return HttpNotFound();
            }
            return View(adimg_art);
        }

        // GET: ImagenArticulo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImagenArticulo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_imgart,co_art,tip,imagen_des,picture,importado_web,importado_pro,id_art")] Adimg_art adimg_art)
        {
            if (ModelState.IsValid)
            {
                db.ImagenesArticulo.Add(adimg_art);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adimg_art);
        }

        // GET: ImagenArticulo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adimg_art adimg_art = db.ImagenesArticulo.Find(id);
            if (adimg_art == null)
            {
                return HttpNotFound();
            }
            return View(adimg_art);
        }

        // POST: ImagenArticulo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_imgart,co_art,tip,imagen_des,picture,importado_web,importado_pro")] Adimg_art adimg_art)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adimg_art).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adimg_art);
        }

        // GET: ImagenArticulo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adimg_art adimg_art = db.ImagenesArticulo.Find(id);
            if (adimg_art == null)
            {
                return HttpNotFound();
            }
            return View(adimg_art);
        }

        // POST: ImagenArticulo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adimg_art adimg_art = db.ImagenesArticulo.Find(id);
            db.ImagenesArticulo.Remove(adimg_art);
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
