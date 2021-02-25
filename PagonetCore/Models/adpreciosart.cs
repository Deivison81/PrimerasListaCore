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
        [Display(Name = "Código Artículo")]
        public string co_art { get; set; }

        [Required]
        [StringLength(6)]
        [Display(Name = "Código Precio")]
        public string co_precios { get; set; }

        [Display(Name = "Desde")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd-MM-yyyy HH:mm:ss}", NullDisplayText = "Sin Fecha")]
        public DateTime? desde { get; set; }

        [Display(Name = "Hasta")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd-MM-yyyy HH:mm:ss}", NullDisplayText = "Sin Fecha")]
        public DateTime? hasta { get; set; }

        [StringLength(6)]
        [Display(Name = "Código Almacén")]
        public string co_alma { get; set; }

        [Display(Name = "Monto")]
        public decimal monto { get; set; }

        [Display(Name = "Monto Adicional 1")]
        public decimal? montoadi1 { get; set; }

        [Display(Name = "Monto Adicional 2")]
        public decimal? montoadi2 { get; set; }

        [Display(Name = "Monto Adicional 3")]
        public decimal? montoadi3 { get; set; }

        [Display(Name = "Monto Adicional 4")]
        public decimal? montoadi4 { get; set; }

        [Display(Name = "Monto Adicional 5")]
        public decimal? montoadi5 { get; set; }

        [StringLength(1)]
        [Display(Name = "Precio OM")]
        public string precioOm { get; set; }

        [Display(Name = "Tasa del Día")]
        public decimal? tasa_v { get; set; }

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
