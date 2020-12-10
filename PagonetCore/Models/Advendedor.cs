using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PagonetCore.Models
{
    public class Advendedor
    {
        public int id_vendedor { get; set; }
        public char co_ven { get; set; }
        public char tipo { get; set; }
        public string ven_des { get; set; }
        public int id_zona { get; set; }
        public char co_zon { get; set; }
        public char importado_web { get; set; }
        public char importado_pro { get; set; }
    }
}