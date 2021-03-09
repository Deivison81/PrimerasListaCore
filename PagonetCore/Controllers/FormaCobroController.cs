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
    public class FormaCobroController : Controller
    {
        private PagonetContext db = new PagonetContext();

        // GET: FormaCobro
        public ActionResult Index()
        {
            return View(db.FormasCobro.ToList());
        }

        // GET: FormaCobro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdFormasCobro adFormasCobro = db.FormasCobro.Find(id);
            if (adFormasCobro == null)
            {
                return HttpNotFound();
            }
            return View(adFormasCobro);
        }

        // GET: FormaCobro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormaCobro/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "forma_cob_id,nro_reng,id_cob,cob_num_pro,co_ban,forma_pag,cod_cta,cod_caja,mov_num_c,mov_num_b,mont_doc,dolar,importado_web,importado_pro")] AdFormasCobro adFormasCobro)
        {
            if (ModelState.IsValid)
            {
                db.FormasCobro.Add(adFormasCobro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adFormasCobro);
        }

        // GET: FormaCobro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdFormasCobro adFormasCobro = db.FormasCobro.Find(id);
            if (adFormasCobro == null)
            {
                return HttpNotFound();
            }
            return View(adFormasCobro);
        }

        // POST: FormaCobro/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "forma_cob_id,nro_reng,id_cob,cob_num_pro,co_ban,forma_pag,cod_cta,cod_caja,mov_num_c,mov_num_b,mont_doc,dolar,importado_web,importado_pro")] AdFormasCobro adFormasCobro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adFormasCobro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adFormasCobro);
        }

        // GET: FormaCobro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdFormasCobro adFormasCobro = db.FormasCobro.Find(id);
            if (adFormasCobro == null)
            {
                return HttpNotFound();
            }
            return View(adFormasCobro);
        }

        // POST: FormaCobro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdFormasCobro adFormasCobro = db.FormasCobro.Find(id);
            db.FormasCobro.Remove(adFormasCobro);
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
