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
    public class PracowniciesController : Controller
    {
        private readonly PrzychodniaDBContext _context;

        public PracowniciesController(PrzychodniaDBContext context)
        {
            _context = context;
        }

        // GET: Pracownicy
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pracownicies.ToListAsync());
        }

        // GET: PracownikDetails
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pracownicy = await _context.Pracownicies
                .FirstOrDefaultAsync(m => m.PracownicyID == id);
            if (pracownicy == null)
            {
                return NotFound();
            }

            return View(pracownicy);
        }

        // GET: PracownikCreate
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pracownicies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PracownicyID,Imie,Nazwisko,Pesel,AdresZamieszkania,DataZatrudnienia,KoniecKontraktu")] Pracownicy pracownicy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pracownicy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pracownicy);
        }

        // GET: Pracownicies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pracownicy = await _context.Pracownicies.FindAsync(id);
            if (pracownicy == null)
            {
                return NotFound();
            }
            return View(pracownicy);
        }

        // POST: Pracownicies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PracownicyID,Imie,Nazwisko,Pesel,AdresZamieszkania,DataZatrudnienia,KoniecKontraktu")] Pracownicy pracownicy)
        {
            if (id != pracownicy.PracownicyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pracownicy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PracownicyExists(pracownicy.PracownicyID))
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
            return View(pracownicy);
        }

        // GET: Pracownicies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pracownicy = await _context.Pracownicies
                .FirstOrDefaultAsync(m => m.PracownicyID == id);
            if (pracownicy == null)
            {
                return NotFound();
            }

            return View(pracownicy);
        }

        // POST: Paracownicies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pracownicy = await _context.Pracownicies.FindAsync(id);
            _context.Pracownicies.Remove(pracownicy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public bool PracownicyExists(int id)
        {
            return _context.Pracownicies.Any(e => e.PracownicyID == id);
        }
    }
}