using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MagazinVirtualInstrMuzicale.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Username: ")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Parola: ")]
        public string Parola { get; set; }
    }
}