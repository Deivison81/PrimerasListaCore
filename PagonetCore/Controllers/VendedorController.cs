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
    public class VendedorController : Controller
    {
        private PagonetContext db = new PagonetContext();

        // GET: Vendedor
        public ActionResult Index()
        {
            return View(db.Vendedores.ToList());
        }

        // GET: Vendedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advendedor advendedor = db.Vendedores.Find(id);
            if (advendedor == null)
            {
                return HttpNotFound();
            }
            return View(advendedor);
        }

        // GET: Vendedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendedor/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_vendedor,co_ven,tipo,ven_des,co_zon,importado_web,importado_pro")] Advendedor advendedor)
        {
            if (ModelState.IsValid)
            {
                db.Vendedores.Add(advendedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(advendedor);
        }

        // GET: Vendedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advendedor advendedor = db.Vendedores.Find(id);
            if (advendedor == null)
            {
                return HttpNotFound();
            }
            return View(advendedor);
        }

        // POST: Vendedor/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_vendedor,co_ven,tipo,ven_des,co_zon,importado_web,importado_pro")] Advendedor advendedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advendedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(advendedor);
        }

        // GET: Vendedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advendedor advendedor = db.Vendedores.Find(id);
            if (advendedor == null)
            {
                return HttpNotFound();
            }
            return View(advendedor);
        }

        // POST: Vendedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Advendedor advendedor = db.Vendedores.Find(id);
            db.Vendedores.Remove(advendedor);
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
