//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientesDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class TipoCliente
    {
        public TipoCliente()
        {
            this.Cliente = new HashSet<Cliente>();
        }
    
        public int idTipoCliente { get; set; }
        public string descripcion { get; set; }
    
        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
