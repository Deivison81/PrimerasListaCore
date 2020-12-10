using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PagonetCore.Models
{
    public class AdSegmento
    {
       public int id_segmento { get; set; }
       public char co_seg { get; set; }
        public char seg_des { get; set; }
        public char importado_web { get; set; }
        public char importado_pro { get; set; }

    }
}