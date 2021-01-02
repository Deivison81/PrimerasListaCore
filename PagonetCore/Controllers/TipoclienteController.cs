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
    public class TipoClienteController : Controller
    {
        private PagonetContext db = new PagonetContext();

        // GET: TipoCliente
        public ActionResult Index()
        {
            return View(db.TiposCliente.ToList());
        }

        // GET: TipoCliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adtipo_cliente adtipo_cliente = db.TiposCliente.Find(id);
            if (adtipo_cliente == null)
            {
                return HttpNotFound();
            }
            return View(adtipo_cliente);
        }

        // GET: TipoCliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoCliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipocliente,tip_cli,des_tipo,importado_web,importado_pro")] Adtipo_cliente adtipo_cliente)
        {
            if (ModelState.IsValid)
            {
                db.TiposCliente.Add(adtipo_cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adtipo_cliente);
        }

        // GET: TipoCliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adtipo_cliente adtipo_cliente = db.TiposCliente.Find(id);
            if (adtipo_cliente == null)
            {
                return HttpNotFound();
            }
            return View(adtipo_cliente);
        }

        // POST: TipoCliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipocliente,tip_cli,des_tipo,importado_web,importado_pro")] Adtipo_cliente adtipo_cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adtipo_cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adtipo_cliente);
        }

        // GET: TipoCliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adtipo_cliente adtipo_cliente = db.TiposCliente.Find(id);
            if (adtipo_cliente == null)
            {
                return HttpNotFound();
            }
            return View(adtipo_cliente);
        }

        // POST: TipoCliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adtipo_cliente adtipo_cliente = db.TiposCliente.Find(id);
            db.TiposCliente.Remove(adtipo_cliente);
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
