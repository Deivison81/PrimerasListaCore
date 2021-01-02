namespace PagonetCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tasa_IVA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_impuesto { get; set; }

        public DateTime fechapubli { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int nro_reng { get; set; }

        public int tip_impu { get; set; }

        [Required]
        [StringLength(1)]
        public string ventas { get; set; }

        [StringLength(1)]
        public string consumosuntuario { get; set; }

        public decimal porcentajetaza { get; set; }

        public decimal? porcentajesuntuario { get; set; }

        [StringLength(1)]
        public string importado_web { get; set; }

        [StringLength(1)]
        public string importado_pro { get; set; }
    }
}
