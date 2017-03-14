using MVIM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagazinVirtualInstrMuzicale.Models
{
    public class AdaugaProdusModel
    {
        public int IdCategorieProdusSelectata { get; set; }

        public int IdProducatorProdusSelectat { get; set; }

        public List<Categorie> CategoriiProduse { get; set; }

        public List<Producator> ProducatoriProduse { get; set; }
    }
}