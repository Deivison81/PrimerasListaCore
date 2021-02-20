namespace PagonetCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AdMovimientoBanco
    {
        [Key]
        [StringLength(20)]
        public string mov_num { get; set; }

        [StringLength(160)]
        public string descrip { get; set; }

        [Required]
        [StringLength(6)]
        public string cod_cta { get; set; }

        [Required]
        [StringLength(20)]
        public string co_cta_ingr_egr { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime fecha { get; set; }

        public decimal tasa { get; set; }

        [Required]
        [StringLength(2)]
        public string tipo_op { get; set; }

        [Required]
        [StringLength(20)]
        public string doc_num { get; set; }

        public decimal monto_d { get; set; }

        public decimal monto_h { get; set; }

        public decimal idb { get; set; }

        public bool saldo_ini { get; set; }

        [Required]
        [StringLength(3)]
        public string origen { get; set; }

        [StringLength(20)]
        public string cob_pag { get; set; }

        [StringLength(20)]
        public string dep_num { get; set; }

        public bool conciliado { get; set; }

        public bool ori_dep { get; set; }

        public bool anulado { get; set; }

        public int dep_con { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? fec_con { get; set; }

        [StringLength(6)]
        public string cod_ingben { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime fecha_che { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? feccom { get; set; }

        public int? numcom { get; set; }

        [Column(TypeName = "xml")]
        public string dis_cen { get; set; }

        [StringLength(60)]
        public string campo1 { get; set; }

        [StringLength(60)]
        public string campo2 { get; set; }

        [StringLength(60)]
        public string campo3 { get; set; }

        [StringLength(60)]
        public string campo4 { get; set; }

        [StringLength(60)]
        public string campo5 { get; set; }

        [StringLength(60)]
        public string campo6 { get; set; }

        [StringLength(60)]
        public string campo7 { get; set; }

        [StringLength(60)]
        public string campo8 { get; set; }

        [Required]
        [StringLength(6)]
        public string co_us_in { get; set; }

        [StringLength(6)]
        public string co_sucu_in { get; set; }

        public DateTime fe_us_in { get; set; }

        [Required]
        [StringLength(6)]
        public string co_us_mo { get; set; }

        [StringLength(6)]
        public string co_sucu_mo { get; set; }

        public DateTime fe_us_mo { get; set; }

        [StringLength(1)]
        public string trasnfe { get; set; }

        [StringLength(1)]
        public string revisado { get; set; }

        public int? nro_transf_nomi { get; set; }

        [StringLength(1)]
        public string importado_web { get; set; }

        [StringLength(1)]
        public string importado_pro { get; set; }
    }
}
