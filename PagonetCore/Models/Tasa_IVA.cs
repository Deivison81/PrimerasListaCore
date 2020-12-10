using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PagonetCore.Models
{
    public class Tasa_IVA
    {
        public int id_impuesto { get; set; }
        public DateTime fechapubli { get; set; }
        public int nro_reng { get; set; }
        public int tip_impu { get; set; }
        public char ventas { get; set; }
        public char consumosuntuario { get; set; }
        public decimal porcentajetaza { get; set; }
        public decimal porcentajesuntuario { get; set; }
        public char importado_web { get; set; }
        public char importado_pro { get; set; }
    }
}