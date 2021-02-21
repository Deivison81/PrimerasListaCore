using System.ComponentModel.DataAnnotations;

namespace PagonetCore.Models
{
    public class StockAlma
    {
        [Key]
        public int StockAlmacenID { get; set; }

        [StringLength(30)]
        [Display(Name = "Código Almacén")]
        public string co_alma { get; set; }

        [StringLength(30)]
        [Display(Name = "Código Artículo")]
        public string co_art { get; set; }

        [StringLength(30)]
        [Display(Name = "Tipo")]
        public string tipo { get; set; }

        [Display(Name = "Stock")]
        public decimal stock { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Importado Web?")]
        public string importado_web { get; set; }

        [StringLength(1)]
        [Display(Name = "¿Importado Profit?")]
        public string importado_pro { get; set; }

        // Claves Foráneas.
        
        public int cod_almacen { get; set; }

        public int id_art { get; set; }

        public virtual AdAlmacen Almacen { get; set; }

        public virtual AdArticulo Articulo { get; set; }
    }
}