namespace PagonetCore.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AdCotizacionreg")]
    public partial class AdCotizacionreg
    {
        [Key]
        public int id_doc_num { get; set; }

        [Display(Name = "N�mero de Documento")]
        public int? doc_num { get; set; }

        [Display(Name = "N�mero de Rengl�n")]
        public int reng_num { get; set; }

        [StringLength(30)]
        [Display(Name = "C�digo de Art�culo")]
        public string co_art { get; set; }

        [StringLength(120)]
        [Display(Name = "Descripci�n de Art�culo")]
        public string art_des { get; set; }

        [StringLength(6)]
        [Display(Name = "C�digo de Almac�n")]
        public string co_alma { get; set; }

        [Display(Name = "Total Art�culos")]
        public decimal? total_art { get; set; }

        [Display(Name = "Subtotal Art�culos")]
        public decimal? stotal_art { get; set; }

        [StringLength(6)]
        [Display(Name = "C�digo de Unidad")]
        public string cod_unidad { get; set; }

        [StringLength(6)]
        [Display(Name = "C�digo de Precio")]
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

        [Display(Name = "Rengl�n Neto")]
        public decimal? reng_neto { get; set; }

        [StringLength(4)]
        [Display(Name = "Tipo de Documento")]
        public string tipo_doc { get; set; }

        [StringLength(20)]
        [Display(Name = "N�mero de Documento")]
        public string num_doc { get; set; }

        [StringLength(1)]
        [Display(Name = "�Importado Web?")]
        public string importado_web { get; set; }

        [StringLength(1)]
        [Display(Name = "�Importado Profit?")]
        public string importado_pro { get; set; }

        // Claves For�neas.

        public int id_art { get; set; }

        public int cod_almacen { get; set; }

        public int id_preciosart { get; set; }

        // TODO: Debe ser nullable. El operador ? no es soportado sino en C# >= 8.0,
        // y C# 8.0 solo es soportado en .NET Core (no .NET Framework).
        // Inicialmente: AdArticulo?
        [Display(Name = "ID Art�culo")]
        public virtual AdArticulo Articulo { get; set; }

        // TODO: Debe ser nullable. El operador ? no es soportado sino en C# >= 8.0,
        // y C# 8.0 solo es soportado en .NET Core (no .NET Framework).
        // Inicialmente: AdAlmacen?
        [Display(Name = "C�digo de Almac�n")]
        public virtual AdAlmacen Almacen { get; set; }

        // TODO: Debe ser nullable. El operador ? no es soportado sino en C# >= 8.0,
        // y C# 8.0 solo es soportado en .NET Core (no .NET Framework).
        // Inicialmente: adpreciosart?
        [Display(Name = "ID Precio Art�culo")]
        public virtual adpreciosart PrecioArticulo { get; set; }
    }
}
