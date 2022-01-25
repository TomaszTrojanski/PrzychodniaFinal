using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrzychodniaFinal.DataAccess;

namespace PrzychodniaFinal.services
{
    public class PacjenciService
    {
        private readonly PrzychodniaDBContext _context;
        public PacjenciService(PrzychodniaDBContext context)
        {
            _context = context;
        }
        public void Edit()
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
    }
}
