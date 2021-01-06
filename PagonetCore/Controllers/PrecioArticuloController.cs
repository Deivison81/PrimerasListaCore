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

        // GET: PrecioArticulo
        public ActionResult Index()
        {
            var preciosArticulo = db.PreciosArticulo.Include(a => a.Almacen).Include(a => a.Articulo);
            return View(preciosArticulo.ToList());
        }

        // GET: PrecioArticulo/Details/5
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

        // GET: PrecioArticulo/Create
        public ActionResult Create()
        {
            var itemsAlmacenes = db.Almacenes.Select(x => new
            {
                cod_almacen = x.cod_almacen,
                texto = x.co_alma + " - " + x.des_alamacen
            });

            ViewBag.cod_almacen = new SelectList(itemsAlmacenes, "cod_almacen", "texto");

            var itemsArticulos = db.Articulos.Select(x => new
            {
                id_art = x.id_art,
                texto = x.co_art + " - " + x.art_des
            });

            ViewBag.id_art = new SelectList(itemsArticulos, "id_art", "texto");

            return View();
        }

        // POST: PrecioArticulo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_preciosart,co_art,co_precios,desde,hasta,co_alma,monto,montoadi1,montoadi2,montoadi3,montoadi4,montoadi5,precioOm,importado_web,importado_pro,id_art,cod_almacen")] adpreciosart adpreciosart)
        {
            if (ModelState.IsValid)
            {
                db.PreciosArticulo.Add(adpreciosart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_almacen = new SelectList(db.Almacenes, "cod_almacen", "co_alma", adpreciosart.cod_almacen);
            ViewBag.id_art = new SelectList(db.Articulos, "id_art", "co_art", adpreciosart.id_art);
            return View(adpreciosart);
        }

        // GET: PrecioArticulo/Edit/5
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

            var itemsAlmacenes = db.Almacenes.Select(x => new
            {
                cod_almacen = x.cod_almacen,
                texto = x.co_alma + " - " + x.des_alamacen
            });

            ViewBag.cod_almacen = new SelectList(itemsAlmacenes, "cod_almacen", "texto", adpreciosart.cod_almacen);

            var itemsArticulos = db.Articulos.Select(x => new
            {
                id_art = x.id_art,
                texto = x.co_art + " - " + x.art_des
            });

            ViewBag.id_art = new SelectList(itemsArticulos, "id_art", "texto", adpreciosart.id_art);

            return View(adpreciosart);
        }

        // POST: PrecioArticulo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_preciosart,co_art,co_precios,desde,hasta,co_alma,monto,montoadi1,montoadi2,montoadi3,montoadi4,montoadi5,precioOm,importado_web,importado_pro,id_art,cod_almacen")] adpreciosart adpreciosart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adpreciosart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_almacen = new SelectList(db.Almacenes, "cod_almacen", "co_alma", adpreciosart.cod_almacen);
            ViewBag.id_art = new SelectList(db.Articulos, "id_art", "co_art", adpreciosart.id_art);
            return View(adpreciosart);
        }

        // GET: PrecioArticulo/Delete/5
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

        // POST: PrecioArticulo/Delete/5
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
