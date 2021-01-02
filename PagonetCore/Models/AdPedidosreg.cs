namespace PagonetCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdPedidosreg")]
    public partial class AdPedidosreg
    {
        [Key]
        public int RenglonPedidoID { get; set; }
        public int? id_doc_num { get; set; }
        [StringLength(20)]
        public string doc_num { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Adpedidos reng_num { get; set; }
        // TODO: Debe ser nullable. El operador ? no es soportado sino en C# >= 8.0,
        // y C# 8.0 solo es soportado en .NET Core (no .NET Framework).
        // Inicialmente: AdArticulo?
        public AdArticulo id_art { get; set; }
        [StringLength(30)]
        public string co_art { get; set; }
        [StringLength(120)]
        public string art_des { get; set; }
        // TODO: Debe ser nullable. El operador ? no es soportado sino en C# >= 8.0,
        // y C# 8.0 solo es soportado en .NET Core (no .NET Framework).
        // Inicialmente: AdAlmacen?
        public AdAlmacen cod_almacen { get; set; }
        [StringLength(6)]
        public string co_alma { get; set; }
        public decimal? total_art { get; set; }
        public decimal? stotal_art { get; set; }
        [StringLength(6)]
        public string cod_unidad { get; set; }
        public int? id_preciosart { get; set; }
        [StringLength(6)]
        public string co_precios { get; set; }
        public decimal? prec_vta { get; set; }
        public decimal? prec_vta_om { get; set; }
        [StringLength(1)]
        public string tipo_imp { get; set; }
        [StringLength(1)]
        public string tipo_imp2 { get; set; }
        [StringLength(1)]
        public string tipo_imp3 { get; set; }
        public decimal? porc_imp { get; set; }
        public decimal? porc_imp2 { get; set; }
        public decimal? porc_imp3 { get; set; }
        public decimal? monto_imp { get; set; }
        public decimal? monto_imp2 { get; set; }
        public decimal? monto_imp3 { get; set; }
        public decimal? reng_neto { get; set; }
        [StringLength(4)]
        public string tipo_doc { get; set; }
        [StringLength(20)]
        public string num_doc { get; set; }
        [StringLength(1)]
        public string importado_web { get; set; }
        [StringLength(1)]
        public string importado_pro { get; set; }
    }
}
