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
    public class BancoController : Controller
    {
        private PagonetContext db = new PagonetContext();

        // GET: Banco
        public ActionResult Index()
        {
            return View(db.Bancos.ToList());
        }

        // GET: Banco/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdBanco adBanco = db.Bancos.Find(id);
            if (adBanco == null)
            {
                return HttpNotFound();
            }
            return View(adBanco);
        }

        // GET: Banco/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Banco/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_banco,co_ban,des_ban,importado_web,importado_pro")] AdBanco adBanco)
        {
            if (ModelState.IsValid)
            {
                db.Bancos.Add(adBanco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adBanco);
        }

        // GET: Banco/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdBanco adBanco = db.Bancos.Find(id);
            if (adBanco == null)
            {
                return HttpNotFound();
            }
            return View(adBanco);
        }

        // POST: Banco/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_banco,co_ban,des_ban,importado_web,importado_pro")] AdBanco adBanco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adBanco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adBanco);
        }

        // GET: Banco/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdBanco adBanco = db.Bancos.Find(id);
            if (adBanco == null)
            {
                return HttpNotFound();
            }
            return View(adBanco);
        }

        // POST: Banco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdBanco adBanco = db.Bancos.Find(id);
            db.Bancos.Remove(adBanco);
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
