using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PrzychodniaFinal.Models
{
    public partial class Pracownicy
    {
        public int PracownicyID { get; set; }

        [Required(ErrorMessage = "Wprowadź Numer Pesel Pracownika")]
        [Display(Name = "Pesel")]
        [MaxLength(11)]
        [Column(TypeName = "varchar(11)")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Wprowadź cyfry")]
        public string Pesel { get; set; }

        [Required(ErrorMessage = "Wprowadź Imię Pracownika")]
        [MaxLength(50)]
        [Display(Name = "Imię")]
        public string Imie { get; set; }

        [Required(ErrorMessage = "Wprowadź Nazwisko Pracownika")]
        [MaxLength(50)]
        [Display(Name = "Nazwisko")]
        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "Wprowadź Adres Pracownika")]
        [MaxLength(100)]
        [Display(Name = "AdresZamieszkania")]
        public string AdresZamieszkania { get; set; }

        [Required(ErrorMessage = "Wprowadź Datę Zatrudnienia Pracownika")]
        [Display(Name = "DataZatrudnienia")]
        [RegularExpression("d/M/yyyy || dd/M/yyyy || d/MM/yyyy || dd/MM/yyyy")]
        public string DataZatrudnienia { get; set; }

        [Required(ErrorMessage = "Wprowadź Koniec Kontraktu Pracownika")]
        [Display(Name = "KoniecKontraktu")]
        [RegularExpression("d/M/yyyy || dd/M/yyyy || d/MM/yyyy || dd/MM/yyyy")]
        public string KoniecKontraktu { get; set; }

        public virtual Lekarze Lekarze { get; set; }
    }
}
