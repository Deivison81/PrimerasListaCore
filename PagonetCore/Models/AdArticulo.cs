namespace PagonetCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdArticulo")]
    public partial class AdArticulo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AdArticulo()
        {
            Adimg_art = new HashSet<Adimg_art>();
            adpreciosart = new HashSet<adpreciosart>();
            AdSerial = new HashSet<AdSerial>();
        }

        [Key]
        public int id_art { get; set; }

        [Required]
        [StringLength(30)]
        public string co_art { get; set; }

        [Required]
        [StringLength(120)]
        public string art_des { get; set; }

        [Required]
        [StringLength(6)]
        public string co_lin { get; set; }

        [Required]
        [StringLength(6)]
        public string co_subl { get; set; }

        [Required]
        [StringLength(6)]
        public string co_cat { get; set; }

        [Required]
        [StringLength(6)]
        public string co_color { get; set; }

        [Required]
        [StringLength(6)]
        public string co_ubicacion { get; set; }

        [StringLength(6)]
        public string cod_proc { get; set; }

        [Required]
        [StringLength(6)]
        public string cod_unidad { get; set; }

        [StringLength(20)]
        public string referencia { get; set; }

        [StringLength(1)]
        public string tipo_imp { get; set; }

        [StringLength(1)]
        public string tipo_imp2 { get; set; }

        [StringLength(1)]
        public string tipo_imp3 { get; set; }

        [StringLength(1)]
        public string importado_web { get; set; }

        [StringLength(1)]
        public string importado_pro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Adimg_art> Adimg_art { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<adpreciosart> adpreciosart { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdSerial> AdSerial { get; set; }
    }
}
