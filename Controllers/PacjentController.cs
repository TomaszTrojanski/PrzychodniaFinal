using Microsoft.AspNetCore.Mvc;
using PrzychodniaFinal.Models;
using PrzychodniaFinal.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrzychodniaFinal.Controllers
{
    public class PacjentController : Controller
    {
        private readonly IPacjentRepo _pacjentRepo;
        public PacjentController(IPacjentRepo pacjentRepo)
        {
            _pacjentRepo = pacjentRepo;
        }

        [HttpPost]

        public async Task<IActionResult> Create(Pacjenci pacjenci)
        {
            if (ModelState.IsValid)
            {
                await _pacjentRepo.AddNewPatient(pacjenci);
                return RedirectToAction("Index");
            }
            return View(pacjenci);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
