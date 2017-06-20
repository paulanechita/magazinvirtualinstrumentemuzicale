using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagazinVirtualInstrMuzicale.Models
{
    public class DetaliiModel
    {
        public int IdProdus { get; set; }

        public string NumeProdus { get; set; }

        public int IdPozaProdus { get; set; }

        public decimal PretProdus { get; set; }
         
        public string DescriereProdus { get; set; }

        public string Producator { get; set; }
    }
}