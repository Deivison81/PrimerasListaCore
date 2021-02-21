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

        public int guardarDatos(Adcondiciondepago adCondicionPago)
        {
            try
            {
                PagonetSQLDataContext dbsql = new PagonetSQLDataContext();
                dbsql.Adcondiciondepago.InsertOnSubmit(adCondicionPago);
                dbsql.SubmitChanges();
                return 1;
            } catch (Exception ex)
            {
                // TODO: Arrojar excepción.
                return 0;
            }
        }

        public int modificarDatos(Adcondiciondepago adCondicionPago)
        {
            try
            {
                PagonetSQLDataContext dbsql = new PagonetSQLDataContext();
                Adcondiciondepago condicion = dbsql.Adcondiciondepago.Where(p => p.id_condicion.Equals(adCondicionPago.id_condicion)).First();

                condicion.co_cond = adCondicionPago.co_cond;
                condicion.cond_des = adCondicionPago.cond_des;
                condicion.dias_cred = adCondicionPago.dias_cred;
                condicion.importado_web = adCondicionPago.importado_web;
                condicion.importado_pro = adCondicionPago.importado_pro;

				dbsql.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {
                // TODO: Arrojar excepción.
                return 0;
            }
        }
    }
}