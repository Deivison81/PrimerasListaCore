using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PagonetCore.Controllers
{
    public class cotizacionController : Controller
    {
        // GET: cotizacion
        public ActionResult Index()
        {
            return View();
        }
        //cabecera
        public JsonResult listarCotizacion() 
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();
            var listarcotizacion = bdsql.Adcotizacion.Select(p => new
            {
                p.id_doc_num,
                p.doc_num,
                p.descrip,
                p.id_clientes,
                p.co_cli,
                p.idtransporte,
                p.co_tran,
                p.co_mone,
                p.id_vendedor,
                p.co_ven,
                p.id_condicion,
                p.co_cond,
                p.fec_emis,
                p.fec_venc,
                p.fec_reg,
               // FECHAINI =  ((DateTime) p.fec_emis).ToShortDateString(),
               // FEVENC =((DateTime)p.fec_venc).ToShortDateString(),
               // FECREG = ((DateTime)p.fec_reg).ToShortDateString(),
                p.anulado,
                p.status,
                p.total_bruto,
                p.monto_imp,
                p.monto_imp2,
                p.monto_imp3,
                p.total_neto,
                p.saldo,
                p.importado_web,
                p.importado_pro,
                p.Diasvencimiento,
                p.nro_pedido,
                p.vencida
            }).ToList();
            return Json(listarcotizacion, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listarCotizacionid(int id)
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();
            var listarcotizacion = bdsql.Adcotizacion.Where(p=> p.id_doc_num.Equals(id)).Select(p => new
            {
                p.id_doc_num,
                p.doc_num,
                p.descrip,
                p.id_clientes,
                p.co_cli,
                p.idtransporte,
                p.co_tran,
                p.co_mone,
                p.id_vendedor,
                p.co_ven,
                p.id_condicion,
                p.co_cond,
                p.fec_emis,
                p.fec_venc,
                p.fec_reg,
                
                //FECHAINI = ((DateTime)p.fec_emis).ToShortDateString(),
                //FEVENC = ((DateTime)p.fec_venc).ToShortDateString(),
                //FECREG = ((DateTime)p.fec_reg).ToShortDateString(),
                p.anulado,
                p.status,
                p.total_bruto,
                p.monto_imp,
                p.monto_imp2,
                p.monto_imp3,
                p.total_neto,
                p.saldo,
                p.importado_web,
                p.importado_pro,
                p.Diasvencimiento,
                p.nro_pedido,
                p.vencida
            }).ToList();
            return Json(listarcotizacion, JsonRequestBehavior.AllowGet);
        }
        //renglones
        public JsonResult listarRenglones()
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();
            var listarrenglones = bdsql.AdCotizacionreg.Select(p => new
            {
                p.id_doc_num,
                p.doc_num,
                p.reng_num,
                p.id_art,
                p.co_art,
                p.art_des,
                p.cod_almacen,
                p.co_alma,
                p.total_art,
                p.stotal_art,
                p.cod_unidad,
                p.id_preciosart,
                p.co_precios,
                p.prec_vta,
                p.prec_vta_om,
                p.tipo_imp,
                p.tipo_imp2,
                p.tipo_imp3,
                p.porc_imp,
                p.porc_imp2,
                p.porc_imp3,
                p.monto_imp,
                p.monto_imp2,
                p.monto_imp3,
                p.reng_neto,
                p.tipo_doc,
                p.num_doc,
                p.importado_web,
                p.importado_pro
            }).ToList();
            return Json(listarrenglones, JsonRequestBehavior.AllowGet);

        }

        public JsonResult listarRenglonesid(int id)
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();
            var listarrenglones = bdsql.AdCotizacionreg.Where(p=> p.id_doc_num.Equals(id)) .Select(p => new
            {
                p.id_doc_num,
                p.doc_num,
                p.reng_num,
                p.id_art,
                p.co_art,
                p.art_des,
                p.cod_almacen,
                p.co_alma,
                p.total_art,
                p.stotal_art,
                p.cod_unidad,
                p.id_preciosart,
                p.co_precios,
                p.prec_vta,
                p.prec_vta_om,
                p.tipo_imp,
                p.tipo_imp2,
                p.tipo_imp3,
                p.porc_imp,
                p.porc_imp2,
                p.porc_imp3,
                p.monto_imp,
                p.monto_imp2,
                p.monto_imp3,
                p.reng_neto,
                p.tipo_doc,
                p.num_doc,
                p.importado_web,
                p.importado_pro
            }).ToList();
            return Json(listarrenglones, JsonRequestBehavior.AllowGet);

        }
        //subtablas
        public JsonResult listarCondicion()
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();

            var listarcondicion = bdsql.Adcondiciondepago.Select(p => new
            {
                IID = p.id_condicion,
                CODIGO = p.co_cond,
                NOMBRE = p.cond_des,
                DIAS = p.dias_cred
            }).ToList();

            return Json(listarcondicion, JsonRequestBehavior.AllowGet);


        }
        public JsonResult listarCliente()
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();

            var listarcliente = bdsql.Adclientes.Select(p => new
            {
                IID = p.id_clientes,
                CODIGO = p.co_cli,
                NOMBRE = p.cli_des
                
            }).ToList();

            return Json(listarcliente, JsonRequestBehavior.AllowGet);


        }
        public JsonResult listarVendedor()
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();

            var listarvendedor = bdsql.Advendedor.Select(p => new
            {
                IID = p.id_vendedor,
                CODIGO = p.co_ven,
                NOMBRE = p.ven_des
                
            }).ToList();

            return Json(listarvendedor, JsonRequestBehavior.AllowGet);


        }
        public JsonResult listarTransporte()
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();

            var listartransporte = bdsql.Adtransporte.Select(p => new
            {
                IID = p.idtransporte,
                CODIGO = p.co_tran,
                NOMBRE = p.des_tran

            }).ToList();

            return Json(listartransporte, JsonRequestBehavior.AllowGet);


        }
        
     
        // segccion de guardar cabecera
       public int guardarDatos(Adcotizacion Oadcotizacion) { 
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();

            int nroregistros = 0;
            try
            {
                if (Oadcotizacion.id_doc_num==0)
                {
                    bdsql.Adcotizacion.InsertOnSubmit(Oadcotizacion);
                    bdsql.SubmitChanges();
                    nroregistros = 1;
                }
                else
                {
                    Adcotizacion adcotizacionSel = bdsql.Adcotizacion.Where(p => p.id_doc_num.Equals(Oadcotizacion.id_doc_num)).First();

                    adcotizacionSel.id_doc_num = Oadcotizacion.id_doc_num;
                    adcotizacionSel.doc_num = Oadcotizacion.doc_num;
                    adcotizacionSel.descrip = Oadcotizacion.descrip;
                    adcotizacionSel.id_clientes = Oadcotizacion.id_clientes;
                    adcotizacionSel.co_cli = Oadcotizacion.co_cli;
                    adcotizacionSel.idtransporte = Oadcotizacion.idtransporte;
                    adcotizacionSel.co_tran = Oadcotizacion.co_tran;
                    adcotizacionSel.co_mone = Oadcotizacion.co_mone;
                    adcotizacionSel.id_vendedor = Oadcotizacion.id_vendedor;
                    adcotizacionSel.co_ven = Oadcotizacion.co_ven;
                    adcotizacionSel.id_condicion = Oadcotizacion.id_condicion;
                    adcotizacionSel.co_cond = Oadcotizacion.co_cond;
                    adcotizacionSel.fec_emis = Oadcotizacion.fec_emis;
                    adcotizacionSel.fec_venc = Oadcotizacion.fec_venc;
                    adcotizacionSel.fec_reg = Oadcotizacion.fec_reg;
                    adcotizacionSel.anulado = Oadcotizacion.anulado;
                    adcotizacionSel.status = Oadcotizacion.status;
                    adcotizacionSel.total_bruto = Oadcotizacion.total_bruto;
                    adcotizacionSel.monto_imp = Oadcotizacion.monto_imp;
                    adcotizacionSel.monto_imp2 = Oadcotizacion.monto_imp2;
                    adcotizacionSel.monto_imp3 = Oadcotizacion.monto_imp3;
                    adcotizacionSel.total_neto = Oadcotizacion.total_neto;
                    adcotizacionSel.saldo = Oadcotizacion.saldo;
                    adcotizacionSel.importado_web = Oadcotizacion.importado_web;
                    adcotizacionSel.importado_pro = Oadcotizacion.importado_pro;
                    adcotizacionSel.Diasvencimiento = Oadcotizacion.Diasvencimiento;
                    adcotizacionSel.nro_pedido = Oadcotizacion.nro_pedido;
                    adcotizacionSel.vencida = Oadcotizacion.vencida;
                    bdsql.SubmitChanges();
                    nroregistros = 1;
                }

            } catch (Exception ex)
            {
                 nroregistros = 0;
            }
            return nroregistros;
        }

        //seccion de guardar
        public int guardarDatosreng(AdCotizacionreg OadCotizacionreg)
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();
            
            int nroregistros=0;
            
            try
            {
                if (OadCotizacionreg.id_doc_num == 0)
                {
                    bdsql.AdCotizacionreg.InsertOnSubmit(OadCotizacionreg);
                    bdsql.SubmitChanges();
                    nroregistros = 1;
                }
                else
                {
                    AdCotizacionreg adCotizacionregSel = bdsql.AdCotizacionreg.Where(p => p.id_doc_num.Equals(OadCotizacionreg.id_doc_num)).First();
                    adCotizacionregSel.id_doc_num = OadCotizacionreg.id_doc_num;
                    adCotizacionregSel. doc_num = OadCotizacionreg.doc_num;
                    adCotizacionregSel.reng_num = OadCotizacionreg.reng_num;
                    adCotizacionregSel.id_art = OadCotizacionreg.id_art;
                    adCotizacionregSel.co_art = OadCotizacionreg.co_art;
                    adCotizacionregSel.art_des = OadCotizacionreg.art_des;
                    adCotizacionregSel.cod_almacen = OadCotizacionreg.cod_almacen;
                    adCotizacionregSel.co_alma = OadCotizacionreg.co_alma;
                    adCotizacionregSel.total_art = OadCotizacionreg.total_art;
                    adCotizacionregSel.stotal_art = OadCotizacionreg.stotal_art;
                    adCotizacionregSel.cod_unidad = OadCotizacionreg.cod_unidad;
                    adCotizacionregSel.id_preciosart = OadCotizacionreg.id_preciosart;
                    adCotizacionregSel.co_precios = OadCotizacionreg.co_precios;
                    adCotizacionregSel.prec_vta = OadCotizacionreg.prec_vta;
                    adCotizacionregSel.prec_vta_om = OadCotizacionreg.prec_vta_om;
                    adCotizacionregSel.tipo_imp = OadCotizacionreg.tipo_imp;
                    adCotizacionregSel.tipo_imp2 = OadCotizacionreg.tipo_imp2;
                    adCotizacionregSel.tipo_imp3 = OadCotizacionreg.tipo_imp3;
                    adCotizacionregSel.porc_imp = OadCotizacionreg.porc_imp;
                    adCotizacionregSel.porc_imp2 = OadCotizacionreg.porc_imp2;
                    adCotizacionregSel.porc_imp3 = OadCotizacionreg.porc_imp3;
                    adCotizacionregSel.monto_imp = OadCotizacionreg.monto_imp;
                    adCotizacionregSel.monto_imp2 = OadCotizacionreg.monto_imp2;
                    adCotizacionregSel.monto_imp3 = OadCotizacionreg.monto_imp3;
                    adCotizacionregSel.reng_neto = OadCotizacionreg.reng_neto;
                    adCotizacionregSel.tipo_doc = OadCotizacionreg.tipo_doc;
                    adCotizacionregSel.num_doc = OadCotizacionreg.num_doc;
                    adCotizacionregSel.importado_web = OadCotizacionreg.importado_web;
                    adCotizacionregSel.importado_pro = OadCotizacionreg.importado_pro;
                    //bdsql.SubmitChanges();
                    bdsql.AdCotizacionreg.InsertOnSubmit(adCotizacionregSel);

                    bdsql.SubmitChanges();
                    nroregistros = 1;
                }

            } catch (Exception ex)
            {
                nroregistros = 0;
            }
            return nroregistros;
        }
        //cabecera y renglones
        public JsonResult listarCotizacionCompleta()
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();

            var listarcotizacioncompleta = (from cabezas in bdsql.Adcotizacion
                                            join renglones in bdsql.AdCotizacionreg
                                            on cabezas.doc_num equals renglones.doc_num
                                            select new
                                            {
                                                cabezas.id_condicion,
                                                cabezas.doc_num,
                                                cabezas.descrip,
                                                cabezas.id_clientes,
                                                cabezas.co_cli,
                                                idcondicion = cabezas.id_condicion,
                                                cabezas.co_cond,
                                                cabezas.Diasvencimiento,
                                                cabezas.id_vendedor,
                                                cabezas.co_ven,
                                                cabezas.idtransporte,
                                                cabezas.fec_emis,
                                                cabezas.fec_venc,
                                                cabezas.fec_reg,
                                                cabezas.anulado,
                                                cabezas.status,
                                                cabezas.total_bruto,
                                                cabezas.monto_imp,
                                                cabezas.total_neto,
                                                cabezas.saldo,
                                                renglones.reng_num,
                                                renglones.id_art,
                                                renglones.co_art,
                                                renglones.art_des,
                                                renglones.cod_unidad,
                                                renglones.cod_almacen,
                                                renglones.co_alma,
                                                renglones.total_art,
                                                renglones.stotal_art,
                                                renglones.id_preciosart,
                                                renglones.co_precios,
                                                renglones.prec_vta,
                                                renglones.prec_vta_om,
                                                renglones.tipo_imp,
                                                renglones.porc_imp,
                                                IVA = renglones.monto_imp,
                                                renglones.reng_neto,
                                                renglones.tipo_doc,
                                                renglones.num_doc,
                                                renglones.importado_pro,
                                                renglones.importado_web


                                            }).OrderBy(p=> p.reng_num).ToList();

            return Json(listarcotizacioncompleta, JsonRequestBehavior.AllowGet);
        
        }
        public JsonResult listarCotizacionCompletaco(string codigo)
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();

            var  listarcotizacioncompletaco = (from cabezas in bdsql.Adcotizacion
                                            join renglones in bdsql.AdCotizacionreg
                                            on cabezas.doc_num equals renglones.doc_num
                                            where cabezas.doc_num.Equals(codigo)
                                            select new                                  
                                            {
                                                cabezas.id_condicion,
                                                cabezas.doc_num,
                                                cabezas.descrip,
                                                cabezas.id_clientes,
                                                cabezas.co_cli,
                                                idcondicion = cabezas.id_condicion,
                                                cabezas.co_cond,
                                                cabezas.Diasvencimiento,
                                                cabezas.id_vendedor,
                                                cabezas.co_ven,
                                                cabezas.idtransporte,
                                                cabezas.fec_emis,
                                                cabezas.fec_venc,
                                                cabezas.fec_reg,
                                                cabezas.anulado,
                                                cabezas.status,
                                                cabezas.total_bruto,
                                                cabezas.monto_imp,
                                                cabezas.total_neto,
                                                cabezas.saldo,
                                                renglones.reng_num,
                                                renglones.id_art,
                                                renglones.co_art,
                                                renglones.art_des,
                                                renglones.cod_unidad,
                                                renglones.cod_almacen,
                                                renglones.co_alma,
                                                renglones.total_art,
                                                renglones.stotal_art,
                                                renglones.id_preciosart,
                                                renglones.co_precios,
                                                renglones.prec_vta,
                                                renglones.prec_vta_om,
                                                renglones.tipo_imp,
                                                renglones.porc_imp,
                                                IVA = renglones.monto_imp,
                                                renglones.reng_neto,
                                                renglones.tipo_doc,
                                                renglones.num_doc,
                                                renglones.importado_pro,
                                                renglones.importado_web


                                            }).OrderBy(p => p.reng_num).ToList();

                return Json(listarcotizacioncompletaco, JsonRequestBehavior.AllowGet);



        }
        // Formato del JSON.
        // resultado: {
        //    "cotizacion": {
        //        ...
        //    },
        //    "renglon": {
        //        ...
        //    }
        // }

        /*public JsonResult guardarDatosCompletos(Object jsonCompleto)
        {
            Adcotizacion cotizacion = jsonCompleto.cotizacion;
            AdCotizacionreg renglon = jsonCompleto.renglon;
            return this.guardarDatosCompletosSeparado(cotizacion, renglon);
        }

        public JsonResult guardarDatosCompletosSeparado(Adcotizacion Oadcotizacion, AdCotizacionreg OadCotizacionreg)
        {
            // Invocar los métodos individuales para guardar AdCotizacion y AdCotizacionreg.
            int cotizacion = this.guardarDatos(Oadcotizacion);
            int renglon = this.guardarDatosreng(OadCotizacionreg);

           

            //return Json({ "cotizacion": cotizacion, "renglon": renglon }, JsonRequestBehavior.AllowPost );
            return cotizacion, renglon
            
        }*/
        public int Guardate(Adcotizacion Oadcotizacion, AdCotizacionreg OadCotizacionreg)
        {
            PagonetSQLDataContext bdsql = new PagonetSQLDataContext();
            int cantidadrenglon = OadCotizacionreg.reng_num;
            int nroregistros = 0;
            int nrorenglones = 0;

            try
            {   
                bdsql.Adcotizacion.InsertOnSubmit(Oadcotizacion);
                bdsql.SubmitChanges();
                nroregistros = 1;
                if (nroregistros == 1)
                {
                    Adcotizacion adcotizacionSel = bdsql.Adcotizacion.Where(p => p.id_doc_num.Equals(Oadcotizacion.id_doc_num)).First();
                    if (adcotizacionSel.id_doc_num == Oadcotizacion.id_doc_num)
                    {
                        (bdsql.Adcotizacion.Where(p => p.doc_num.Equals(Oadcotizacion.doc_num))).Count();
                        for (int i = 0; i >= nrorenglones; i++ )
                        {
                            bdsql.AdCotizacionreg.InsertOnSubmit(OadCotizacionreg);
                            bdsql.SubmitChanges();
                            nrorenglones = nrorenglones + 1;

                        }
                    }
                    else
                    {
                       return nrorenglones = 0;
                    }

                }
                else
                {
                    return nroregistros = 0;
                }

            }
            catch(Exception ex)
            {
                nroregistros = 0;
                nrorenglones = 0;
            }
             string nrocotizacion =  Oadcotizacion.doc_num;
            return (nroregistros + nrorenglones) + int.Parse(nrocotizacion);    

        }
    }
}