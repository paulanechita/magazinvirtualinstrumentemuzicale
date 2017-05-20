using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagazinVirtualInstrMuzicale.Models
{
    public class FinalizareComandaModel
    {
        public IEnumerable<MVIM.DAL.Cos> ListaProduseInCos { get; set; }

        public string Strada { get; set; }

        public int Numar { get; set; }

        public string Oras { get; set; }

        public string Judet { get; set; }

        public string CodPostal { get; set; }

        public string Tara { get; set; }
    }
}