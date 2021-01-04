namespace PagonetCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdBanco")]
    public partial class AdBanco
    {
        [Key]
        [Column(Order = 0)]
        public int id_banco { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        [Display(Name = "Código")]
        public string co_ban { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(60)]
        [Display(Name = "Descripción")]
        public string des_ban { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Importado Web?")]
        public string importado_web { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Importado Profit?")]
        public string importado_pro { get; set; }
    }
}
