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
        public string co_alma { get; set; }

        [StringLength(60)]
        public string des_alamacen { get; set; }

        [StringLength(1)]
        public string web { get; set; }

        [StringLength(6)]
        public string co_user_prof { get; set; }

        [StringLength(1)]
        public string importado_web { get; set; }

        [StringLength(1)]
        public string importado_pro { get; set; }
    }
}
