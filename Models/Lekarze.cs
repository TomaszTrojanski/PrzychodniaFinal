using System;
using System.Collections.Generic;

#nullable disable

namespace PrzychodniaFinal.Models
{
    public partial class Lekarze
    {
        public Lekarze()
        {
            Chorobies = new HashSet<Choroby>();
        }

        public int IdPracownika { get; set; }
        public string Specjalizacja { get; set; }
        public int NumerGabinetu { get; set; }

        public virtual Pracownicy IdPracownikaNavigation { get; set; }
        public virtual Gabinet NumerGabinetuNavigation { get; set; }
        public virtual Specjalizacja SpecjalizacjaNavigation { get; set; }
        public virtual ICollection<Choroby> Chorobies { get; set; }
    }
}
