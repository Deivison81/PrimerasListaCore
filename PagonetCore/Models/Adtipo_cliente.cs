namespace PagonetCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Adtipo_cliente
    {
        [Key]
        public int id_tipocliente { get; set; }

        [Required]
        [StringLength(6)]
        [Display(Name = "Tipo Cliente")]
        public string tip_cli { get; set; }

        [StringLength(60)]
        [Display(Name = "Descripción")]
        public string des_tipo { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Importado Web?")]
        public string importado_web { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Importado Profit?")]
        public string importado_pro { get; set; }
    }
}
