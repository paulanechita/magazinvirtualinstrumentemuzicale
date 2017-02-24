using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MagazinVirtualInstrMuzicale.Models
{
    public class ContNouModel
    {
        [Display(Name = "Nume: ")]
        public string Nume { get; set; }

        [Display(Name = "Prenume: ")]
        public string Prenume { get; set; }

        [Display(Name = "Data nasterii: ")]
        public DateTime DataNasterii { get; set; }

        [Display(Name = "Email: ")]
        public string Email { get; set; }

        [Display(Name = "Telefon: ")]
        public string NumarTelefon { get; set; }

        [Display(Name = "Username: ")]
        public string Username { get; set; }

        [Display(Name = "Parola: ")]
        public string Parola { get; set; }

        [Display(Name = "Confima parola: ")]
        public string ConfirmaParola { get; set; }
    }
}