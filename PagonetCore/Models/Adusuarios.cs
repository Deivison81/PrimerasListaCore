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
        [Display(Name = "C�digo Usuario Profit")]
        public string co_user_prof { get; set; }

        [Required]
        [StringLength(6)]
        [Display(Name = "C�digo Usuario")]
        public string cod_user { get; set; }

        [Required]
        [StringLength(60)]
        [Display(Name = "Nombre Usuario")]
        public string nombre_usuarios { get; set; }

        // TODO: Debe almacenarse como hash, no como texto plano.
        [Required]
        [Display(Name = "Contrase�a")]
        public byte[] password { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Display(Name = "Fecha Ingreso")]
        public DateTime fecha_ingreso { get; set; }

        [StringLength(6)]
        [Display(Name = "Validaci�n")]
        public string validacion { get; set; }
    }
}
