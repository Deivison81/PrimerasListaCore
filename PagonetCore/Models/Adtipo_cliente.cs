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
        public string tip_cli { get; set; }

        [StringLength(60)]
        public string des_tipo { get; set; }

        [StringLength(1)]
        public string importado_web { get; set; }

        [StringLength(1)]
        public string importado_pro { get; set; }
    }
}
