
using System.ComponentModel.DataAnnotations;

namespace MagazinVirtualInstrMuzicale.Models
{
    public class ContulMeuModel
    {
        public MVIM.DAL.Client Client { get; set; }

        public MVIM.DAL.User User { get; set; }

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