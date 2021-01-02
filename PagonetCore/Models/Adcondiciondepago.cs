namespace PagonetCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Adcondiciondepago")]
    public partial class Adcondiciondepago
    {
        [Key]
        public int id_condicion { get; set; }

        [StringLength(6)]
        public string co_cond { get; set; }

        [StringLength(60)]
        public string cond_des { get; set; }

        public int? dias_cred { get; set; }

        [StringLength(1)]
        public string importado_web { get; set; }

        [StringLength(1)]
        public string importado_pro { get; set; }
    }
}
