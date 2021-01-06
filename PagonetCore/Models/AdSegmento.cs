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
        [Display(Name = "Código Segmento")]
        public string co_seg { get; set; }

        [StringLength(60)]
        [Display(Name = "Descripción Segmento")]
        public string seg_des { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Importado Web?")]
        public string importado_web { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Importado Profit?")]
        public string importado_pro { get; set; }
    }
}
