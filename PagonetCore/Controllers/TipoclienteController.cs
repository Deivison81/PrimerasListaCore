using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PagonetCore.Controllers
{
    public class TipoclienteController : Controller
    {
        // GET: Tipocliente
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult listatipo(int id)
        {
            PagonetSQLDataContext dbsql = new PagonetSQLDataContext();

            var listatipo = dbsql.Adtipo_cliente.Where(p => p.id_tipocliente.Equals(id))
                            .Select(p => new { p.id_tipocliente, p.tip_cli, p.des_tipo, p.importado_web, p.importado_pro }).ToList();
            return Json(listatipo, JsonRequestBehavior.AllowGet);
        }
        public JsonResult listatipot()
        {
            PagonetSQLDataContext dbsql = new PagonetSQLDataContext();

            var listatipo = dbsql.Adtipo_cliente.Select(p => new { p.id_tipocliente, p.tip_cli, p.des_tipo, p.importado_web, p.importado_pro }).ToList();
            return Json(listatipo, JsonRequestBehavior.AllowGet);
        }
        public int guardarDatos(Adtipo_cliente otipoclientes)
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();

            int nregistrosafectados = 0;

            try
            {
                if (otipoclientes.id_tipocliente == 0)
                {
                    bdsql.Adtipo_cliente.InsertOnSubmit(otipoclientes);
                    bdsql.SubmitChanges();
                    nregistrosafectados = 1;
                }
                else
                {
                    Adtipo_cliente adtipo_ClienteSel = bdsql.Adtipo_cliente.Where(p => p.id_tipocliente.Equals(otipoclientes.id_tipocliente)).First();
                    adtipo_ClienteSel.tip_cli = otipoclientes.tip_cli;
                    adtipo_ClienteSel.des_tipo = otipoclientes.des_tipo;
                    bdsql.SubmitChanges();
                    nregistrosafectados = 1;
                }
            }catch
            {
                nregistrosafectados = 0;
            }

            return nregistrosafectados;

        }
    }
}


