using PrzychodniaFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrzychodniaFinal.Repos
{
    public interface IPacjentRepo
    {
        Task<Pacjenci> GetPatientById(int id);
        Task<List<Pacjenci>> GetAllPatients();
        Task AddNewPatient(Pacjenci pacjent);
        Task UpdatePatientDetails(Pacjenci pacjent);
        Task DeletePatient(Pacjenci pacjent);
    }
}
