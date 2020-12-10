using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PagonetCore.Controllers
{
    public class VendedorController : Controller
    {
        // GET: Vendedor
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult listarVendedor()
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();
            var listarVendedor = bdsql.Advendedor.Select(p => new
            {
                p.id_vendedor,
                p.co_ven,
                p.tipo,
                p.ven_des,
                p.id_zona,
                p.co_zon,
                p.importado_web,
                p.importado_pro

            }).ToList();
            return Json(listarVendedor, JsonRequestBehavior.AllowGet);
        } 
        public JsonResult listarVendedores(int id)
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();
            var listarVendedores = bdsql.Advendedor.Where(p => p.id_vendedor.Equals(id))
                                   .Select(p => new { p.id_vendedor, p.co_ven, p.ven_des }).ToList();
            return Json(listarVendedores, JsonRequestBehavior.AllowGet);
        }
      
        public int guardaDatos(Advendedor oadvendedor)
        {
            int nregistrosafectados = 0;
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();
            try
            {
                if(oadvendedor.id_vendedor==0)
                {
                    bdsql.Advendedor.InsertOnSubmit(oadvendedor);
                    bdsql.SubmitChanges();
                    nregistrosafectados = 1;
                } else
                {

                }

            } catch(Exception ex)
            {
                 nregistrosafectados = 0;
            }
            return nregistrosafectados;
        }
        // cargar Combo 
        public JsonResult listarzonaid()
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();

            var listarzonaid = bdsql.Adzona
                .Select(p => new
                {
                    IID = p.id_zona,
                    CODIGO = p.co_zon,
                    NOMBRE = p.zon_des,
                }).ToList();
            return Json(listarzonaid, JsonRequestBehavior.AllowGet);
        }  
        
       
    }

}
      