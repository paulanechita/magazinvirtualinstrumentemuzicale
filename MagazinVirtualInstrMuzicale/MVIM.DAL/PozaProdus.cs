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
    
    public partial class PozaProdus
    {
        public int IdPozaProdus { get; set; }
        public int IdProdus { get; set; }
        public byte[] Poza { get; set; }
    
        public virtual Produs Produs { get; set; }
    }
}
