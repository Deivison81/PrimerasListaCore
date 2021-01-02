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
            var renglonesPedidos = db.RenglonesPedidos.Include(a => a.reng_num);
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
            ViewBag.id_doc_num = new SelectList(db.Pedidos, "id_doc_num", "doc_num");
            return View();
        }

        // POST: RenglonPedido/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RenglonPedidoID,id_doc_num,doc_num,co_art,art_des,co_alma,total_art,stotal_art,cod_unidad,id_preciosart,co_precios,prec_vta,prec_vta_om,tipo_imp,tipo_imp2,tipo_imp3,porc_imp,porc_imp2,porc_imp3,monto_imp,monto_imp2,monto_imp3,reng_neto,tipo_doc,num_doc,importado_web,importado_pro")] AdPedidosreg adPedidosreg)
        {
            if (ModelState.IsValid)
            {
                db.RenglonesPedidos.Add(adPedidosreg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_doc_num = new SelectList(db.Pedidos, "id_doc_num", "doc_num", adPedidosreg.id_doc_num);
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
            ViewBag.id_doc_num = new SelectList(db.Pedidos, "id_doc_num", "doc_num", adPedidosreg.id_doc_num);
            return View(adPedidosreg);
        }

        // POST: RenglonPedido/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RenglonPedidoID,id_doc_num,doc_num,co_art,art_des,co_alma,total_art,stotal_art,cod_unidad,id_preciosart,co_precios,prec_vta,prec_vta_om,tipo_imp,tipo_imp2,tipo_imp3,porc_imp,porc_imp2,porc_imp3,monto_imp,monto_imp2,monto_imp3,reng_neto,tipo_doc,num_doc,importado_web,importado_pro")] AdPedidosreg adPedidosreg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adPedidosreg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_doc_num = new SelectList(db.Pedidos, "id_doc_num", "doc_num", adPedidosreg.id_doc_num);
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
