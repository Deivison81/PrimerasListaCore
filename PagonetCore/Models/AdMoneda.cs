namespace PagonetCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AdMoneda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_moneda { get; set; }

        [StringLength(6)]
        public string co_mone { get; set; }

        [StringLength(60)]
        public string mone_des { get; set; }

        [StringLength(1)]
        public string importado_web { get; set; }

        [StringLength(1)]
        public string importado_pro { get; set; }
    }
}
