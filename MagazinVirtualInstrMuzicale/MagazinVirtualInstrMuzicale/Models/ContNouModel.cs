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
        [Required]
        public string Nume { get; set; }
        
        [Display(Name = "Prenume: ")]
        [Required]
        public string Prenume { get; set; }

        [Display(Name = "Data nasterii: ")]
        [Required]
        public DateTime DataNasterii { get; set; }

        [Display(Name = "Email: ")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Telefon: ")]
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number must be a number.")]
        public string NumarTelefon { get; set; }

        [Display(Name = "Username: ")]
        [Required]
        public string Username { get; set; }

        [Display(Name = "Parola: ")]
        [Required]
        [DataType(DataType.Password)]
        public string Parola { get; set; }

        [Display(Name = "Confima parola: ")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Parola")]
        public string ConfirmaParola { get; set; }
    }
}