namespace PagonetCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Adusuarios
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(6)]
        public string co_user_prof { get; set; }

        [Required]
        [StringLength(6)]
        public string cod_user { get; set; }

        [Required]
        [StringLength(60)]
        public string nombre_usuarios { get; set; }

        // TODO: Debe almacenarse como hash, no como texto plano.
        [Required]
        public byte[] password { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }

        public DateTime fecha_ingreso { get; set; }

        [StringLength(6)]
        public string validacion { get; set; }
    }
}
