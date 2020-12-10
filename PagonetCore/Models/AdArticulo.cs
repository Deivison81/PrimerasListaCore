using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PagonetCore.Models
{
    public class AdArticulo
    {
       public int  id_art { get; set; }
       public char co_art { get; set; }
        public char art_des { get; set; }
        public char co_lin { get; set; }
        public char co_subl { get; set; }
        public char co_cat { get; set; }
        public char co_color { get; set; }
        public char co_ubicacion { get; set; }
        public char cod_proc { get; set; }
        public char cod_unidad { get; set; }
        public string referencia { get; set; }
        public char importado_web { get; set; }
        public char importado_pro { get; set; }
        
    }
}