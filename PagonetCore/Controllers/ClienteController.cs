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
            var clientes = db.Clientes.Include(a => a.Cliente).Include(a => a.Ingreso).Include(a => a.Pais).Include(a => a.Segmento).Include(a => a.Vendedor).Include(a => a.Zona);
            return View(clientes.ToList());
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
            ViewBag.id_tipocliente = new SelectList(db.TiposCliente, "id_tipocliente", "tip_cli");
            ViewBag.idingre = new SelectList(db.Ingresos, "id", "co_ctaIng_egr");
            ViewBag.id_pais = new SelectList(db.Paises, "id_pais", "co_pais");
            ViewBag.id_segmento = new SelectList(db.Segmentos, "id_segmento", "co_seg");
            ViewBag.id_vendedor = new SelectList(db.Vendedores, "id_vendedor", "co_ven");
            ViewBag.id_zona = new SelectList(db.Zonas, "id_zona", "co_zon");
            return View();
        }

        // POST: Cliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_clientes,co_cli,tip_cli,cli_des,direc1,dir_ent2,telefonos,inactivo,respons,co_zon,co_seg,co_ven,co_cta_ingr_egr,rif,email,juridico,ciudad,zip,co_pais,cod_comercio,importado_web,importado_pro,id_tipocliente,id_vendedor,idingre,id_zona,id_segmento,id_pais")] Adclientes adclientes)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(adclientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_tipocliente = new SelectList(db.TiposCliente, "id_tipocliente", "tip_cli", adclientes.id_tipocliente);
            ViewBag.idingre = new SelectList(db.Ingresos, "id", "co_ctaIng_egr", adclientes.idingre);
            ViewBag.id_pais = new SelectList(db.Paises, "id_pais", "co_pais", adclientes.id_pais);
            ViewBag.id_segmento = new SelectList(db.Segmentos, "id_segmento", "co_seg", adclientes.id_segmento);
            ViewBag.id_vendedor = new SelectList(db.Vendedores, "id_vendedor", "co_ven", adclientes.id_vendedor);
            ViewBag.id_zona = new SelectList(db.Zonas, "id_zona", "co_zon", adclientes.id_zona);
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
            ViewBag.id_tipocliente = new SelectList(db.TiposCliente, "id_tipocliente", "tip_cli", adclientes.id_tipocliente);
            ViewBag.idingre = new SelectList(db.Ingresos, "id", "co_ctaIng_egr", adclientes.idingre);
            ViewBag.id_pais = new SelectList(db.Paises, "id_pais", "co_pais", adclientes.id_pais);
            ViewBag.id_segmento = new SelectList(db.Segmentos, "id_segmento", "co_seg", adclientes.id_segmento);
            ViewBag.id_vendedor = new SelectList(db.Vendedores, "id_vendedor", "co_ven", adclientes.id_vendedor);
            ViewBag.id_zona = new SelectList(db.Zonas, "id_zona", "co_zon", adclientes.id_zona);
            return View(adclientes);
        }

        // POST: Cliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_clientes,co_cli,tip_cli,cli_des,direc1,dir_ent2,telefonos,inactivo,respons,co_zon,co_seg,co_ven,co_cta_ingr_egr,rif,email,juridico,ciudad,zip,co_pais,cod_comercio,importado_web,importado_pro,id_tipocliente,id_vendedor,idingre,id_zona,id_segmento,id_pais")] Adclientes adclientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adclientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_tipocliente = new SelectList(db.TiposCliente, "id_tipocliente", "tip_cli", adclientes.id_tipocliente);
            ViewBag.idingre = new SelectList(db.Ingresos, "id", "co_ctaIng_egr", adclientes.idingre);
            ViewBag.id_pais = new SelectList(db.Paises, "id_pais", "co_pais", adclientes.id_pais);
            ViewBag.id_segmento = new SelectList(db.Segmentos, "id_segmento", "co_seg", adclientes.id_segmento);
            ViewBag.id_vendedor = new SelectList(db.Vendedores, "id_vendedor", "co_ven", adclientes.id_vendedor);
            ViewBag.id_zona = new SelectList(db.Zonas, "id_zona", "co_zon", adclientes.id_zona);
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
