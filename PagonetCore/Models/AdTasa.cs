namespace PagonetCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AdTasa
    {
        [Key]
        public int idmone { get; set; }

        [StringLength(6)]
        public string co_mone { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? fecha { get; set; }

        public decimal? tasa_c { get; set; }

        public decimal? tasa_v { get; set; }

        [StringLength(1)]
        public string importado_web { get; set; }

        [StringLength(1)]
        public string importado_pro { get; set; }
    }
}
