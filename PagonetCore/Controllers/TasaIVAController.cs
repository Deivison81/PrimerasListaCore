using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PagonetCore.Controllers
{
    public class TasaIVAController : Controller
    {
        // GET: TasaIVA
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ListarIVA()
        {
            PagonetSQLDataContext dbsql = new PagonetSQLDataContext();

            var listarIVA = dbsql.Tasa_IVA.Select(p => new
            {
                p.id_impuesto,
                p.fechapubli,
                p.nro_reng,
                p.tip_impu,
                p.ventas,
                p.consumosuntuario,
                p.porcentajetaza,
                p.porcentajesuntuario,
                p.importado_web,
                p.importado_pro



            }).ToList();
            return Json(listarIVA, JsonRequestBehavior.AllowGet);
        }
    }
}