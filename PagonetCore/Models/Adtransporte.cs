namespace PagonetCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Adtransporte")]
    public partial class Adtransporte
    {
        [Key]
        public int idtransporte { get; set; }

        [StringLength(6)]
        [Display(Name = "Código")]
        public string co_tran { get; set; }

        [StringLength(60)]
        [Display(Name = "Descripción")]
        public string des_tran { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Transporte Local?")]
        public string transporte_local { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Importado Web?")]
        public string importado_web { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Importado Profit?")]
        public string importado_pro { get; set; }
    }
}
