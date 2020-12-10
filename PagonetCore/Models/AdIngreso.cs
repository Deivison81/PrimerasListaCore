using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PagonetCore.Models
{
    public class AdIngreso
    {
       public int id { get; set; }
       public char co_ctaIng_egr { get; set; }
        public string descrip_ingre { get; set; }
        public char co_user_prof { get; set; }
        public char importada_web { get; set; }
        public char Imortada_prof { get; set; }
    }
}