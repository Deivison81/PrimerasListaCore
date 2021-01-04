using System.ComponentModel.DataAnnotations;

namespace PagonetCore.Models
{
    public class StockAlma
    {
        [Key]
        public int StockAlmacenID { get; set; }

        public char co_alma { get; set; }

        public char co_art { get; set; }

        public char tipo { get; set; }

        public decimal stock { get; set; }

        public char importado_web { get; set; }

        public char importado_pro { get; set; }

        // Claves Foráneas.
        
        public int cod_almacen { get; set; }

        public int id_art { get; set; }

        public virtual AdAlmacen Almacen { get; set; }

        public virtual AdArticulo Articulo { get; set; }
    }
}