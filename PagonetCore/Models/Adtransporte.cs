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
        public string co_tran { get; set; }

        [StringLength(60)]
        public string des_tran { get; set; }

        [StringLength(1)]
        public string importado_web { get; set; }

        [StringLength(1)]
        public string importado_pro { get; set; }
    }
}
