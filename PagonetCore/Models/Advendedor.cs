namespace PagonetCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Advendedor")]
    public partial class Advendedor
    {
        [Key]
        public int id_vendedor { get; set; }

        [StringLength(6)]
        public string co_ven { get; set; }

        [StringLength(4)]
        public string tipo { get; set; }

        [StringLength(60)]
        public string ven_des { get; set; }

        public Adzona id_zona { get; set; }

        [Required]
        [StringLength(6)]
        public string co_zon { get; set; }

        [StringLength(1)]
        public string importado_web { get; set; }

        [StringLength(1)]
        public string importado_pro { get; set; }
    }
}
