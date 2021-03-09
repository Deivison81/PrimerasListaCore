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
    public class CobroController : Controller
    {
        private PagonetContext db = new PagonetContext();

        // GET: Cobro
        public ActionResult Index()
        {
            return View(db.Cobros.ToList());
        }

        // GET: Cobro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdCobros adCobros = db.Cobros.Find(id);
            if (adCobros == null)
            {
                return HttpNotFound();
            }
            return View(adCobros);
        }

        // GET: Cobro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cobro/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_cob,cob_num_pro,id_clientes,co_cli,co_mone,id_vendedor,co_ven,tasa,fecha,anulado,monto,importado_web,importado_pro")] AdCobros adCobros)
        {
            if (ModelState.IsValid)
            {
                db.Cobros.Add(adCobros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adCobros);
        }

        // GET: Cobro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdCobros adCobros = db.Cobros.Find(id);
            if (adCobros == null)
            {
                return HttpNotFound();
            }
            return View(adCobros);
        }

        // POST: Cobro/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_cob,cob_num_pro,id_clientes,co_cli,co_mone,id_vendedor,co_ven,tasa,fecha,anulado,monto,importado_web,importado_pro")] AdCobros adCobros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adCobros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adCobros);
        }

        // GET: Cobro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdCobros adCobros = db.Cobros.Find(id);
            if (adCobros == null)
            {
                return HttpNotFound();
            }
            return View(adCobros);
        }

        // POST: Cobro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdCobros adCobros = db.Cobros.Find(id);
            db.Cobros.Remove(adCobros);
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
