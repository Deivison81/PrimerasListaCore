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
            var clientes = db.Clientes.Include(a => a.TipoCliente).Include(a => a.Ingreso).Include(a => a.Pais).Include(a => a.Segmento).Include(a => a.Vendedor).Include(a => a.Zona);
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
            var itemsTipoCliente = db.TiposCliente.Select(x => new
            {
                id_tipocliente = x.id_tipocliente,
                texto = x.tip_cli + " - " + x.des_tipo
            });

            ViewBag.id_tipocliente = new SelectList(itemsTipoCliente, "id_tipocliente", "texto");

            //ViewBag.id_tipocliente = new SelectList(db.TiposCliente, "id_tipocliente", "tip_cli");

            var itemsIngresos = db.Ingresos.Select(x => new
            {
                id = x.id,
                texto = x.co_ctaIng_egr + " - " + x.descrip_ingre
            });

            ViewBag.id = new SelectList(itemsIngresos, "id", "texto");

            //ViewBag.idingre = new SelectList(db.Ingresos, "id", "co_ctaIng_egr");

            var itemsPaises = db.Paises.Select(x => new
            {
                id_pais = x.id_pais,
                texto = x.co_pais + " - " + x.pais_des
            });

            ViewBag.id_pais = new SelectList(itemsPaises, "id_pais", "texto");

            //ViewBag.id_pais = new SelectList(db.Paises, "id_pais", "co_pais");

            var itemsSegmentos = db.Segmentos.Select(x => new
            {
                id_segmento = x.id_segmento,
                texto = x.co_seg + " - " + x.seg_des
            });

            ViewBag.id_segmento = new SelectList(itemsSegmentos, "id_segmento", "texto");

            //ViewBag.id_segmento = new SelectList(db.Segmentos, "id_segmento", "co_seg");

            var itemsVendedores = db.Vendedores.Select(x => new
            {
                id_vendedor = x.id_vendedor,
                texto = x.co_ven + " - " + x.tipo + " - " + x.ven_des + " - " + x.co_zon
            });

            ViewBag.id_vendedor = new SelectList(itemsVendedores, "id_vendedor", "texto");

            //ViewBag.id_vendedor = new SelectList(db.Vendedores, "id_vendedor", "co_ven");

            var itemsZona = db.Zonas.Select(x => new
            {
                id_zona = x.id_zona,
                texto = x.co_zon + " - " + x.zon_des
            });

            ViewBag.id_zona = new SelectList(itemsZona, "id_zona", "texto");

            //ViewBag.id_zona = new SelectList(db.Zonas, "id_zona", "co_zon");
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

            var itemsTipoCliente = db.TiposCliente.Select(x => new
            {
                id_tipocliente = x.id_tipocliente,
                texto = x.tip_cli + " - " + x.des_tipo
            });

            ViewBag.id_tipocliente = new SelectList(itemsTipoCliente, "id_tipocliente", "texto", adclientes.id_tipocliente);

            //ViewBag.id_tipocliente = new SelectList(db.TiposCliente, "id_tipocliente", "tip_cli", adclientes.id_tipocliente);

            var itemsIngresos = db.Ingresos.Select(x => new
            {
                id = x.id,
                texto = x.co_ctaIng_egr + " - " + x.descrip_ingre
            });

            ViewBag.id = new SelectList(itemsIngresos, "id", "texto", adclientes.idingre);

            //ViewBag.idingre = new SelectList(db.Ingresos, "id", "co_ctaIng_egr", adclientes.idingre);

            var itemsPaises = db.Paises.Select(x => new
            {
                id_pais = x.id_pais,
                texto = x.co_pais + " - " + x.pais_des
            });

            ViewBag.id_pais = new SelectList(itemsPaises, "id_pais", "texto", adclientes.id_pais);

            //ViewBag.id_pais = new SelectList(db.Paises, "id_pais", "co_pais", adclientes.id_pais);

            var itemsSegmentos = db.Segmentos.Select(x => new
            {
                id_segmento = x.id_segmento,
                texto = x.co_seg + " - " + x.seg_des
            });

            ViewBag.id_segmento = new SelectList(itemsSegmentos, "id_segmento", "texto", adclientes.id_segmento);

            //ViewBag.id_segmento = new SelectList(db.Segmentos, "id_segmento", "co_seg", adclientes.id_segmento);

            var itemsVendedores = db.Vendedores.Select(x => new
            {
                id_vendedor = x.id_vendedor,
                texto = x.co_ven + " - " + x.tipo + " - " + x.ven_des + " - " + x.co_zon
            });

            ViewBag.id_vendedor = new SelectList(itemsVendedores, "id_vendedor", "texto", adclientes.id_vendedor);

            //ViewBag.id_vendedor = new SelectList(db.Vendedores, "id_vendedor", "co_ven", adclientes.id_vendedor);

            var itemsZona = db.Zonas.Select(x => new
            {
                id_zona = x.id_zona,
                texto = x.co_zon + " - " + x.zon_des
            });

            ViewBag.id_zona = new SelectList(itemsZona, "id_zona", "texto", adclientes.id_zona);

            //ViewBag.id_zona = new SelectList(db.Zonas, "id_zona", "co_zon", adclientes.id_zona);

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
