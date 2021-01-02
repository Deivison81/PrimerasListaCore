namespace PagonetCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdIngreso")]
    public partial class AdIngreso
    {
        public int id { get; set; }

        [StringLength(20)]
        public string co_ctaIng_egr { get; set; }

        [StringLength(60)]
        public string descrip_ingre { get; set; }

        [StringLength(6)]
        public string co_user_prof { get; set; }

        [StringLength(1)]
        public string importado_web { get; set; }

        [StringLength(1)]
        public string importado_pro { get; set; }
    }
}
