
namespace PagonetCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdCajas")]
    public class AdCajas
    {
        [Key]
        public int id_cajas { get; set; }

        [Display(Name = "Código")]
        public string co_cajas { get; set; }

        [StringLength(60)]
        [Display(Name = "Descripción")]
        public string des_cajas { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Importado Web?")]
        public string importado_web { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Importado Profit?")]
        public string importado_pro { get; set; }
    }
}