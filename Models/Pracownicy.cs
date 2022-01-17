using System;
using System.Collections.Generic;

#nullable disable

namespace PrzychodniaFinal.Models
{
    public partial class Pracownicy
    {
        public int IdPracownika { get; set; }
        public string Pesel { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string AdresZamieszkania { get; set; }
        public DateTime DataZatrudnienia { get; set; }
        public DateTime KoniecKontraktu { get; set; }

        public virtual Lekarze Lekarze { get; set; }
    }
}
