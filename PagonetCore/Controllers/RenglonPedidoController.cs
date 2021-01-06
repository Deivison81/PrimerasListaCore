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
    public class RenglonPedidoController : Controller
    {
        private PagonetContext db = new PagonetContext();

        // GET: RenglonPedido
        public ActionResult Index()
        {
            var renglonesPedidos = db.RenglonesPedidos.Include(a => a.Almacen).Include(a => a.Articulo).Include(a => a.Pedido).Include(a => a.PrecioArticulo);
            return View(renglonesPedidos.ToList());
        }

        // GET: RenglonPedido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdPedidosreg adPedidosreg = db.RenglonesPedidos.Find(id);
            if (adPedidosreg == null)
            {
                return HttpNotFound();
            }
            return View(adPedidosreg);
        }

        // GET: RenglonPedido/Create
        public ActionResult Create()
        {
            ViewBag.cod_almacen = new SelectList(db.Almacenes, "cod_almacen", "co_alma");
            ViewBag.id_art = new SelectList(db.Articulos, "id_art", "co_art");
            ViewBag.id_doc_num = new SelectList(db.Pedidos, "id_doc_num", "doc_num");
            ViewBag.id_preciosart = new SelectList(db.PreciosArticulo, "id_preciosart", "co_art");
            return View();
        }

        // POST: RenglonPedido/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "reng_num,doc_num,co_art,art_des,co_alma,total_art,stotal_art,cod_unidad,co_precios,prec_vta,prec_vta_om,tipo_imp,tipo_imp2,tipo_imp3,porc_imp,porc_imp2,porc_imp3,monto_imp,monto_imp2,monto_imp3,reng_neto,tipo_doc,num_doc,importado_web,importado_pro,id_doc_num,id_art,cod_almacen,id_preciosart")] AdPedidosreg adPedidosreg)
        {
            if (ModelState.IsValid)
            {
                db.RenglonesPedidos.Add(adPedidosreg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_almacen = new SelectList(db.Almacenes, "cod_almacen", "co_alma", adPedidosreg.cod_almacen);
            ViewBag.id_art = new SelectList(db.Articulos, "id_art", "co_art", adPedidosreg.id_art);
            ViewBag.id_doc_num = new SelectList(db.Pedidos, "id_doc_num", "doc_num", adPedidosreg.id_doc_num);
            ViewBag.id_preciosart = new SelectList(db.PreciosArticulo, "id_preciosart", "co_art", adPedidosreg.id_preciosart);
            return View(adPedidosreg);
        }

        // GET: RenglonPedido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdPedidosreg adPedidosreg = db.RenglonesPedidos.Find(id);
            if (adPedidosreg == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_almacen = new SelectList(db.Almacenes, "cod_almacen", "co_alma", adPedidosreg.cod_almacen);
            ViewBag.id_art = new SelectList(db.Articulos, "id_art", "co_art", adPedidosreg.id_art);
            ViewBag.id_doc_num = new SelectList(db.Pedidos, "id_doc_num", "doc_num", adPedidosreg.id_doc_num);
            ViewBag.id_preciosart = new SelectList(db.PreciosArticulo, "id_preciosart", "co_art", adPedidosreg.id_preciosart);
            return View(adPedidosreg);
        }

        // POST: RenglonPedido/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "reng_num,doc_num,co_art,art_des,co_alma,total_art,stotal_art,cod_unidad,co_precios,prec_vta,prec_vta_om,tipo_imp,tipo_imp2,tipo_imp3,porc_imp,porc_imp2,porc_imp3,monto_imp,monto_imp2,monto_imp3,reng_neto,tipo_doc,num_doc,importado_web,importado_pro,id_doc_num,id_art,cod_almacen,id_preciosart")] AdPedidosreg adPedidosreg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adPedidosreg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_almacen = new SelectList(db.Almacenes, "cod_almacen", "co_alma", adPedidosreg.cod_almacen);
            ViewBag.id_art = new SelectList(db.Articulos, "id_art", "co_art", adPedidosreg.id_art);
            ViewBag.id_doc_num = new SelectList(db.Pedidos, "id_doc_num", "doc_num", adPedidosreg.id_doc_num);
            ViewBag.id_preciosart = new SelectList(db.PreciosArticulo, "id_preciosart", "co_art", adPedidosreg.id_preciosart);
            return View(adPedidosreg);
        }

        // GET: RenglonPedido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdPedidosreg adPedidosreg = db.RenglonesPedidos.Find(id);
            if (adPedidosreg == null)
            {
                return HttpNotFound();
            }
            return View(adPedidosreg);
        }

        // POST: RenglonPedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdPedidosreg adPedidosreg = db.RenglonesPedidos.Find(id);
            db.RenglonesPedidos.Remove(adPedidosreg);
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
