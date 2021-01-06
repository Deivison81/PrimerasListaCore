namespace PagonetCore.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AdCotizacionreg")]
    public partial class AdCotizacionreg
    {
        [Key]
        public int id_doc_num { get; set; }

        [Display(Name = "Número de Documento")]
        public int? doc_num { get; set; }

        [Display(Name = "Número de Renglón")]
        public int reng_num { get; set; }

        [StringLength(30)]
        [Display(Name = "Código de Artículo")]
        public string co_art { get; set; }

        [StringLength(120)]
        [Display(Name = "Descripción de Artículo")]
        public string art_des { get; set; }

        [StringLength(6)]
        [Display(Name = "Código de Almacén")]
        public string co_alma { get; set; }

        [Display(Name = "Total Artículos")]
        public decimal? total_art { get; set; }

        [Display(Name = "Subtotal Artículos")]
        public decimal? stotal_art { get; set; }

        [StringLength(6)]
        [Display(Name = "Código de Unidad")]
        public string cod_unidad { get; set; }

        [StringLength(6)]
        [Display(Name = "Código de Precio")]
        public string co_precios { get; set; }

        [Display(Name = "Precio de Venta")]
        public decimal? prec_vta { get; set; }

        [Display(Name = "Precio de Venta OM")]
        public decimal? prec_vta_om { get; set; }

        [StringLength(1)]
        [Display(Name = "Tipo de Impuesto")]
        public string tipo_imp { get; set; }

        [StringLength(1)]
        [Display(Name = "Tipo de Impuesto 2")]
        public string tipo_imp2 { get; set; }

        [StringLength(1)]
        [Display(Name = "Tipo de Impuesto 3")]
        public string tipo_imp3 { get; set; }

        [Display(Name = "Porcentaje de Impuesto")]
        public decimal? porc_imp { get; set; }

        [Display(Name = "Porcentaje de Impuesto 2")]
        public decimal? porc_imp2 { get; set; }

        [Display(Name = "Porcentaje de Impuesto 3")]
        public decimal? porc_imp3 { get; set; }

        [Display(Name = "Monto de Impuesto")]
        public decimal? monto_imp { get; set; }

        [Display(Name = "Monto de Impuesto 2")]
        public decimal? monto_imp2 { get; set; }

        [Display(Name = "Monto de Impuesto 3")]
        public decimal? monto_imp3 { get; set; }

        [Display(Name = "Renglón Neto")]
        public decimal? reng_neto { get; set; }

        [StringLength(4)]
        [Display(Name = "Tipo de Documento")]
        public string tipo_doc { get; set; }

        [StringLength(20)]
        [Display(Name = "Número de Documento")]
        public string num_doc { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Importado Web?")]
        public string importado_web { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Importado Profit?")]
        public string importado_pro { get; set; }

        // Claves Foráneas.

        public int id_art { get; set; }

        public int cod_almacen { get; set; }

        public int id_preciosart { get; set; }

        // TODO: Debe ser nullable. El operador ? no es soportado sino en C# >= 8.0,
        // y C# 8.0 solo es soportado en .NET Core (no .NET Framework).
        // Inicialmente: AdArticulo?
        [Display(Name = "ID Artículo")]
        public virtual AdArticulo Articulo { get; set; }

        // TODO: Debe ser nullable. El operador ? no es soportado sino en C# >= 8.0,
        // y C# 8.0 solo es soportado en .NET Core (no .NET Framework).
        // Inicialmente: AdAlmacen?
        [Display(Name = "Código de Almacén")]
        public virtual AdAlmacen Almacen { get; set; }

        // TODO: Debe ser nullable. El operador ? no es soportado sino en C# >= 8.0,
        // y C# 8.0 solo es soportado en .NET Core (no .NET Framework).
        // Inicialmente: adpreciosart?
        [Display(Name = "ID Precio Artículo")]
        public virtual adpreciosart PrecioArticulo { get; set; }
    }
}
