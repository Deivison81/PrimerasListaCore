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
        [Display(Name = "N�mero de Documento")]
        public string doc_num { get; set; }

        [StringLength(60)]
        [Display(Name = "Descripci�n")]
        public string descrip { get; set; }

        [StringLength(16)]
        [Display(Name = "C�digo de Cliente")]
        public string co_cli { get; set; }

        [StringLength(6)]
        [Display(Name = "C�digo de Transporte")]
        public string co_tran { get; set; }

        [StringLength(6)]
        [Display(Name = "C�digo de Moneda")]
        public string co_mone { get; set; }

        [StringLength(6)]
        [Display(Name = "C�digo de Vendedor")]
        public string co_ven { get; set; }

        [StringLength(6)]
        [Display(Name = "C�digo Condici�n de Pago")]
        public string co_cond { get; set; }

        [Column(TypeName = "smalldatetime")]
        [Display(Name = "Fecha de Emisi�n")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd-MM-yyyy HH:mm:ss}", NullDisplayText = "Sin Fecha")]
        public DateTime? fec_emis { get; set; }

        [Column(TypeName = "smalldatetime")]
        [Display(Name = "Fecha de Vencimiento")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd-MM-yyyy HH:mm:ss}", NullDisplayText = "Sin Fecha")]
        public DateTime? fec_venc { get; set; }

        [Column(TypeName = "smalldatetime")]
        [Display(Name = "Fecha de Registro")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd-MM-yyyy HH:mm:ss}", NullDisplayText = "Sin Fecha")]
        public DateTime? fec_reg { get; set; }

        [StringLength(1)]
        [Display(Name = "�Anulado?")]
        public string anulado { get; set; }

        [StringLength(1)]
        [Display(Name = "Estatus")]
        public string status { get; set; }

        [Display(Name = "Total Bruto")]
        public decimal? total_bruto { get; set; }

        [Display(Name = "Monto de Impuesto")]
        public decimal? monto_imp { get; set; }

        [Display(Name = "Monto de Impuesto 2")]
        public decimal? monto_imp2 { get; set; }

        [Display(Name = "Monto de Impuesto 3")]
        public decimal? monto_imp3 { get; set; }

        [Display(Name = "Total Neto")]
        public decimal? total_neto { get; set; }

        [Display(Name = "Saldo")]
        public decimal? saldo { get; set; }

        [StringLength(1)]
        [Display(Name = "�Importado Web?")]
        public string importado_web { get; set; }

        [StringLength(1)]
        [Display(Name = "�Importado Profit?")]
        public string importado_pro { get; set; }

        [Display(Name = "D�as de Vencimiento")]
        public int? Diasvencimiento { get; set; }

        [StringLength(1)]
        [Display(Name = "N�mero de Pedido")]
        public string nro_pedido { get; set; }

        [StringLength(1)]
        [Display(Name = "�Vencida?")]
        public string vencida { get; set; }

        // Claves For�neas.
        
        public int id_clientes { get; set; }

        public int idtransporte { get; set; }

        public int id_vendedor { get; set; }

        public int id_condicion { get; set; }

        public virtual Adclientes Cliente { get; set; }

        public virtual Adtransporte Transporte { get; set; }

        public virtual Advendedor Vendedor { get; set; }

        public virtual Adcondiciondepago CondicionDePago { get; set; }
    }
}