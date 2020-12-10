using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PagonetCore.Controllers
{
    public class StockController : Controller
    {
        // GET: Stock
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult listarStock()
        {
            PagonetSQLDataContext dbsql = new PagonetSQLDataContext();

            var listarStock = dbsql.StockAlma.Select(p => new
            {
                p.cod_almacen,
                p.co_alma,
                p.id_art,
                p.co_art,
                p.tipo,
                p.stock,
                p.importado_web,
                p.importado_pro

            }).ToList();
            return Json(listarStock, JsonRequestBehavior.AllowGet);
        }
        public JsonResult listarStocks(int idalma, int idart)
        {
            PagonetSQLDataContext dbsql = new PagonetSQLDataContext();

            var listarStock = dbsql.StockAlma.Where(P=> P.cod_almacen.Equals(idalma) && P.id_art.Equals(idart))
                .Select(p => new
            {
                p.cod_almacen,
                p.co_alma,
                p.id_art,
                p.co_art,
                p.tipo,
                p.stock,
                p.importado_web,
                p.importado_pro

            }).ToList();
            return Json(listarStock, JsonRequestBehavior.AllowGet);
        }
    }
    
}