namespace PagonetCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Adcotizacion")]
    public partial class Adcotizacion
    {
        [Key]
        public int id_doc_num { get; set; }

        [Display(Name = "Número de Documento")]
        public int? doc_num { get; set; }

        [StringLength(60)]
        [Display(Name = "Descripción")]
        public string descrip { get; set; }

        [StringLength(16)]
        [Display(Name = "Código Cliente")]
        public string co_cli { get; set; }

        [StringLength(6)]
        [Display(Name = "Código de Transporte")]
        public string co_tran { get; set; }

        [StringLength(6)]
        [Display(Name = "Código de Moneda")]
        public string co_mone { get; set; }

        [StringLength(6)]
        [Display(Name = "Código de Vendedor")]
        public string co_ven { get; set; }

        [StringLength(6)]
        [Display(Name = "Código Condición de Pago")]
        public string co_cond { get; set; }

        [Column(TypeName = "smalldatetime")]
        [Display(Name = "Fecha Emisión")]
        public DateTime? fec_emis { get; set; }

        [Column(TypeName = "smalldatetime")]
        [Display(Name = "Fecha Vencimiento")]
        public DateTime? fec_venc { get; set; }

        [Column(TypeName = "smalldatetime")]
        [Display(Name = "Fecha Registro")]
        public DateTime? fec_reg { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Anulado?")]
        public string anulado { get; set; }

        [StringLength(1)]
        [Display(Name = "Estatus")]
        public string status { get; set; }

        [Display(Name = "Total Bruto")]
        public decimal? total_bruto { get; set; }

        [Display(Name = "Monto Impuesto")]
        public decimal? monto_imp { get; set; }

        [Display(Name = "Monto Impuesto 2")]
        public decimal? monto_imp2 { get; set; }

        [Display(Name = "Monto Impuesto 3")]
        public decimal? monto_imp3 { get; set; }

        [Display(Name = "Total Neto")]
        public decimal? total_neto { get; set; }

        [Display(Name = "Saldo")]
        public decimal? saldo { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Importado Web?")]
        public string importado_web { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Importado Profit?")]
        public string importado_pro { get; set; }

        [Display(Name = "Días de Vencimiento")]
        public int? Diasvencimiento { get; set; }

        [Display(Name = "Número de Pedido")]
        public int? nro_pedido { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Vencida?")]
        public string vencida { get; set; }

        // Claves Foráneas.
        
        public int id_clientes { get; set; }
        public int idtransporte { get; set; }
        public int id_vendedor { get; set; }
        public int id_condicion { get; set; }

        [Display(Name = "ID Cliente")]
        public virtual Adclientes Cliente { get; set; }

        [Display(Name = "ID Transporte")]
        public virtual Adtransporte Transporte { get; set; }

        [Display(Name = "ID Vendedor")]
        public virtual Advendedor Vendedor { get; set; }

        [Display(Name = "ID Condición de Pago")]
        public virtual Adcondiciondepago CondicionDePago { get; set; }
    }
}
