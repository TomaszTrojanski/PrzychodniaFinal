using System;
using System.Collections.Generic;

#nullable disable

namespace PrzychodniaFinal.Models
{
    public partial class Choroby
    {
        public int IdChoroby { get; set; }
        public int IdRecepty { get; set; }
        public int IdPracownika { get; set; }
        public int IdPacjenta { get; set; }
        public string PrzebiegChoroby { get; set; }

        public virtual Recepty Id { get; set; }
        public virtual Pacjenci IdPacjentaNavigation { get; set; }
        public virtual Lekarze IdPracownikaNavigation { get; set; }
    }
}
