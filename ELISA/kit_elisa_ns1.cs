//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ELISA
{
    using System;
    using System.Collections.Generic;
    
    public partial class kit_elisa_ns1
    {
        public kit_elisa_ns1()
        {
            this.ns1 = new HashSet<ns1>();
            this.reactivos_ns1 = new HashSet<reactivos_ns1>();
        }
    
        public string Codigo { get; set; }
        public string Lote { get; set; }
        public string CasaComercial { get; set; }
        public string Metodo { get; set; }
    
        public virtual ICollection<ns1> ns1 { get; set; }
        public virtual ICollection<reactivos_ns1> reactivos_ns1 { get; set; }
    }
}
