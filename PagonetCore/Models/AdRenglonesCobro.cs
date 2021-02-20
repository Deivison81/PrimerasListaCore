namespace PagonetCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AdRenglonesCobro
    {
        public int reng_num { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_cob { get; set; }

        [Required]
        [StringLength(15)]
        public string cob_num_pro { get; set; }

        [StringLength(6)]
        public string co_tipo_doc { get; set; }

        [StringLength(20)]
        public string nro_doc { get; set; }

        public decimal? mont_cob { get; set; }

        public decimal? dpcobro_monto { get; set; }

        [StringLength(4)]
        public string tipo_doc { get; set; }

        [StringLength(20)]
        public string num_doc { get; set; }

        public decimal? saldo { get; set; }

        [StringLength(1)]
        public string importado_web { get; set; }

        [StringLength(1)]
        public string importado_pro { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idrencob { get; set; }
    }
}
