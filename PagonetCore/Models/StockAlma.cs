using System.ComponentModel.DataAnnotations;

namespace PagonetCore.Models
{
    public class StockAlma
    {
        [Key]
        public int StockAlmacenID { get; set; }
        // Inicialmente cod_almacen era de tipo int.
        public AdAlmacen cod_almacen { get; set;} 
        public char co_alma { get; set; }
        public AdArticulo id_art { get; set; }
        public char co_art { get; set; }
        public char tipo { get; set; }
        public decimal stock { get; set; }
        public char importado_web { get; set; }
        public char importado_pro { get; set; }
    }
}