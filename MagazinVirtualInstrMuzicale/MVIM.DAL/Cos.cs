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
    
    public partial class Cos
    {
        public int IdCos { get; set; }
        public int IdClient { get; set; }
        public System.DateTime Data { get; set; }
        public int Cantitate { get; set; }
        public int IdProdus { get; set; }
        public string Status { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Produs Produs { get; set; }
    }
}
