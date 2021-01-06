using System.ComponentModel.DataAnnotations;

namespace PagonetCore.Models
{
    public class StockAlma
    {
        [Key]
        public int StockAlmacenID { get; set; }

        [Display(Name = "Código Almacén")]
        public char co_alma { get; set; }

        [Display(Name = "Código Artículo")]
        public char co_art { get; set; }

        [Display(Name = "Tipo")]
        public char tipo { get; set; }

        [Display(Name = "Stock")]
        public decimal stock { get; set; }

        [Display(Name = "¿Importado Web?")]
        public char importado_web { get; set; }

        [Display(Name = "¿Importado Profit?")]
        public char importado_pro { get; set; }

        // Claves Foráneas.
        
        public int cod_almacen { get; set; }

        public int id_art { get; set; }

        public virtual AdAlmacen Almacen { get; set; }

        public virtual AdArticulo Articulo { get; set; }
    }
}