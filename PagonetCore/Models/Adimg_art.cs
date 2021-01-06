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
        [Display(Name = "ID Imagen Artículo")]
        public int id_imgart { get; set; }

        [StringLength(30)]
        [Display(Name = "Código de Artículo")]
        public string co_art { get; set; }

        [StringLength(6)]
        [Display(Name = "Tipo")]
        public string tip { get; set; }

        [StringLength(60)]
        [Display(Name = "Descripción")]
        public string imagen_des { get; set; }

        [Display(Name = "Foto")]
        public string picture { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Importado Web?")]
        public string importado_web { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Importado Profit?")]
        public string importado_pro { get; set; }

        // Claves Foráneas.

        public int id_art { get; set; }

        public virtual AdArticulo Articulo { get; set; }
    }
}
