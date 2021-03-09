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
    public class RenglonCobroController : Controller
    {
        private PagonetContext db = new PagonetContext();

        // GET: RenglonCobro
        public ActionResult Index()
        {
            return View(db.RenglonesCobro.ToList());
        }

        // GET: RenglonCobro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdRenglonesCobro adRenglonesCobro = db.RenglonesCobro.Find(id);
            if (adRenglonesCobro == null)
            {
                return HttpNotFound();
            }
            return View(adRenglonesCobro);
        }

        // GET: RenglonCobro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RenglonCobro/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idrencob,reng_num,id_cob,cob_num_pro,co_tipo_doc,nro_doc,mont_cob,dpcobro_monto,tipo_doc,num_doc,saldo,importado_web,importado_pro")] AdRenglonesCobro adRenglonesCobro)
        {
            if (ModelState.IsValid)
            {
                db.RenglonesCobro.Add(adRenglonesCobro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adRenglonesCobro);
        }

        // GET: RenglonCobro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdRenglonesCobro adRenglonesCobro = db.RenglonesCobro.Find(id);
            if (adRenglonesCobro == null)
            {
                return HttpNotFound();
            }
            return View(adRenglonesCobro);
        }

        // POST: RenglonCobro/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idrencob,reng_num,id_cob,cob_num_pro,co_tipo_doc,nro_doc,mont_cob,dpcobro_monto,tipo_doc,num_doc,saldo,importado_web,importado_pro")] AdRenglonesCobro adRenglonesCobro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adRenglonesCobro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adRenglonesCobro);
        }

        // GET: RenglonCobro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdRenglonesCobro adRenglonesCobro = db.RenglonesCobro.Find(id);
            if (adRenglonesCobro == null)
            {
                return HttpNotFound();
            }
            return View(adRenglonesCobro);
        }

        // POST: RenglonCobro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdRenglonesCobro adRenglonesCobro = db.RenglonesCobro.Find(id);
            db.RenglonesCobro.Remove(adRenglonesCobro);
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
