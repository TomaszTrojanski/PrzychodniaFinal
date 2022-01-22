using System;
using PrzychodniaFinal.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrzychodniaFinal.Repos
{
    public interface IPracownikRepo
    {
        Task<Pracownicy> GetEmployeeById(int id);
        Task<List<Pracownicy>> GetAllEmployees();
        Task AddNewEmployee(Pracownicy pracownicy);
        Task UpdateEmployeeDetails(Pracownicy pracownicy);
        Task DeleteEmployee(Pracownicy pracownicy);
    }
}
