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
    
    public partial class ComandaProdus
    {
        public int IdComandaProdus { get; set; }
        public int IdComanda { get; set; }
        public int IdProdus { get; set; }
        public string NumeProdus { get; set; }
        public decimal PretProdus { get; set; }
        public string DescriereProdus { get; set; }
        public int Cantitate { get; set; }
    
        public virtual Comanda Comanda { get; set; }
        public virtual Produs Produs { get; set; }
    }
}
