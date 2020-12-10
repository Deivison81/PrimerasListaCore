using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PagonetCore.Models
{
    public class Adcondiciondepago
    {
        public int id_condicion { get; set; }
        public char co_cond { get; set; }
        public string cond_des { get; set; }
        public int dias_cred { get; set; }
        public char importado_web { get; set; }
        public char importado_pro { get; set; }
    }
}