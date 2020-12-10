using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PagonetCore.Controllers
{
    public class SegmentoController : Controller
    {
        // GET: Segmento
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult listarSegmento()
        {
            PagonetSQLDataContext dbsql = new PagonetSQLDataContext();

            var listarSegmento = dbsql.AdSegmento.Select(p => new {

                p.id_segmento,
                p.co_seg,
                p.seg_des,
                p.importado_web,
                p.importado_pro


            }).ToList();
            return Json(listarSegmento, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listarSegmentos(int id)
        {
            PagonetSQLDataContext dbsql = new PagonetSQLDataContext();

            var listarSegmentos = dbsql.AdSegmento.Where(p=> p.id_segmento.Equals(id)).Select(p => new {

                p.id_segmento,
                p.co_seg,
                p.seg_des,
                p.importado_web,
                p.importado_pro


            }).ToList();
            return Json(listarSegmentos, JsonRequestBehavior.AllowGet);
        }
        public int GuardarDatos(AdSegmento OadSegmento)
        {
            PagonetSQLDataContext dbsql = new PagonetSQLDataContext();
            int nregistrosafectados = 0;
            try
            {
                if (OadSegmento.id_segmento == 0)
                {
                    dbsql.AdSegmento.InsertOnSubmit(OadSegmento);
                    dbsql.SubmitChanges();
                    nregistrosafectados = 1;
                }
                else
                {
                    AdSegmento adSegmentoSel = dbsql.AdSegmento.Where(P => P.id_segmento.Equals(OadSegmento.id_segmento)).First();
                    adSegmentoSel.co_seg = OadSegmento.co_seg;
                    adSegmentoSel.seg_des = OadSegmento.seg_des;
                    dbsql.SubmitChanges();
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