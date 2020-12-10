using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PagonetCore.Models
{
    public class sazona
    {
        public string co_zon { get; set; }
        public string zon_des { get; set; } 
        public int numcom { get; set; }
        public DateTime feccom { get; set; }
        public object dis_cen { get; set; }
        public string campo1 { get; set; }
        public string campo2 { get; set; }
        public string campo3 { get; set; }
        public string campo4 { get; set; }
        public string campo5 { get; set; }
        public string campo6 { get; set; }
        public string campo7 { get; set; }
        public string campo8 { get; set; }
        public char co_us_in { get; set; }
        public char co_sucu_in { get; set; }
        public DateTime fe_us_in { get; set; }
        public char co_us_mo { get; set; }
        public char co_sucu_mo { get; set; }
        public DateTime fe_us_mo { get; set; }
        public char revisado { get; set; }
        public char trasnfe { get; set; }
        public object validador { get; set; } 
        public object rowguid { get; set; }
    }
}