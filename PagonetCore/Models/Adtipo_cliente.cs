using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PagonetCore.Models
{
    public class Adtipo_cliente
    {
        public int id_tipocliente { get; set; }
        public char tip_cli { get; set; }
        public string des_tipo { get; set; }
        public char importado_web { get; set; }
        public char importado_pro { get; set; }

    }
}