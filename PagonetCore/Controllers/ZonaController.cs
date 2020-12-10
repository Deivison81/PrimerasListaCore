using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PagonetCore.Controllers
{
    public class ZonaController : Controller
    {
        // GET: Zona
        public ActionResult Index()
        {
            return View();
        }
        // GET: Zona
        public ActionResult zonaprofit()
        {
            return View();
        }

        public JsonResult listazona()
        {
            PagonetSQLDataContext dbsql = new PagonetSQLDataContext();

            var listazona = dbsql.Adzona.Select(p => new { p.id_zona, p.co_zon, p.zon_des, p.importado_web, p.importado_pro }).ToList();
            return Json(listazona, JsonRequestBehavior.AllowGet);
        }
        public JsonResult listazonas(int id)
        {
            PagonetSQLDataContext dbsql = new PagonetSQLDataContext();

            var listazona = dbsql.Adzona.Where(p => p.id_zona.Equals(id)).Select(p => new { p.id_zona, p.co_zon, p.zon_des}).ToList();
            return Json(listazona, JsonRequestBehavior.AllowGet);
        }
        public int guardarDatos(Adzona oadzona)
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();
            int nregistrosafectados = 0;
            try
            {
                if (oadzona.id_zona == 0)
                {
                    bdsql.Adzona.InsertOnSubmit(oadzona);
                    bdsql.SubmitChanges();
                    nregistrosafectados = 1;
                } else
                {
                    Adzona adzonasel = bdsql.Adzona.Where(P => P.id_zona.Equals(oadzona.id_zona)).First();
                    adzonasel.co_zon = oadzona.co_zon;
                    adzonasel.zon_des = oadzona.zon_des;
                    bdsql.SubmitChanges();
                    nregistrosafectados = 1;
                }
            } catch(Exception ex)
            {
                nregistrosafectados = 0;
            }
            return nregistrosafectados;
        }
        public JsonResult listarZonaprofit()
        {
            profitDataContext bdsql = new profitDataContext();

            var listarzonaprofit = bdsql.saZona.Select(p => new
            {
                p.co_zon,
                p.zon_des,
                p.campo1


            }).ToList();
            return Json(listarzonaprofit, JsonRequestBehavior.AllowGet);
        }
    }
}