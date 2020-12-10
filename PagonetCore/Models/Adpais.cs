using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PagonetCore.Models
{
    public class Adpais
    {
        public int id_pais { get; set; }
        public string co_pais { get; set; }
        public string pais_des { get; set; }
        public char importado_web { get; set; }
        public char importado_pro { get; set; }
    }
}