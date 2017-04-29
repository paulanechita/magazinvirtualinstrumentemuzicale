using MVIM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagazinVirtualInstrMuzicale.Models
{
    public class AfisareProduse
    {
        public IEnumerable<Categorie> CategoriiProduse { get; set; }

        public int IdCategorieSelectata { get; set; }

        public List<MVIM.DAL.Produs> ListaProduse { get; set; }
    }
}