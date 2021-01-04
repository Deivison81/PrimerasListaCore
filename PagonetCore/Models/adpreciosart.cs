namespace PagonetCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("adpreciosart")]
    public partial class adpreciosart
    {
        [Key]
        public int id_preciosart { get; set; }

        [Required]
        [StringLength(30)]
        public string co_art { get; set; }

        [Required]
        [StringLength(6)]
        public string co_precios { get; set; }

        public DateTime? desde { get; set; }

        public DateTime? hasta { get; set; }

        [StringLength(6)]
        public string co_alma { get; set; }

        public decimal monto { get; set; }

        public decimal? montoadi1 { get; set; }

        public decimal? montoadi2 { get; set; }

        public decimal? montoadi3 { get; set; }

        public decimal? montoadi4 { get; set; }

        public decimal? montoadi5 { get; set; }

        [StringLength(1)]
        public string precioOm { get; set; }

        [StringLength(1)]
        public string importado_web { get; set; }

        [StringLength(1)]
        public string importado_pro { get; set; }

        // Claves Foráneas.
        
        public int id_art { get; set; }

        public int cod_almacen { get; set; }

        public virtual AdArticulo Articulo { get; set; }

        public virtual AdAlmacen Almacen { get; set; }
    }
}
