﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using PrzychodniaFinal.Models;
using PrzychodniaFinal.Repos;

namespace PrzychodniaFinal.Controllers
{
    public class PracownikController:Controller
    {
        private readonly IPracownikRepo _pracownikRepo;
        public PracownikController(IPracownikRepo pracownikRepo)
        {
            _pracownikRepo = pracownikRepo;
        }

        [HttpPost]

        public async Task<IActionResult> Utwórz_pracownika(Pracownicy pracownicy)
        {
            if (ModelState.IsValid)
            {
                await _pracownikRepo.AddNewEmployee(pracownicy);
                return RedirectToAction("Index");
            }
            return View(pracownicy);
        }
        public IActionResult Utwórz_pracownika()
        {
            return View();
        }

        public IActionResult Utworz_pracownika()
        {
            throw new NotImplementedException();
        }
    }
}
