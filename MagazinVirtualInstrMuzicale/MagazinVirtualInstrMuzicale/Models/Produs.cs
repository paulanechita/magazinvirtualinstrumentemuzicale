using MVIM.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MagazinVirtualInstrMuzicale.Models
{
    public class Produs
    {
        [Required]
        public string Nume { get; set; }

        [Required]
        public double Pret { get; set; }

        [Required]
        public string Descriere { get; set; }

        [Required]
        public PozaProdus PozaProdus { get; set; }

        //[Required]
        //public Categorie CategorieProdus { get; set; }

        [Required]
        public Producator ProducatorProdus { get; set; }

        [Required]
        public HttpPostedFileBase Upload { get; set; }
    }
}