using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using Microsoft.EntityFrameworkCore;
using PrzychodniaFinal.DataAccess;
using PrzychodniaFinal.Models;

namespace PrzychodniaFinal.services
{
    public interface IPacjenciServices
    {
        public Task<List<Pacjenci>> GetPacjenci(string sortOrder, string searchString);



    }
    public class PacjenciService:IPacjenciServices
    {
        private readonly PrzychodniaDBContext context;

        public PacjenciService(PrzychodniaDBContext context)
        {
            this.context = context;
        }

        public async Task<List<Pacjenci>> GetPacjenci(string sortOrder, string searchString)
        {
            var pacjenci = await context.Pacjencis.ToListAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
                pacjenci = (List<Pacjenci>)pacjenci.Where(s => s.Imie.Contains(searchString)
                                                               || s.Nazwisko.Contains(searchString)
                                                               || s.Pesel.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    pacjenci = pacjenci.OrderByDescending(s => s.Nazwisko).ToList();
                    break;
                case "Date":
                    pacjenci = pacjenci.OrderBy(s => s.DataUrodzenia).ToList();
                    break;
                case "date_desc":
                    pacjenci = pacjenci.OrderByDescending(s => s.DataUrodzenia).ToList();
                    break;
                default:
                    pacjenci = pacjenci.OrderBy(s => s.Nazwisko).ToList();
                    break;
            }

            return pacjenci.ToList();
        }
    }
}
