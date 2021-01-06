using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PagonetCore.Models
{
    public class CotizacionRenglon
    {
        [Key]
        public int id { get; set; }

        public int? doc_num { get; set; }

        public string descrip { get; set; }

        public string co_cli { get; set; }

        public string co_tran { get; set; }

        public string co_mone { get; set; }

        public string co_ven { get; set; }

        public string co_cond { get; set; }

        public DateTime? fec_emis { get; set; }

        public DateTime? fec_venc { get; set; }

        public DateTime? fec_reg { get; set; }

        public string anulado { get; set; }

        public string status { get; set; }

        public decimal? total_bruto { get; set; }

        public decimal? monto_imp { get; set; }

        public decimal? monto_imp2 { get; set; }

        public decimal? monto_imp3 { get; set; }

        public decimal? total_neto { get; set; }

        public decimal? saldo { get; set; }

        public string importado_web { get; set; }

        public string importado_pro { get; set; }

        public int? Diasvencimiento { get; set; }

        public int? nro_pedido { get; set; }

        public string vencida { get; set; }

        // Claves Foráneas.

        public int id_clientes { get; set; }
        public int idtransporte { get; set; }
        public int id_vendedor { get; set; }
        public int id_condicion { get; set; }

        // Objetos de Renglones de Cotización.

        public ICollection<AdCotizacionreg> RenglonesCotizacion { get; set; }
    }
}