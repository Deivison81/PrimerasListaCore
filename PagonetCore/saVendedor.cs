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
    
    public partial class saVendedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public saVendedor()
        {
            this.saCliente = new HashSet<saCliente>();
            this.saCotizacionCliente = new HashSet<saCotizacionCliente>();
            this.saPedidoVenta = new HashSet<saPedidoVenta>();
            this.saCobro = new HashSet<saCobro>();
        }
    
        public string co_ven { get; set; }
        public string tipo { get; set; }
        public string ven_des { get; set; }
        public Nullable<int> numcom { get; set; }
        public Nullable<System.DateTime> feccom { get; set; }
        public string dis_cen { get; set; }
        public string cedula { get; set; }
        public string direc1 { get; set; }
        public string direc2 { get; set; }
        public string telefonos { get; set; }
        public System.DateTime fecha_reg { get; set; }
        public bool inactivo { get; set; }
        public decimal comision { get; set; }
        public string comentario { get; set; }
        public bool fun_cob { get; set; }
        public bool fun_ven { get; set; }
        public Nullable<decimal> comisionv { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string PSW_M { get; set; }
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
        public string co_zon { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<saCliente> saCliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<saCotizacionCliente> saCotizacionCliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<saPedidoVenta> saPedidoVenta { get; set; }
        public virtual saZona saZona { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<saCobro> saCobro { get; set; }
    }
}
