using Microsoft.EntityFrameworkCore;
using PrzychodniaFinal.DataAccess;
using PrzychodniaFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrzychodniaFinal.Repos
{
    public class PacjentRepo : IPacjentRepo
    {
        private readonly PrzychodniaDBContext _dbContext;
        public PacjentRepo(PrzychodniaDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddNewPatient(Pacjenci pacjent)
        {
            _dbContext.Add(pacjent);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePatient(Pacjenci pacjent)
        {
            _dbContext.Remove(pacjent);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Pacjenci>> GetAllPatients()
        {
            return await _dbContext.Pacjencis.ToListAsync();
        }

        public async Task<Pacjenci> GetPatientById(int id)
        {
            return await _dbContext.Pacjencis.FindAsync(id);
        }

        public async Task UpdatePatientDetails(Pacjenci pacjent)
        {
            _dbContext.Entry(pacjent).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
