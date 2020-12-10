using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PagonetCore.Models
{
    public class Adimg_art
    {
        public int id_imgart { get; set; }
        public int id_art { get; set; }
        public char co_art { get; set; }
        public char tip { get; set; }
        public char imagen_des { get; set; }
        public string picture { get; set; }
        public char importado_web { get; set; }
        public char importado_pro { get; set; }

    }
}