using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PagonetCore.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult listaCliente()
        { 
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();
            var listaCliente = bdsql.Adclientes.Select(p => new {
                p.id_clientes,
                p.co_cli,
                p.id_tipocliente,
                p.tip_cli,
                p.cli_des,
                p.direc1,
                p.dir_ent2,
                p.telefonos,
                p.inactivo,
                p.respons,
                p.id_zona,
                p.co_zon,
                p.id_segmento,
                p.co_seg,
                p.id_vendedor,
                p.co_ven,
                p.idingre,
                p.co_cta_ingr_egr,
                p.rif,
                p.email,
                p.juridico,
                p.ciudad,
                p.zip,
                p.id_pais,
                p.co_pais,
                p.cod_comercio,
                p.importado_web,
                p.importado_pro


            }).ToList();

            return Json(listaCliente, JsonRequestBehavior.AllowGet);
        }
        public JsonResult listaClientes(int id)
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();
            var listaClientes = bdsql.Adclientes.Where(p=> p.id_clientes.Equals(id))
                .Select(p => new {
                p.id_clientes,
                p.co_cli,
                p.id_tipocliente,
                p.tip_cli,
                p.cli_des,
                p.direc1,
                p.dir_ent2,
                p.telefonos,
                p.inactivo,
                p.respons,
                p.id_zona,
                p.co_zon,
                p.id_segmento,
                p.co_seg,
                p.id_vendedor,
                p.co_ven,
                p.idingre,
                p.co_cta_ingr_egr,
                p.rif,
                p.email,
                p.juridico,
                p.ciudad,
                p.zip,
                p.id_pais,
                p.co_pais,
                p.cod_comercio,
                p.importado_web,
                p.importado_pro


            }).ToList();

            return Json(listaClientes, JsonRequestBehavior.AllowGet);
        }

        //listar clientes en cotizacion
        // busquedar por codigo
        public JsonResult listaClientesb1(int id)
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();
            var listaClientes = bdsql.Adclientes.Where(p => p.id_clientes.Equals(id))
                .Select(p => new {
                    p.id_clientes,
                    p.co_cli,
                    p.cli_des,
                    


                }).ToList();

            return Json(listaClientes, JsonRequestBehavior.AllowGet);
        }
        //Busqueda por rif
        public JsonResult listaClientesxrif(string rif)
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();
            var listaClientes = bdsql.Adclientes.Where(p => p.rif.Equals(rif))
                .Select(p => new {
                    p.id_clientes,
                    p.co_cli,
                    p.cli_des,
                    p.cod_comercio,
                   


                }).ToList();

            return Json(listaClientes, JsonRequestBehavior.AllowGet);
        }
        //Busqueda por codigo de cliente
        public JsonResult listaClientesxcodigo(string codigo)
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();
            var listaClientes = bdsql.Adclientes.Where(p => p.co_cli.Equals(codigo))
                .Select(p => new {
                    p.id_clientes,
                    p.co_cli,
                    p.cli_des,
                    p.cod_comercio,



                }).ToList();

            return Json(listaClientes, JsonRequestBehavior.AllowGet);
        }


        //Agregar cliente
        public int guardarDatos(Adclientes Oadclientes)
        {
            PagonetSQLDataContext dbsql = new PagonetSQLDataContext();

            int nregistrosafectados = 0;
            try
            {
                if (Oadclientes.id_clientes==0)
                {   
                    dbsql.Adclientes.InsertOnSubmit(Oadclientes);
                    dbsql.SubmitChanges();
                    nregistrosafectados = 1;
                }
                else
                {
                    Adclientes adclientesSel = dbsql.Adclientes.Where(P => P.id_clientes.Equals(Oadclientes.id_clientes)).First();
                    adclientesSel.co_cli = Oadclientes.co_cli;
                    adclientesSel.id_tipocliente = Oadclientes.id_tipocliente;
                    adclientesSel.tip_cli = Oadclientes.tip_cli;
                    adclientesSel.cli_des = Oadclientes.cli_des;
                    adclientesSel.direc1 = Oadclientes.direc1;
                    adclientesSel.dir_ent2 = Oadclientes.dir_ent2;
                    adclientesSel.telefonos = Oadclientes.telefonos;
                    adclientesSel.inactivo = Oadclientes.inactivo;
                    adclientesSel.respons = Oadclientes.respons;
                    adclientesSel.id_zona = Oadclientes.id_zona;
                    adclientesSel.co_zon = Oadclientes.co_zon;
                    adclientesSel.id_segmento = Oadclientes.id_segmento;
                    adclientesSel.co_seg = Oadclientes.co_seg;
                    adclientesSel.id_vendedor = Oadclientes.id_vendedor;
                    adclientesSel.co_ven = Oadclientes.co_ven;
                    adclientesSel.idingre = Oadclientes.idingre;
                    adclientesSel.co_cta_ingr_egr = Oadclientes.co_cta_ingr_egr;
                    adclientesSel.rif = Oadclientes.rif;
                    adclientesSel.email = Oadclientes.email;
                    adclientesSel.juridico = Oadclientes.juridico;
                    adclientesSel.ciudad = Oadclientes.ciudad;
                    adclientesSel.zip = Oadclientes.zip;
                    adclientesSel.id_pais = Oadclientes.id_pais;
                    adclientesSel.co_pais = Oadclientes.co_pais;
                    adclientesSel.cod_comercio = Oadclientes.cod_comercio;
                    adclientesSel.importado_web = Oadclientes.importado_web;
                    adclientesSel.importado_pro = Oadclientes.importado_pro;
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
      
        public JsonResult Validacodigo()
        {
            PagonetSQLDataContext dbsql = new PagonetSQLDataContext();

            var listarcodigo = dbsql.Adclientes.OrderBy(p=> p.co_cli).Select(p => new
            {
                p.id_clientes,
                p.co_cli
            }).ToList();
            return Json(listarcodigo, JsonRequestBehavior.AllowGet);
            
        }
    }
  
}