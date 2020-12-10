using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PagonetCore.Controllers
{
    public class AdpaisController : Controller
    {
        // GET: Adpais
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult listarPais()
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();

            var listarPais = bdsql.Adpais.Select(p => new
            {
                p.id_pais,
                p.co_pais,
                p.pais_des,
                p.importado_web,
                p.importado_pro



            }).ToList();
            return Json(listarPais, JsonRequestBehavior.AllowGet);
        }
        public JsonResult listarPais1(int id)
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();

            var listarPais1 = bdsql.Adpais.Where(p=> p.id_pais.Equals(id)). 
                Select(p => new
            {
                p.id_pais,
                p.co_pais,
                p.pais_des

            }).ToList();
            return Json(listarPais1, JsonRequestBehavior.AllowGet);
        }
        public int guardarDatos(Adpais Oadpais)
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();
            int nregistrosafectados = 0;

            try
            {
                if(Oadpais.id_pais == 0)
                {
                    bdsql.Adpais.InsertOnSubmit(Oadpais);
                    bdsql.SubmitChanges();
                    nregistrosafectados = 1;
                }
                else
                {
                    Adpais adpaissel = bdsql.Adpais.Where(p => p.id_pais.Equals(Oadpais.id_pais)).First();
                    adpaissel.co_pais = Oadpais.co_pais;
                    adpaissel.pais_des = Oadpais.pais_des;
                    nregistrosafectados = 1;
                }
            }
            catch (Exception ex)
            {
                nregistrosafectados = 0;
            }
            return nregistrosafectados;

        }
    }
}