namespace PagonetCore.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AdArticulo")]
    public partial class AdArticulo
    {
        [Key]
        public int id_art { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Código")]
        public string co_art { get; set; }

        [Required]
        [StringLength(120)]
        [Display(Name = "Descripción")]
        public string art_des { get; set; }

        [Required]
        [StringLength(6)]
        [Display(Name = "Código LIN")]
        public string co_lin { get; set; }

        [Required]
        [StringLength(6)]
        [Display(Name = "Código Subl")]
        public string co_subl { get; set; }

        [Required]
        [StringLength(6)]
        [Display(Name = "Código Cat")]
        public string co_cat { get; set; }

        [Required]
        [StringLength(6)]
        [Display(Name = "Código Color")]
        public string co_color { get; set; }

        [Required]
        [StringLength(6)]
        [Display(Name = "Código Ubicación")]
        public string co_ubicacion { get; set; }

        [StringLength(6)]
        [Display(Name = "Código Proc")]
        public string cod_proc { get; set; }

        [Required]
        [StringLength(6)]
        [Display(Name = "Código Unidad")]
        public string cod_unidad { get; set; }

        [StringLength(20)]
        [Display(Name = "Referencia")]
        public string referencia { get; set; }

        [StringLength(1)]
        [Display(Name = "Tipo de Impuesto")]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "No aplica")]
        public string tipo_imp { get; set; }

        [StringLength(1)]
        [Display(Name = "Tipo de Impuesto 2")]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "No aplica")]
        public string tipo_imp2 { get; set; }

        [StringLength(1)]
        [Display(Name = "Tipo de Impuesto 3")]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "No aplica")]
        public string tipo_imp3 { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Importado Web?")]
        public string importado_web { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Importado Profit?")]
        public string importado_pro { get; set; }
    }
}
