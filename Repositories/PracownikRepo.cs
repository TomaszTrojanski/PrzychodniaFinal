using Microsoft.EntityFrameworkCore;
using PrzychodniaFinal.DataAccess;
using PrzychodniaFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrzychodniaFinal.Repos
{
    public class PracownikRepo : IPracownikRepo
    {
        private readonly PrzychodniaDBContext _dbContext;
        public PracownikRepo(PrzychodniaDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddNewEmployee(Pracownicy pracownicy)
        {
            _dbContext.Add(pracownicy);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployee(Pracownicy pracownicy)
        {
            _dbContext.Remove(pracownicy);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Pracownicy>> GetAllEmployees()
        {
            return await _dbContext.Pracownicies.ToListAsync();
        }

        public async Task<Pracownicy> GetEmployeeById(int id)
        {
            return await _dbContext.Pracownicies.FindAsync(id);
        }

        public async Task UpdateEmployeeDetails(Pracownicy pracownicy)
        {
            _dbContext.Entry(pracownicy).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
