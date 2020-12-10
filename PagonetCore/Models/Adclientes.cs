using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PagonetCore.Models
{
    public class Adclientes
    {
        public int id_clientes { get; set; }
        public string co_cli { get; set; }
        public int id_tipocliente { get; set; }
        public char tip_cli { get; set; }
        public string cli_des { get; set; }
        public string direc1 { get; set; }
        public string dir_ent2 { get; set; }
        public string telefonos { get; set; }
        public char inactivo { get; set; }
        public string respons { get; set; }
        public int id_zona { get; set; }
        public char co_zon { get; set; }
        public int id_segmento { get; set; }
        public char co_seg { get; set; }
        public int id_vendedor { get; set; }
        public char co_ven { get; set; }
        public int idingre { get; set; }
        public char co_cta_ingr_egr { get; set; }
        public string rif { get; set; }
        public string email { get; set; }
        public char juridico { get; set; }
        public string ciudad { get; set; }
        public string zip { get; set; }
        public int id_pais { get; set; }
        public char co_pais { get; set; }
        public string cod_comercio { get; set; }
        public char importado_web { get; set; }
        public char importado_pro { get; set; }
    }
}