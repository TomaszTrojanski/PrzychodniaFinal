using System;
using System.Collections.Generic;

#nullable disable

namespace PrzychodniaFinal.Models
{
    public partial class Recepty
    {
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
