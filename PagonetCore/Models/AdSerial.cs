namespace PagonetCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdSerial")]
    public partial class AdSerial
    {
        [Key]
        public int reng_num { get; set; }

        [StringLength(30)]
        [Display(Name = "Código Artículo")]
        public string co_art { get; set; }

        [StringLength(6)]
        [Display(Name = "Código Almacén")]
        public string co_alma { get; set; }

        [StringLength(40)]
        [Display(Name = "Serial")]
        public string serial { get; set; }

        [StringLength(40)]
        [Display(Name = "Tipo Dispositivo")]
        public string tip_dispositivo { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Importado Web?")]
        public string importado_web { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Importado Profit?")]
        public string importado_pro { get; set; }

        // Claves Foráneas.
        
        public int id_art { get; set; }

        public int cod_almacen { get; set; }

        public virtual AdArticulo Articulo { get; set; }

        public virtual AdAlmacen Almacen { get; set; }
    }
}
