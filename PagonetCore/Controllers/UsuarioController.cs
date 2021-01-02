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
    public class UsuarioController : Controller
    {
        private PagonetContext db = new PagonetContext();

        // GET: Usuario
        public ActionResult Index()
        {
            return View(db.Usuarios.ToList());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adusuarios adusuarios = db.Usuarios.Find(id);
            if (adusuarios == null)
            {
                return HttpNotFound();
            }
            return View(adusuarios);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,co_user_prof,cod_user,nombre_usuarios,password,Estado,fecha_ingreso,validacion")] Adusuarios adusuarios)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(adusuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adusuarios);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adusuarios adusuarios = db.Usuarios.Find(id);
            if (adusuarios == null)
            {
                return HttpNotFound();
            }
            return View(adusuarios);
        }

        // POST: Usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,co_user_prof,cod_user,nombre_usuarios,password,Estado,fecha_ingreso,validacion")] Adusuarios adusuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adusuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adusuarios);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adusuarios adusuarios = db.Usuarios.Find(id);
            if (adusuarios == null)
            {
                return HttpNotFound();
            }
            return View(adusuarios);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adusuarios adusuarios = db.Usuarios.Find(id);
            db.Usuarios.Remove(adusuarios);
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
