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
        [Display(Name = "Código")]
        public string co_ven { get; set; }

        [StringLength(4)]
        [Display(Name = "Tipo")]
        public string tipo { get; set; }

        [StringLength(60)]
        [Display(Name = "Descripción")]
        public string ven_des { get; set; }

        [Required]
        [StringLength(6)]
        [Display(Name = "Código Zona")]
        public string co_zon { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Importado Web?")]
        public string importado_web { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Importado Profit?")]
        public string importado_pro { get; set; }

        // Claves Foráneas.

        public int id_zona { get; set; }

        public virtual Adzona Zona { get; set; }
    }
}
