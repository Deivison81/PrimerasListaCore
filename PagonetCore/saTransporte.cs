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
    
    public partial class saTransporte
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public saTransporte()
        {
            this.saCotizacionCliente = new HashSet<saCotizacionCliente>();
            this.saPedidoVenta = new HashSet<saPedidoVenta>();
        }
    
        public string co_tran { get; set; }
        public string des_tran { get; set; }
        public string resp_tra { get; set; }
        public Nullable<int> numcom { get; set; }
        public Nullable<System.DateTime> feccom { get; set; }
        public string dis_cen { get; set; }
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
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<saCotizacionCliente> saCotizacionCliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<saPedidoVenta> saPedidoVenta { get; set; }
    }
}
