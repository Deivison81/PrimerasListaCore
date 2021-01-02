namespace PagonetCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdSegmento")]
    public partial class AdSegmento
    {
        [Key]
        public int id_segmento { get; set; }

        [Required]
        [StringLength(6)]
        public string co_seg { get; set; }

        [StringLength(60)]
        public string seg_des { get; set; }

        [StringLength(1)]
        public string importado_web { get; set; }

        [StringLength(1)]
        public string importado_pro { get; set; }
    }
}
