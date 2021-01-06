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
        [Display(Name = "C�digo")]
        public string co_cli { get; set; }

        [Required]
        [StringLength(6)]
        [Display(Name = "Tipo de Cliente")]
        public string tip_cli { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Descripci�n")]
        public string cli_des { get; set; }

        [Required]
        [Display(Name = "Direcci�n")]
        public string direc1 { get; set; }

        [Required]
        [Display(Name = "Direcci�n 2")]
        public string dir_ent2 { get; set; }

        [Required]
        [StringLength(60)]
        [Display(Name = "Telef�no")]
        public string telefonos { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "�Inactivo?")]
        public string inactivo { get; set; }

        [Required]
        [StringLength(60)]
        [Display(Name = "Responsable")]
        public string respons { get; set; }

        [Required]
        [StringLength(6)]
        [Display(Name = "C�digo Zona")]
        public string co_zon { get; set; }

        [Required]
        [StringLength(6)]
        [Display(Name = "C�digo Segmento")]
        public string co_seg { get; set; }

        [Required]
        [StringLength(6)]
        [Display(Name = "C�digo Vendedor")]
        public string co_ven { get; set; }

        [Required]
        [StringLength(6)]
        [Display(Name = "C�digo Cuenta Ingreso/Egreso")]
        public string co_cta_ingr_egr { get; set; }

        [Required]
        [StringLength(18)]
        [Display(Name = "RIF")]
        public string rif { get; set; }

        [Required]
        [StringLength(60)]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "�Jur�dico?")]
        public string juridico { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Ciudad")]
        public string ciudad { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "ZIP")]
        public string zip { get; set; }

        [Required]
        [StringLength(6)]
        [Display(Name = "C�digo Pa�s")]
        public string co_pais { get; set; }

        [StringLength(20)]
        [Display(Name = "C�digo Comercio")]
        public string cod_comercio { get; set; }

        [StringLength(1)]
        [Display(Name = "�Importado Web?")]
        public string importado_web { get; set; }

        [StringLength(1)]
        [Display(Name = "�Importado Profit?")]
        public string importado_pro { get; set; }

        // Claves For�neas.

        public int id_tipocliente { get; set; }

        public int id_vendedor { get; set; }

        public int idingre { get; set; }

        public int id_zona { get; set; }

        public int id_segmento { get; set; }

        public int id_pais { get; set; }

        public virtual Adtipo_cliente TipoCliente { get; set; }

        public virtual Advendedor Vendedor { get; set; }

        [ForeignKey("idingre")]
        public virtual AdIngreso Ingreso { get; set; }

        public virtual Adzona Zona { get; set; }

        public virtual AdSegmento Segmento { get; set; }

        public virtual Adpais Pais { get; set; }
    }
}
