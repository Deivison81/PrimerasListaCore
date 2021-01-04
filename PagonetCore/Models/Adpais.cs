namespace PagonetCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Adpais
    {
        [Key]
        public int id_pais { get; set; }

        [StringLength(6)]
        [Display(Name = "Código País")]
        public string co_pais { get; set; }

        [StringLength(60)]
        [Display(Name = "Descripción")]
        public string pais_des { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Importado Web?")]
        public string importado_web { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Importado Profit?")]
        public string importado_pro { get; set; }
    }
}
