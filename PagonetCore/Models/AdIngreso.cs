namespace PagonetCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdIngreso")]
    public partial class AdIngreso
    {
        [Key]
        public int id { get; set; }

        [StringLength(20)]
        [Display(Name = "C�digo de Cuenta Ingreso/Egreso")]
        public string co_ctaIng_egr { get; set; }

        [StringLength(60)]
        [Display(Name = "Descripci�n")]
        public string descrip_ingre { get; set; }

        [StringLength(6)]
        [Display(Name = "C�digo de Usuario Profit")]
        public string co_user_prof { get; set; }

        [StringLength(1)]
        [Display(Name = "�Importado Web?")]
        public string importado_web { get; set; }

        [StringLength(1)]
        [Display(Name = "�Importado Profit?")]
        public string importado_pro { get; set; }
    }
}
