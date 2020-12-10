using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PagonetCore.Models
{
    public class adpreciosart
    {
        public int id_preciosart { get; set; }
        public int id_art { get; set; }
        public char co_art { get; set; }
        public char co_precios { get; set; }
        public DateTime desde { get; set; }
        public DateTime hasta { get; set; }
        public int cod_almacen { get; set; }
        public char co_alma { get; set; }
        public decimal monto { get; set; }
        public decimal montoadi1 { get; set; }
        public decimal montoadi2 { get; set; }
        public decimal montoadi3 { get; set; }
        public decimal montoadi4 { get; set; }
        public decimal montoadi5 { get; set; }
        public decimal precioOm { get; set; }
        public decimal importado_web { get; set; }
        public decimal importado_pro { get; set; }
    }
}