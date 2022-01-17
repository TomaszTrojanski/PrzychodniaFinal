using System;
using System.Collections.Generic;

#nullable disable

namespace PrzychodniaFinal.Models
{
    public partial class Pacjenci
    {
        public Pacjenci()
        {
            Chorobies = new HashSet<Choroby>();
        }

        public int IdPacjenta { get; set; }
        public string Pesel { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string AdresZamieszkania { get; set; }

        public virtual ICollection<Choroby> Chorobies { get; set; }
    }
}
