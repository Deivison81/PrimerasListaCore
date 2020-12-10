using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PagonetCore.Controllers
{
    public class TransporteController : Controller
    {
        // GET: Transporte
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult listarTransportes()
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();

            var listarTransportes = bdsql.Adtransporte.Select(p => new
            {
                p.idtransporte,
                p.co_tran,
                p.des_tran,
                p.importado_web,
                p.importado_pro

            }).ToList();
            return Json(listarTransportes, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listarTransporte(int id)
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();

            var listarTransporte = bdsql.Adtransporte.Where(p=> p.idtransporte.Equals(id))
                .Select(p => new
            {
                p.idtransporte,
                p.co_tran,
                p.des_tran,
                p.importado_web,
                p.importado_pro

            }).ToList();
            return Json(listarTransporte, JsonRequestBehavior.AllowGet);
        }
        public JsonResult listarTransportecot(int id)
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();

            var listarTransporte = bdsql.Adtransporte.Where(p => p.idtransporte.Equals(id))
                .Select(p => new
                {
                    p.idtransporte,
                    p.co_tran,
                    p.des_tran,
                   

                }).ToList();
            return Json(listarTransporte, JsonRequestBehavior.AllowGet);
        }
    }
}