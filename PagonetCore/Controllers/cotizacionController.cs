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
            var cotizaciones = db.Cotizaciones.Include(a => a.Cliente).Include(a => a.CondicionDePago).Include(a => a.Transporte).Include(a => a.Vendedor);
            return View(cotizaciones.ToList());
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
            var itemsClientes = db.Clientes.Select(x => new
            {
                id_clientes = x.id_clientes,
                texto = x.co_cli + " - " + x.tip_cli + " - " + x.cli_des
            });

            ViewBag.id_clientes = new SelectList(itemsClientes, "id_clientes", "texto");

            //ViewBag.id_clientes = new SelectList(db.Clientes, "id_clientes", "co_cli");

            var itemsCondicionesPago = db.CondicionesDePago.Select(x => new
            {
                id_condicion = x.id_condicion,
                texto = x.co_cond + " - " + x.cond_des + " - " + x.dias_cred
            });

            ViewBag.id_condicion = new SelectList(itemsCondicionesPago, "id_condicion", "texto");

            //ViewBag.id_condicion = new SelectList(db.CondicionesDePago, "id_condicion", "co_cond");

            var itemsTransporte = db.Transportes.Select(x => new
            {
                idtransporte = x.idtransporte,
                texto = x.co_tran + " - " + x.des_tran
            });

            ViewBag.idtransporte = new SelectList(itemsTransporte, "idtransporte", "texto");

            //ViewBag.idtransporte = new SelectList(db.Transportes, "idtransporte", "co_tran");

            var itemsVendedores = db.Vendedores.Select(x => new
            {
                id_vendedor = x.id_vendedor,
                texto = x.co_ven + " - " + x.tipo + " - " + x.ven_des + " - " + x.co_zon
            });

            ViewBag.id_vendedor = new SelectList(itemsVendedores, "id_vendedor", "texto");

            //ViewBag.id_vendedor = new SelectList(db.Vendedores, "id_vendedor", "co_ven");
            return View();
        }

        // POST: Cotizacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_doc_num,doc_num,descrip,co_cli,co_tran,co_mone,co_ven,co_cond,fec_emis,fec_venc,fec_reg,anulado,status,total_bruto,monto_imp,monto_imp2,monto_imp3,total_neto,saldo,importado_web,importado_pro,Diasvencimiento,nro_pedido,vencida,id_clientes,idtransporte,id_vendedor,id_condicion")] Adcotizacion adcotizacion)
        {
            if (ModelState.IsValid)
            {
                db.Cotizaciones.Add(adcotizacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_clientes = new SelectList(db.Clientes, "id_clientes", "co_cli", adcotizacion.id_clientes);
            ViewBag.id_condicion = new SelectList(db.CondicionesDePago, "id_condicion", "co_cond", adcotizacion.id_condicion);
            ViewBag.idtransporte = new SelectList(db.Transportes, "idtransporte", "co_tran", adcotizacion.idtransporte);
            ViewBag.id_vendedor = new SelectList(db.Vendedores, "id_vendedor", "co_ven", adcotizacion.id_vendedor);
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

            var itemsClientes = db.Clientes.Select(x => new
            {
                id_clientes = x.id_clientes,
                texto = x.co_cli + " - " + x.tip_cli + " - " + x.cli_des
            });

            ViewBag.id_clientes = new SelectList(itemsClientes, "id_clientes", "texto", adcotizacion.id_clientes);

            //ViewBag.id_clientes = new SelectList(db.Clientes, "id_clientes", "co_cli", adcotizacion.id_clientes);

            var itemsCondicionesPago = db.CondicionesDePago.Select(x => new
            {
                id_condicion = x.id_condicion,
                texto = x.co_cond + " - " + x.cond_des + " - " + x.dias_cred
            });

            ViewBag.id_condicion = new SelectList(itemsCondicionesPago, "id_condicion", "texto", adcotizacion.id_condicion);

            //ViewBag.id_condicion = new SelectList(db.CondicionesDePago, "id_condicion", "co_cond", adcotizacion.id_condicion);

            var itemsTransporte = db.Transportes.Select(x => new
            {
                idtransporte = x.idtransporte,
                texto = x.co_tran + " - " + x.des_tran
            });

            ViewBag.idtransporte = new SelectList(itemsTransporte, "idtransporte", "texto", adcotizacion.idtransporte);

            //ViewBag.idtransporte = new SelectList(db.Transportes, "idtransporte", "co_tran", adcotizacion.idtransporte);

            var itemsVendedores = db.Vendedores.Select(x => new
            {
                id_vendedor = x.id_vendedor,
                texto = x.co_ven + " - " + x.tipo + " - " + x.ven_des + " - " + x.co_zon
            });

            ViewBag.id_vendedor = new SelectList(itemsVendedores, "id_vendedor", "texto", adcotizacion.id_vendedor);

            //ViewBag.id_vendedor = new SelectList(db.Vendedores, "id_vendedor", "co_ven", adcotizacion.id_vendedor);

            return View(adcotizacion);
        }

        // POST: Cotizacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_doc_num,doc_num,descrip,co_cli,co_tran,co_mone,co_ven,co_cond,fec_emis,fec_venc,fec_reg,anulado,status,total_bruto,monto_imp,monto_imp2,monto_imp3,total_neto,saldo,importado_web,importado_pro,Diasvencimiento,nro_pedido,vencida,id_clientes,idtransporte,id_vendedor,id_condicion")] Adcotizacion adcotizacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adcotizacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_clientes = new SelectList(db.Clientes, "id_clientes", "co_cli", adcotizacion.id_clientes);
            ViewBag.id_condicion = new SelectList(db.CondicionesDePago, "id_condicion", "co_cond", adcotizacion.id_condicion);
            ViewBag.idtransporte = new SelectList(db.Transportes, "idtransporte", "co_tran", adcotizacion.idtransporte);
            ViewBag.id_vendedor = new SelectList(db.Vendedores, "id_vendedor", "co_ven", adcotizacion.id_vendedor);
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
