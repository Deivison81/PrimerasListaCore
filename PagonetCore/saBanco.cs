//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PagonetCore
{
    using System;
    using System.Collections.Generic;
    
    public partial class saBanco
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public saBanco()
        {
            this.saCobroTPReng = new HashSet<saCobroTPReng>();
            this.saCuentaBancaria = new HashSet<saCuentaBancaria>();
            this.saMovimientoCaja = new HashSet<saMovimientoCaja>();
        }
    
        public string co_ban { get; set; }
        public string des_ban { get; set; }
        public string telefonos { get; set; }
        public int plazo1 { get; set; }
        public int plazo2 { get; set; }
        public int plazo3 { get; set; }
        public int plazo4 { get; set; }
        public string campo1 { get; set; }
        public string campo2 { get; set; }
        public string campo3 { get; set; }
        public string campo4 { get; set; }
        public string campo5 { get; set; }
        public string campo6 { get; set; }
        public string campo7 { get; set; }
        public string campo8 { get; set; }
        public string co_us_in { get; set; }
        public string co_sucu_in { get; set; }
        public System.DateTime fe_us_in { get; set; }
        public string co_us_mo { get; set; }
        public string co_sucu_mo { get; set; }
        public System.DateTime fe_us_mo { get; set; }
        public string revisado { get; set; }
        public string trasnfe { get; set; }
        public byte[] validador { get; set; }
        public System.Guid rowguid { get; set; }
        public Nullable<decimal> comisMismoBanco { get; set; }
        public Nullable<decimal> comisOtrosBancos { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<saCobroTPReng> saCobroTPReng { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<saCuentaBancaria> saCuentaBancaria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<saMovimientoCaja> saMovimientoCaja { get; set; }
    }
}
