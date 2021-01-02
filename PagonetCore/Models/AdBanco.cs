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
        public string co_ban { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(60)]
        public string des_ban { get; set; }

        [StringLength(1)]
        public string importado_web { get; set; }

        [StringLength(1)]
        public string importado_pro { get; set; }
    }
}
