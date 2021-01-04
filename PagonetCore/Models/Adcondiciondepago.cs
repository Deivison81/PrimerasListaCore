namespace PagonetCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Adcondiciondepago")]
    public partial class Adcondiciondepago
    {
        [Key]
        public int id_condicion { get; set; }

        [StringLength(6)]
        [Display(Name = "C�digo")]
        public string co_cond { get; set; }

        [StringLength(60)]
        [Display(Name = "Descripci�n")]
        public string cond_des { get; set; }

        [Display(Name = "D�as de Cr�dito")]
        public int? dias_cred { get; set; }

        [StringLength(1)]
        [Display(Name = "�Importado Web?")]
        public string importado_web { get; set; }

        [StringLength(1)]
        [Display(Name = "�Importado Profit?")]
        public string importado_pro { get; set; }
    }
}
