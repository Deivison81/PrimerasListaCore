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
    public class RenglonCotizacionController : Controller
    {
        private PagonetContext db = new PagonetContext();

        // GET: RenglonCotizacion
        public ActionResult Index()
        {
            var renglonesCotizacion = db.RenglonesCotizacion.Include(a => a.Almacen).Include(a => a.Articulo).Include(a => a.PrecioArticulo);
            return View(renglonesCotizacion.ToList());
        }

        // GET: RenglonCotizacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdCotizacionreg adCotizacionreg = db.RenglonesCotizacion.Find(id);
            if (adCotizacionreg == null)
            {
                return HttpNotFound();
            }
            return View(adCotizacionreg);
        }

        // GET: RenglonCotizacion/Create
        public ActionResult Create()
        {
            var itemsAlmacenes = db.Almacenes.Select(x => new
            {
                cod_almacen = x.cod_almacen,
                texto = x.co_alma + " - " + x.des_alamacen
            });

            ViewBag.cod_almacen = new SelectList(itemsAlmacenes, "cod_almacen", "texto");

            //ViewBag.cod_almacen = new SelectList(db.Almacenes, "cod_almacen", "co_alma");

            var itemsArticulos = db.Articulos.Select(x => new
            {
                id_art = x.id_art,
                texto = x.co_art + " - " + x.art_des
            });

            ViewBag.id_art = new SelectList(itemsArticulos, "id_art", "texto");

            //ViewBag.id_art = new SelectList(db.Articulos, "id_art", "co_art");

            var itemsPrecioArticulo = db.PreciosArticulo.Select(x => new
            {
                id_preciosart = x.id_preciosart,
                texto = x.co_art + " - " + x.co_precios
            });

            ViewBag.id_preciosart = new SelectList(itemsPrecioArticulo, "id_preciosart", "texto");

            //ViewBag.id_preciosart = new SelectList(db.PreciosArticulo, "id_preciosart", "co_art");

            return View();
        }

        // POST: RenglonCotizacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_doc_num,doc_num,reng_num,co_art,art_des,co_alma,total_art,stotal_art,cod_unidad,co_precios,prec_vta,prec_vta_om,tipo_imp,tipo_imp2,tipo_imp3,porc_imp,porc_imp2,porc_imp3,monto_imp,monto_imp2,monto_imp3,reng_neto,tipo_doc,num_doc,importado_web,importado_pro,id_art,cod_almacen,id_preciosart")] AdCotizacionreg adCotizacionreg)
        {
            if (ModelState.IsValid)
            {
                db.RenglonesCotizacion.Add(adCotizacionreg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_almacen = new SelectList(db.Almacenes, "cod_almacen", "co_alma", adCotizacionreg.cod_almacen);
            ViewBag.id_art = new SelectList(db.Articulos, "id_art", "co_art", adCotizacionreg.id_art);
            ViewBag.id_preciosart = new SelectList(db.PreciosArticulo, "id_preciosart", "co_art", adCotizacionreg.id_preciosart);
            return View(adCotizacionreg);
        }

        // GET: RenglonCotizacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdCotizacionreg adCotizacionreg = db.RenglonesCotizacion.Find(id);
            if (adCotizacionreg == null)
            {
                return HttpNotFound();
            }

            var itemsAlmacenes = db.Almacenes.Select(x => new
            {
                cod_almacen = x.cod_almacen,
                texto = x.co_alma + " - " + x.des_alamacen
            });

            ViewBag.cod_almacen = new SelectList(itemsAlmacenes, "cod_almacen", "texto", adCotizacionreg.cod_almacen);

            var itemsArticulos = db.Articulos.Select(x => new
            {
                id_art = x.id_art,
                texto = x.co_art + " - " + x.art_des
            });

            ViewBag.id_art = new SelectList(itemsArticulos, "id_art", "texto", adCotizacionreg.id_art);

            var itemsPrecioArticulo = db.PreciosArticulo.Select(x => new
            {
                id_preciosart = x.id_preciosart,
                texto = x.co_art + " - " + x.co_precios
            });

            ViewBag.id_preciosart = new SelectList(itemsPrecioArticulo, "id_preciosart", "texto", adCotizacionreg.id_preciosart);

            return View(adCotizacionreg);
        }

        // POST: RenglonCotizacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_doc_num,doc_num,reng_num,co_art,art_des,co_alma,total_art,stotal_art,cod_unidad,co_precios,prec_vta,prec_vta_om,tipo_imp,tipo_imp2,tipo_imp3,porc_imp,porc_imp2,porc_imp3,monto_imp,monto_imp2,monto_imp3,reng_neto,tipo_doc,num_doc,importado_web,importado_pro,id_art,cod_almacen,id_preciosart")] AdCotizacionreg adCotizacionreg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adCotizacionreg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_almacen = new SelectList(db.Almacenes, "cod_almacen", "co_alma", adCotizacionreg.cod_almacen);
            ViewBag.id_art = new SelectList(db.Articulos, "id_art", "co_art", adCotizacionreg.id_art);
            ViewBag.id_preciosart = new SelectList(db.PreciosArticulo, "id_preciosart", "co_art", adCotizacionreg.id_preciosart);
            return View(adCotizacionreg);
        }

        // GET: RenglonCotizacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdCotizacionreg adCotizacionreg = db.RenglonesCotizacion.Find(id);
            if (adCotizacionreg == null)
            {
                return HttpNotFound();
            }
            return View(adCotizacionreg);
        }

        // POST: RenglonCotizacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdCotizacionreg adCotizacionreg = db.RenglonesCotizacion.Find(id);
            db.RenglonesCotizacion.Remove(adCotizacionreg);
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
