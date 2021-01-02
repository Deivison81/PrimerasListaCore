namespace PagonetCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Adpedidos
    {
        [Key]
        public int id_doc_num { get; set; }

        [StringLength(20)]
        public string doc_num { get; set; }

        [StringLength(60)]
        public string descrip { get; set; }

        public Adclientes id_clientes { get; set; }

        [StringLength(16)]
        public string co_cli { get; set; }

        public Adtransporte idtransporte { get; set; }

        [StringLength(6)]
        public string co_tran { get; set; }

        [StringLength(6)]
        public string co_mone { get; set; }

        public Advendedor id_vendedor { get; set; }

        [StringLength(6)]
        public string co_ven { get; set; }

        public Adcondiciondepago id_condicion { get; set; }

        [StringLength(6)]
        public string co_cond { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? fec_emis { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? fec_venc { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? fec_reg { get; set; }

        [StringLength(1)]
        public string anulado { get; set; }

        [StringLength(1)]
        public string status { get; set; }

        public decimal? total_bruto { get; set; }

        public decimal? monto_imp { get; set; }

        public decimal? monto_imp2 { get; set; }

        public decimal? monto_imp3 { get; set; }

        public decimal? total_neto { get; set; }

        public decimal? saldo { get; set; }

        [StringLength(1)]
        public string importado_web { get; set; }

        [StringLength(1)]
        public string importado_pro { get; set; }

        public int? Diasvencimiento { get; set; }

        [StringLength(1)]
        public string nro_pedido { get; set; }

        [StringLength(1)]
        public string vencida { get; set; }
    }
}
