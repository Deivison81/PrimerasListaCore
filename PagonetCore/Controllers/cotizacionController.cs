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
    public class CotizacionController : Controller
    {
        private PagonetContext db = new PagonetContext();

        // GET: Cotizacion
        public ActionResult Index()
        {
            return View(db.Cotizaciones.ToList());
        }

        // GET: Cotizacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adcotizacion adcotizacion = db.Cotizaciones.Find(id);
            if (adcotizacion == null)
            {
                return HttpNotFound();
            }
            return View(adcotizacion);
        }

        // GET: Cotizacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cotizacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_doc_num,doc_num,descrip,co_cli,co_tran,co_mone,co_ven,co_cond,fec_emis,fec_venc,fec_reg,anulado,status,total_bruto,monto_imp,monto_imp2,monto_imp3,total_neto,saldo,importado_web,importado_pro,Diasvencimiento,nro_pedido,vencida")] Adcotizacion adcotizacion)
        {
            if (ModelState.IsValid)
            {
                db.Cotizaciones.Add(adcotizacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adcotizacion);
        }

        // GET: Cotizacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adcotizacion adcotizacion = db.Cotizaciones.Find(id);
            if (adcotizacion == null)
            {
                return HttpNotFound();
            }
            return View(adcotizacion);
        }

        // POST: Cotizacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_doc_num,doc_num,descrip,co_cli,co_tran,co_mone,co_ven,co_cond,fec_emis,fec_venc,fec_reg,anulado,status,total_bruto,monto_imp,monto_imp2,monto_imp3,total_neto,saldo,importado_web,importado_pro,Diasvencimiento,nro_pedido,vencida")] Adcotizacion adcotizacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adcotizacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adcotizacion);
        }

        // GET: Cotizacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adcotizacion adcotizacion = db.Cotizaciones.Find(id);
            if (adcotizacion == null)
            {
                return HttpNotFound();
            }
            return View(adcotizacion);
        }

        // POST: Cotizacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adcotizacion adcotizacion = db.Cotizaciones.Find(id);
            db.Cotizaciones.Remove(adcotizacion);
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
