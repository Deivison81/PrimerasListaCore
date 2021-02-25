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
        public int id_banco { get; set; }

        [Display(Name = "C�digo")]
        public string co_ban { get; set; }

        [StringLength(60)]
        [Display(Name = "Descripci�n")]
        public string des_ban { get; set; }

        [StringLength(1)]
        [Display(Name = "�Importado Web?")]
        public string importado_web { get; set; }

        [StringLength(1)]
        [Display(Name = "�Importado Profit?")]
        public string importado_pro { get; set; }
    }
}