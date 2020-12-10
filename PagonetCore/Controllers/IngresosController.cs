using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PagonetCore.Controllers
{
    public class IngresosController : Controller
    {
        // GET: Ingresos
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult listaIngreso()
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();
            var listaIngreso = bdsql.AdIngreso.Select(p => new {

                p.id,
                p.co_ctaIng_egr,
                p.descrip_ingre,
                p.co_user_prof,
                p.importada_web,
                p.Imortada_prof


            }).ToList();
            return Json(listaIngreso, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listaIngresos(int id)
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();
            var listaIngresos = bdsql.AdIngreso.Where(p=> p.id.Equals(id)).Select(p => new {

                p.id,
                p.co_ctaIng_egr,
                p.descrip_ingre,
                p.co_user_prof,
                p.importada_web,
                p.Imortada_prof


            }).ToList();
            return Json(listaIngresos, JsonRequestBehavior.AllowGet);
        }
        public int guardarDatos(AdIngreso oadIngreso)
        {
            
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();
            int nregistrosafectados = 0;
            try
            {
                if(oadIngreso.id==0)
                {
                    bdsql.AdIngreso.InsertOnSubmit(oadIngreso);
                    bdsql.SubmitChanges();
                    nregistrosafectados = 1;
                }
                else
                {
                    AdIngreso adIngresosel = bdsql.AdIngreso.Where(p => p.id.Equals(oadIngreso.id)).First();
                    adIngresosel.co_ctaIng_egr = oadIngreso.co_ctaIng_egr;
                    adIngresosel.descrip_ingre = oadIngreso.descrip_ingre;
                    bdsql.SubmitChanges();
                    nregistrosafectados = 1;
                }

            }
            catch(Exception ex)
            {
               nregistrosafectados = 0;
            }
            return nregistrosafectados;
        }
    }
    
}