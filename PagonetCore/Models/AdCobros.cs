namespace PagonetCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AdCobros
    {
        [Key]
        public int id_cob { get; set; }

        [Required]
        [StringLength(15)]
        public string cob_num_pro { get; set; }

        public int id_clientes { get; set; }

        [StringLength(16)]
        public string co_cli { get; set; }

        [StringLength(6)]
        public string co_mone { get; set; }

        public int id_vendedor { get; set; }

        [StringLength(6)]
        public string co_ven { get; set; }

        public decimal? tasa { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? fecha { get; set; }

        [StringLength(1)]
        public string anulado { get; set; }

        public decimal? monto { get; set; }

        [StringLength(1)]
        public string importado_web { get; set; }

        [StringLength(1)]
        public string importado_pro { get; set; }

        [NotMapped]
        public virtual ICollection<AdRenglonesCobro> RenglonesCobro { get; set; }

        [NotMapped]
        public virtual ICollection<AdFormasCobro> FormasCobro { get; set; }
    }
}
