namespace PagonetCore.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AdAlmacen")]
    public partial class AdAlmacen
    {
        [Key]
        public int cod_almacen { get; set; }

        [StringLength(6)]
        [Display(Name = "Código")]
        public string co_alma { get; set; }

        [StringLength(60)]
        [Display(Name = "Descripción")]
        public string des_alamacen { get; set; }

        [StringLength(1)]
        [Display(Name = "Web")]
        public string web { get; set; }

        [StringLength(6)]
        [Display(Name = "Código de Usuario Profit")]
        public string co_user_prof { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Importado Web?")]
        public string importado_web { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Importado Profit?")]
        public string importado_pro { get; set; }
    }
}
