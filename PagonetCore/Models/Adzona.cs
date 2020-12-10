using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PagonetCore.Models
{
    public class Adzona
    {
       public int  id_zona { get; set; }
       public char co_zon { get; set; }
        public string zon_des { get; set; }
        public char importado_web { get; set; }
        public char importado_pro { get; set; }

    }
}