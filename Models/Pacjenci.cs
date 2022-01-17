using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PrzychodniaFinal.Models
{
    public partial class Pacjenci
    {
        [Key]

        public int IdPacjenta { get; set; }

        [Required(ErrorMessage = "Wprowadź Imię Pacjenta")]
        [Display(Name = "Imię")]
        public string Imie { get; set; }

        [Required(ErrorMessage = "Wprowadź Nazwisko Pacjenta")]
        [Display(Name = "Nazwisko")]
        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "Wprowadź Numer Pesel Pacjenta")]
        [Display(Name = "Pesel")]
        [StringLength(11)]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Wprowadź cyfry")]
        public string Pesel { get; set; }

        [Required(ErrorMessage = "Wprowadź Adres Pacjenta")]
        [Display(Name = "Adres")]
        public string AdresZamieszkania { get; set; }

        public virtual ICollection<Choroby> Chorobies { get; set; }
        public Pacjenci()
        {
            Chorobies = new HashSet<Choroby>();
        }
    }
}
