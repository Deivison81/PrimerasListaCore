using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PagonetCore.Controllers
{
    public class AlmacenController : Controller
    {
        // GET: Almacen
        public ActionResult Index()
        {
            return View();
        } 
        public JsonResult listarAlmacen()
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();

            var listarAlmacen = bdsql.AdAlmacen.Select(p => new
            {
                p.cod_almacen,
                p.co_alma,
                p.des_alamacen,
                p.web,
                p.co_user_prof,
                p.importado_web,
                p.importado_pro

            }).ToList();
            return Json(listarAlmacen, JsonRequestBehavior.AllowGet);
        }
        // alamacen tabla completa
        public JsonResult listarAlmacens(int id)
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();

            var listarAlmacen = bdsql.AdAlmacen.Where(p=> p.cod_almacen.Equals(id)) 
                .Select(p => new
            {
                p.cod_almacen,
                p.co_alma,
                p.des_alamacen,
                

            }).ToList();
            return Json(listarAlmacen, JsonRequestBehavior.AllowGet);
        }
        public JsonResult listarAlmacensb1(string almacen)
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();

            var listarAlmacen = bdsql.AdAlmacen.Where(p => p.co_alma.Equals(almacen))
                .Select(p => new
                {
                    p.cod_almacen,
                    p.co_alma,
                    p.des_alamacen,
                    p.web,
                   

                }).ToList();
            return Json(listarAlmacen, JsonRequestBehavior.AllowGet);
        }
        public int guardarDatos(AdAlmacen OadAlmacen)
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();

            int nroregistros = 0;
            try
            {
                if (OadAlmacen.cod_almacen == 0)
                {
                    bdsql.AdAlmacen.InsertOnSubmit(OadAlmacen);
                    bdsql.SubmitChanges();
                    nroregistros = 1;
                }
                else
                {
                    AdAlmacen adAlmacensel = bdsql.AdAlmacen.Where(p => p.cod_almacen.Equals(OadAlmacen)).First();
                              adAlmacensel.co_alma = OadAlmacen.co_alma;
                              adAlmacensel.des_alamacen = OadAlmacen.des_alamacen;
                              bdsql.SubmitChanges();
                              nroregistros = 1;
                }
            } catch (Exception ex)
            {
                nroregistros = 0;
            }

            return nroregistros;
        }
    }
}