using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PagonetCore.Models
{
    public class AdAlmacen
    {
        public int cod_almacen { get; set; }
        public string co_alma { get; set; }
        public string des_alamacen { get; set; }
        public char web { get; set; }
        public char co_user_prof { get; set; }
        public char importado_web { get; set; }
        public char importado_pro { get; set; }

    }
}