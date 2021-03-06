//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVIM.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comanda
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comanda()
        {
            this.ComandaProdus = new HashSet<ComandaProdus>();
        }
    
        public int IdComanda { get; set; }
        public int IdClient { get; set; }
        public int IdAdresa { get; set; }
        public string Email { get; set; }
        public System.DateTime Data { get; set; }
        public int IdCodStatusComanda { get; set; }
    
        public virtual Adresa Adresa { get; set; }
        public virtual Client Client { get; set; }
        public virtual StatusComanda StatusComanda { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComandaProdus> ComandaProdus { get; set; }
    }
}
