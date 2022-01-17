﻿using System;
using System.Collections.Generic;

#nullable disable

namespace PrzychodniaFinal.Models
{
    public partial class Recepty
    {
        [Key]

        public int IdPracownika { get; set; }

        [Required(ErrorMessage = "Wprowadź Id Pracownika")]
        [Display(Name = "Id")]
        public string Imie { get; set; }

        [Required(ErrorMessage = "Wprowadź Numer Pesel Pracownika")]
        [Display(Name = "Pesel")]
        [StringLength(11)]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Wprowadź cyfry")]
        public string Pesel { get; set; }

        [Required(ErrorMessage = "Wprowadź Imię Pracownika")]
        [Display(Name = "Imię")]
        public string Imie { get; set; }

        [Required(ErrorMessage = "Wprowadź Nazwisko Pracownika")]
        [Display(Name = "Nazwisko")]
        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "Wprowadź Adres Pracownika")]
        [Display(Name = "AdresZamieszkania")]
        public string AdresZamieszkania { get; set; }

        [Required(ErrorMessage = "Wprowadź Datę Zatrudnienia Pracownika")]
        [Display(Name = "DataZatrudnienia")]
        [RegularExpression("d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MM/yyyy"), ErrorMessage = "Wprowadź datę")]
        public string DataZatrudnienia { get; set; }

        [Required(ErrorMessage = "Wprowadź Koniec Kontraktu Pracownika")]
        [Display(Name = "KoniecKontraktu")]
        [RegularExpression("d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MM/yyyy", ErrorMessage = "Wprowadź datę")]
        public string KoniecKontraktu { get; set; }

        public virtual Lekarze Lekarze { get; set; }





        public Recepty()
        {
            Chorobies = new HashSet<Choroby>();
        }

        public int IdChoroby { get; set; }
        public int IdRecepty { get; set; }
        public string Lek { get; set; }
        public DateTime DataWystawienia { get; set; }

        public virtual ICollection<Choroby> Chorobies { get; set; }
    }
}
