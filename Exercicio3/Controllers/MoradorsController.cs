using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Exercicio3.Data;
using Exercicio3.Models;
using Microsoft.AspNetCore.Authorization;

namespace Exercicio3.Controllers
{
    [Authorize] //Atributo para autenticação de autorização da classe ou de alguma função especica como por exemplo permisao só para visualização de condominios.
    public class MoradorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoradorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Moradors
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Morador.Include(m => m.familia);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Moradors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var morador = await _context.Morador
                .Include(m => m.familia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (morador == null)
            {
                return NotFound();
            }

            return View(morador);
        }

        // GET: Moradors/Create
        public IActionResult Create()
        {
            ViewData["Id_Familia"] = new SelectList(_context.Familia, "Id", "Nome");
            return View();
        }

        // POST: Moradors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Id_Familia,Nome,QuantidadeBichosEstimacao")] Morador morador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(morador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_Familia"] = new SelectList(_context.Familia, "Id", "Nome", morador.Id_Familia);
            return View(morador);
        }

        // GET: Moradors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var morador = await _context.Morador.FindAsync(id);
            if (morador == null)
            {
                return NotFound();
            }
            ViewData["Id_Familia"] = new SelectList(_context.Familia, "Id", "Nome", morador.Id_Familia);
            return View(morador);
        }

        // POST: Moradors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_Familia,Nome,QuantidadeBichosEstimacao")] Morador morador)
        {
            if (id != morador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(morador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoradorExists(morador.Id))
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
            ViewData["Id_Familia"] = new SelectList(_context.Familia, "Id", "Nome", morador.Id_Familia);
            return View(morador);
        }

        // GET: Moradors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var morador = await _context.Morador
                .Include(m => m.familia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (morador == null)
            {
                return NotFound();
            }

            return View(morador);
        }

        // POST: Moradors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var morador = await _context.Morador.FindAsync(id);
            _context.Morador.Remove(morador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoradorExists(int id)
        {
            return _context.Morador.Any(e => e.Id == id);
        }
    }
}
