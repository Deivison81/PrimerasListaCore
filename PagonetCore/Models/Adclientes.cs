namespace PagonetCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Adclientes
    {
        [Key]
        public int id_clientes { get; set; }

        [Required]
        [StringLength(16)]
        public string co_cli { get; set; }

        public Adtipo_cliente id_tipocliente { get; set; }

        [Required]
        [StringLength(6)]
        public string tip_cli { get; set; }

        [Required]
        [StringLength(100)]
        public string cli_des { get; set; }

        [Required]
        public string direc1 { get; set; }

        [Required]
        public string dir_ent2 { get; set; }

        [Required]
        [StringLength(60)]
        public string telefonos { get; set; }

        [Required]
        [StringLength(1)]
        public string inactivo { get; set; }

        [Required]
        [StringLength(60)]
        public string respons { get; set; }

        public Adzona id_zona { get; set; }

        [Required]
        [StringLength(6)]
        public string co_zon { get; set; }

        public AdSegmento id_segmento { get; set; }

        [Required]
        [StringLength(6)]
        public string co_seg { get; set; }

        public Advendedor id_vendedor { get; set; }

        [Required]
        [StringLength(6)]
        public string co_ven { get; set; }

        public AdIngreso idingre { get; set; }

        [Required]
        [StringLength(6)]
        public string co_cta_ingr_egr { get; set; }

        [Required]
        [StringLength(18)]
        public string rif { get; set; }

        [Required]
        [StringLength(60)]
        public string email { get; set; }

        [Required]
        [StringLength(1)]
        public string juridico { get; set; }

        [Required]
        [StringLength(50)]
        public string ciudad { get; set; }

        [Required]
        [StringLength(10)]
        public string zip { get; set; }

        public int id_pais { get; set; }

        [Required]
        [StringLength(6)]
        public string co_pais { get; set; }

        [StringLength(20)]
        public string cod_comercio { get; set; }

        [StringLength(1)]
        public string importado_web { get; set; }

        [StringLength(1)]
        public string importado_pro { get; set; }
    }
}
