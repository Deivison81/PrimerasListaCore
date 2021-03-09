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
    public class MovimientoBancoController : Controller
    {
        private PagonetContext db = new PagonetContext();

        // GET: MovimientoBanco
        public ActionResult Index()
        {
            return View(db.MovimientosBancos.ToList());
        }

        // GET: MovimientoBanco/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdMovimientoBanco adMovimientoBanco = db.MovimientosBancos.Find(id);
            if (adMovimientoBanco == null)
            {
                return HttpNotFound();
            }
            return View(adMovimientoBanco);
        }

        // GET: MovimientoBanco/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovimientoBanco/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mov_num,descrip,cod_cta,co_cta_ingr_egr,fecha,tasa,tipo_op,doc_num,monto_d,monto_h,idb,saldo_ini,origen,cob_pag,dep_num,conciliado,ori_dep,anulado,dep_con,fec_con,cod_ingben,fecha_che,feccom,numcom,dis_cen,campo1,campo2,campo3,campo4,campo5,campo6,campo7,campo8,co_us_in,co_sucu_in,fe_us_in,co_us_mo,co_sucu_mo,fe_us_mo,trasnfe,revisado,nro_transf_nomi,importado_web,importado_pro")] AdMovimientoBanco adMovimientoBanco)
        {
            if (ModelState.IsValid)
            {
                db.MovimientosBancos.Add(adMovimientoBanco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adMovimientoBanco);
        }

        // GET: MovimientoBanco/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdMovimientoBanco adMovimientoBanco = db.MovimientosBancos.Find(id);
            if (adMovimientoBanco == null)
            {
                return HttpNotFound();
            }
            return View(adMovimientoBanco);
        }

        // POST: MovimientoBanco/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mov_num,descrip,cod_cta,co_cta_ingr_egr,fecha,tasa,tipo_op,doc_num,monto_d,monto_h,idb,saldo_ini,origen,cob_pag,dep_num,conciliado,ori_dep,anulado,dep_con,fec_con,cod_ingben,fecha_che,feccom,numcom,dis_cen,campo1,campo2,campo3,campo4,campo5,campo6,campo7,campo8,co_us_in,co_sucu_in,fe_us_in,co_us_mo,co_sucu_mo,fe_us_mo,trasnfe,revisado,nro_transf_nomi,importado_web,importado_pro")] AdMovimientoBanco adMovimientoBanco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adMovimientoBanco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adMovimientoBanco);
        }

        // GET: MovimientoBanco/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdMovimientoBanco adMovimientoBanco = db.MovimientosBancos.Find(id);
            if (adMovimientoBanco == null)
            {
                return HttpNotFound();
            }
            return View(adMovimientoBanco);
        }

        // POST: MovimientoBanco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AdMovimientoBanco adMovimientoBanco = db.MovimientosBancos.Find(id);
            db.MovimientosBancos.Remove(adMovimientoBanco);
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
