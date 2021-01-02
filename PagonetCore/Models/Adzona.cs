namespace PagonetCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Adzona")]
    public partial class Adzona
    {
        [Key]
        public int id_zona { get; set; }

        [Required]
        [StringLength(6)]
        public string co_zon { get; set; }

        [StringLength(60)]
        public string zon_des { get; set; }

        [StringLength(1)]
        public string importado_web { get; set; }

        [StringLength(1)]
        public string importado_pro { get; set; }
    }
}
