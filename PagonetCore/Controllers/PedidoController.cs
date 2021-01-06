﻿using System;
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
    public class PedidoController : Controller
    {
        private PagonetContext db = new PagonetContext();

        // GET: Pedido
        public ActionResult Index()
        {
            var pedidos = db.Pedidos.Include(a => a.Cliente).Include(a => a.CondicionDePago).Include(a => a.Transporte).Include(a => a.Vendedor);
            return View(pedidos.ToList());
        }

        // GET: Pedido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adpedidos adpedidos = db.Pedidos.Find(id);
            if (adpedidos == null)
            {
                return HttpNotFound();
            }
            return View(adpedidos);
        }

        // GET: Pedido/Create
        public ActionResult Create()
        {
            ViewBag.id_clientes = new SelectList(db.Clientes, "id_clientes", "co_cli");
            ViewBag.id_condicion = new SelectList(db.CondicionesDePago, "id_condicion", "co_cond");
            ViewBag.idtransporte = new SelectList(db.Transportes, "idtransporte", "co_tran");
            ViewBag.id_vendedor = new SelectList(db.Vendedores, "id_vendedor", "co_ven");
            return View();
        }

        // POST: Pedido/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_doc_num,doc_num,descrip,co_cli,co_tran,co_mone,co_ven,co_cond,fec_emis,fec_venc,fec_reg,anulado,status,total_bruto,monto_imp,monto_imp2,monto_imp3,total_neto,saldo,importado_web,importado_pro,Diasvencimiento,nro_pedido,vencida,id_clientes,idtransporte,id_vendedor,id_condicion")] Adpedidos adpedidos)
        {
            if (ModelState.IsValid)
            {
                db.Pedidos.Add(adpedidos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_clientes = new SelectList(db.Clientes, "id_clientes", "co_cli", adpedidos.id_clientes);
            ViewBag.id_condicion = new SelectList(db.CondicionesDePago, "id_condicion", "co_cond", adpedidos.id_condicion);
            ViewBag.idtransporte = new SelectList(db.Transportes, "idtransporte", "co_tran", adpedidos.idtransporte);
            ViewBag.id_vendedor = new SelectList(db.Vendedores, "id_vendedor", "co_ven", adpedidos.id_vendedor);
            return View(adpedidos);
        }

        // GET: Pedido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adpedidos adpedidos = db.Pedidos.Find(id);
            if (adpedidos == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_clientes = new SelectList(db.Clientes, "id_clientes", "co_cli", adpedidos.id_clientes);
            ViewBag.id_condicion = new SelectList(db.CondicionesDePago, "id_condicion", "co_cond", adpedidos.id_condicion);
            ViewBag.idtransporte = new SelectList(db.Transportes, "idtransporte", "co_tran", adpedidos.idtransporte);
            ViewBag.id_vendedor = new SelectList(db.Vendedores, "id_vendedor", "co_ven", adpedidos.id_vendedor);
            return View(adpedidos);
        }

        // POST: Pedido/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_doc_num,doc_num,descrip,co_cli,co_tran,co_mone,co_ven,co_cond,fec_emis,fec_venc,fec_reg,anulado,status,total_bruto,monto_imp,monto_imp2,monto_imp3,total_neto,saldo,importado_web,importado_pro,Diasvencimiento,nro_pedido,vencida,id_clientes,idtransporte,id_vendedor,id_condicion")] Adpedidos adpedidos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adpedidos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_clientes = new SelectList(db.Clientes, "id_clientes", "co_cli", adpedidos.id_clientes);
            ViewBag.id_condicion = new SelectList(db.CondicionesDePago, "id_condicion", "co_cond", adpedidos.id_condicion);
            ViewBag.idtransporte = new SelectList(db.Transportes, "idtransporte", "co_tran", adpedidos.idtransporte);
            ViewBag.id_vendedor = new SelectList(db.Vendedores, "id_vendedor", "co_ven", adpedidos.id_vendedor);
            return View(adpedidos);
        }

        // GET: Pedido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adpedidos adpedidos = db.Pedidos.Find(id);
            if (adpedidos == null)
            {
                return HttpNotFound();
            }
            return View(adpedidos);
        }

        // POST: Pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adpedidos adpedidos = db.Pedidos.Find(id);
            db.Pedidos.Remove(adpedidos);
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
