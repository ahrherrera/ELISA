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
    
    public partial class usuario
    {
        public usuario()
        {
            this.elisaiggrepeticiones = new HashSet<elisaiggrepeticione>();
        }
    
        public int idUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public byte[] pass { get; set; }
        public string rol { get; set; }
        public bool Estado { get; set; }
    
        public virtual ICollection<elisaiggrepeticione> elisaiggrepeticiones { get; set; }
    }
}
