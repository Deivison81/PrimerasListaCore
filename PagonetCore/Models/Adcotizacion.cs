using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PagonetCore.Models
{
    public class Adcotizacion
    {
        public int id_doc_num { get; set; }
        public int doc_num { get; set; }
        public string descrip { get; set; }
        public int id_clientes { get; set; }
        public string co_cli { get; set; }
        public int idtransporte { get; set; }
        public char co_tran { get; set; }
        public char co_mone { get; set; }
        public int id_vendedor { get; set; }
        public char co_ven { get; set; } 
        public int id_condicion { get; set; }
        public char  co_cond { get; set; }
        public DateTime fec_emis { get; set; }
        public DateTime fec_venc { get; set; }
        public DateTime fec_reg { get; set; }
        public char anulado { get; set; }
        public char status { get; set; }
        public decimal total_bruto { get; set; }
        public decimal monto_imp { get; set; }
        public decimal monto_imp2 { get; set; }
        public decimal monto_imp3 { get; set; }
        public decimal total_neto { get; set; }
        public decimal saldo { get; set; }
        public char importado_web { get; set; }
        public char importado_pro { get; set; }
        public int Diasvencimiento { get; set; }
        public int nro_pedido { get; set; }
        public char vencida { get; set; }
    }
}