using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PagonetCore.Models
{
    public class StockAlma
    {
        public int cod_almacen { get; set;}
        public char co_alma { get; set; }
        public int id_art { get; set; }
        public char co_art { get; set; }
        public char tipo { get; set; }
        public decimal stock { get; set; }
        public char importado_web { get; set; }
        public char importado_pro { get; set; }
    }
}