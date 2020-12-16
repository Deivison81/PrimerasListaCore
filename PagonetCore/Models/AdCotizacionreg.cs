using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PagonetCore.Models
{
    public class AdCotizacionreg
    {
        public int reng_num { get; set; }
        public int doc_num { get; set; }
        public int id_doc_num { get; set; }
        public int id_art { get; set; }
        public string co_art { get; set; }
        public string art_des { get; set; }
        public int cod_almacen { get; set; }
        public char co_alma { get; set; }
        public decimal total_art { get; set; }
        public decimal stotal_art { get; set; }
        public char cod_unidad { get; set; }
        public int id_preciosart { get; set; }
        public char co_precios { get; set; }
        public decimal prec_vta { get; set; }
        public decimal prec_vta_om { get; set; }
        public char tipo_imp { get; set; }
        public char tipo_imp2 { get; set; }
        public char tipo_imp3 { get; set; }
        public decimal porc_imp { get; set; }
        public decimal porc_imp2 { get; set; }
        public decimal porc_imp3 { get; set; }
        public decimal monto_imp { get; set; }
        public  decimal monto_imp2 { get; set; }
        public decimal monto_imp3 { get; set; }
        public decimal reng_neto { get; set; }
        public char tipo_doc { get; set; }
        public string num_doc { get; set; }
        public char importado_web { get; set; }
        public char importado_pro { get; set; }
    }
}