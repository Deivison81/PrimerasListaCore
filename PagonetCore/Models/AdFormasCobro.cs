namespace PagonetCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AdFormasCobro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int forma_cob_id { get; set; }

        public int nro_reng { get; set; }

        public int id_cob { get; set; }

        [StringLength(15)]
        public string cob_num_pro { get; set; }

        [StringLength(6)]
        public string co_ban { get; set; }

        [StringLength(2)]
        public string forma_pag { get; set; }

        [StringLength(6)]
        public string cod_cta { get; set; }

        [StringLength(6)]
        public string cod_caja { get; set; }

        [StringLength(20)]
        public string mov_num_c { get; set; }

        [StringLength(20)]
        public string mov_num_b { get; set; }

        public decimal? mont_doc { get; set; }

        [StringLength(1)]
        public string dolar { get; set; }

        [StringLength(1)]
        public string importado_web { get; set; }

        [StringLength(1)]
        public string importado_pro { get; set; }
    }
}
