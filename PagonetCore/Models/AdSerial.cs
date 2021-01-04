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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int reng_num { get; set; }

        [StringLength(30)]
        public string co_art { get; set; }

        [StringLength(6)]
        public string co_alma { get; set; }

        [StringLength(40)]
        public string serial { get; set; }

        [StringLength(40)]
        public string tip_dispositivo { get; set; }

        [StringLength(1)]
        public string importado_web { get; set; }

        [StringLength(1)]
        public string importado_pro { get; set; }

        // Claves For�neas.
        
        public int id_art { get; set; }

        public int cod_almacen { get; set; }

        public virtual AdArticulo Articulo { get; set; }

        public virtual AdAlmacen Almacen { get; set; }
    }
}
