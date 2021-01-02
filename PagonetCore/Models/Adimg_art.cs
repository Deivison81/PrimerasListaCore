namespace PagonetCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Adimg_art
    {
        [Key]
        [Column(Order = 0)]
        public int id_imgart { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public AdArticulo id_art { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(30)]
        public string co_art { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(6)]
        public string tip { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(60)]
        public string imagen_des { get; set; }

        [Key]
        [Column(Order = 5)]
        public string picture { get; set; }

        [StringLength(1)]
        public string importado_web { get; set; }

        [StringLength(1)]
        public string importado_pro { get; set; }

        public virtual AdArticulo AdArticulo { get; set; }
    }
}
