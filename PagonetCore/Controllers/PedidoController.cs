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
            var itemsClientes = db.Clientes.Select(x => new
            {
                id_clientes = x.id_clientes,
                texto = x.co_cli + " - " + x.tip_cli + " - " + x.cli_des
            });

            ViewBag.id_clientes = new SelectList(itemsClientes, "id_clientes", "texto");

            var itemsCondicionPago = db.CondicionesDePago.Select(x => new
            {
                id_condicion = x.id_condicion,
                texto = x.co_cond + " - " + x.cond_des + " - " + x.dias_cred
            });

            ViewBag.id_condicion = new SelectList(itemsCondicionPago, "id_condicion", "texto");

            var itemsTransportes = db.Transportes.Select(x => new
            {
                idtransporte = x.idtransporte,
                texto = x.co_tran + " - " + x.des_tran
            });

            ViewBag.idtransporte = new SelectList(itemsTransportes, "idtransporte", "texto");

            var itemsVendedores = db.Vendedores.Select(x => new
            {
                id_vendedor = x.id_vendedor,
                texto = x.co_ven + " - " + x.tipo + " - " + x.ven_des + " - " + x.co_zon
            });

            ViewBag.id_vendedor = new SelectList(itemsVendedores, "id_vendedor", "texto");

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

            var itemsClientes = db.Clientes.Select(x => new
            {
                id_clientes = x.id_clientes,
                texto = x.co_cli + " - " + x.tip_cli + " - " + x.cli_des
            });

            ViewBag.id_clientes = new SelectList(itemsClientes, "id_clientes", "texto", adpedidos.id_clientes);

            var itemsCondicionPago = db.CondicionesDePago.Select(x => new
            {
                id_condicion = x.id_condicion,
                texto = x.co_cond + " - " + x.cond_des + " - " + x.dias_cred
            });

            ViewBag.id_condicion = new SelectList(itemsCondicionPago, "id_condicion", "texto", adpedidos.id_condicion);

            var itemsTransportes = db.Transportes.Select(x => new
            {
                idtransporte = x.idtransporte,
                texto = x.co_tran + " - " + x.des_tran
            });

            ViewBag.idtransporte = new SelectList(itemsTransportes, "idtransporte", "texto", adpedidos.idtransporte);

            var itemsVendedores = db.Vendedores.Select(x => new
            {
                id_vendedor = x.id_vendedor,
                texto = x.co_ven + " - " + x.tipo + " - " + x.ven_des + " - " + x.co_zon
            });

            ViewBag.id_vendedor = new SelectList(itemsVendedores, "id_vendedor", "texto", adpedidos.id_vendedor);

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
