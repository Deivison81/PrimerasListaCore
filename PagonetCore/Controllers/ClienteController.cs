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
    public class ClienteController : Controller
    {
        private PagonetContext db = new PagonetContext();

        // GET: Cliente
        public ActionResult Index()
        {
            return View(db.Clientes.ToList());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adclientes adclientes = db.Clientes.Find(id);
            if (adclientes == null)
            {
                return HttpNotFound();
            }
            return View(adclientes);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_clientes,co_cli,tip_cli,cli_des,direc1,dir_ent2,telefonos,inactivo,respons,co_zon,co_seg,co_ven,co_cta_ingr_egr,rif,email,juridico,ciudad,zip,id_pais,co_pais,cod_comercio,importado_web,importado_pro,id_tipocliente,id_vendedor,idingre,id_zona,id_segmento")] Adclientes adclientes)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(adclientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adclientes);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adclientes adclientes = db.Clientes.Find(id);
            if (adclientes == null)
            {
                return HttpNotFound();
            }
            return View(adclientes);
        }

        // POST: Cliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_clientes,co_cli,tip_cli,cli_des,direc1,dir_ent2,telefonos,inactivo,respons,co_zon,co_seg,co_ven,co_cta_ingr_egr,rif,email,juridico,ciudad,zip,id_pais,co_pais,cod_comercio,importado_web,importado_pro")] Adclientes adclientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adclientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adclientes);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adclientes adclientes = db.Clientes.Find(id);
            if (adclientes == null)
            {
                return HttpNotFound();
            }
            return View(adclientes);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adclientes adclientes = db.Clientes.Find(id);
            db.Clientes.Remove(adclientes);
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
