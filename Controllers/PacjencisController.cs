using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrzychodniaFinal.DataAccess;
using PrzychodniaFinal.Models;

namespace PrzychodniaFinal.Controllers
{
    public class PacjencisController : Controller
    {
        private readonly PrzychodniaDBContext _context;

        public PacjencisController(PrzychodniaDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pacjencis.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacjenci = await _context.Pacjencis
                .FirstOrDefaultAsync(m => m.PacjenciID == id);
            if (pacjenci == null)
            {
                return NotFound();
            }

            return View(pacjenci);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PacjenciID,Imie,Nazwisko,Pesel,AdresZamieszkania")] Pacjenci pacjenci)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pacjenci);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pacjenci);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacjenci = await _context.Pacjencis.FindAsync(id);
            if (pacjenci == null)
            {
                return NotFound();
            }
            return View(pacjenci);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PacjenciID,Imie,Nazwisko,Pesel,AdresZamieszkania")] Pacjenci pacjenci)
        {
            if (id != pacjenci.PacjenciID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacjenci);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacjenciExists(pacjenci.PacjenciID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pacjenci);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacjenci = await _context.Pacjencis
                .FirstOrDefaultAsync(m => m.PacjenciID == id);
            if (pacjenci == null)
            {
                return NotFound();
            }

            return View(pacjenci);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pacjenci = await _context.Pacjencis.FindAsync(id);
            _context.Pacjencis.Remove(pacjenci);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacjenciExists(int id)
        {
            return _context.Pacjencis.Any(e => e.PacjenciID == id);
        }
    }
}
