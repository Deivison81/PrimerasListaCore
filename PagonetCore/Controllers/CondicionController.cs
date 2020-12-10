using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PagonetCore.Controllers
{
    public class CondicionController : Controller
    {
        // GET: Condicion
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult listarCondiciones()
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();

            var listarCondiciones = bdsql.Adcondiciondepago.Select(p => new
            {
                p.id_condicion,
                p.co_cond,
                p.cond_des,
                p.dias_cred,
                p.importado_web,
                p.importado_pro

            }).ToList();
            return Json(listarCondiciones, JsonRequestBehavior.AllowGet);

           
        }

        public JsonResult listarCondicion(int id)
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();

            var listarCondicion = bdsql.Adcondiciondepago.Where(p=> p.id_condicion.Equals(id))
                .Select(p => new
            {
                p.id_condicion,
                p.co_cond,
                p.cond_des,
                p.dias_cred,
                p.importado_web,
                p.importado_pro

            }).ToList();
            return Json(listarCondicion, JsonRequestBehavior.AllowGet);


        }
        public JsonResult listarCondicion3(int id)
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();

            var listarCondicion3 = bdsql.Adcondiciondepago.Where(p => p.id_condicion.Equals(id))
                .Select(p => new
                {
                    p.id_condicion,
                    p.co_cond,
                    p.cond_des,
                    p.dias_cred,
                   

                }).ToList();
            return Json(listarCondicion3, JsonRequestBehavior.AllowGet);


        }
    }
}