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
    //[Authorize]
    
    public class Condominios1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Condominios1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Condominios1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Condominio.ToListAsync());
        }

        // GET: Condominios1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var condominio = await _context.Condominio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (condominio == null)
            {
                return NotFound();
            }

            return View(condominio);
        }

        // GET: Condominios1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Condominios1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Bairro,Cidade")] Condominio condominio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(condominio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(condominio);
        }

        // GET: Condominios1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var condominio = await _context.Condominio.FindAsync(id);
            if (condominio == null)
            {
                return NotFound();
            }
            return View(condominio);
        }

        // POST: Condominios1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Bairro,Cidade")] Condominio condominio)
        {
            if (id != condominio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(condominio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CondominioExists(condominio.Id))
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
            return View(condominio);
        }

        // GET: Condominios1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var condominio = await _context.Condominio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (condominio == null)
            {
                return NotFound();
            }

            return View(condominio);
        }

        // POST: Condominios1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var condominio = await _context.Condominio.FindAsync(id);
            _context.Condominio.Remove(condominio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CondominioExists(int id)
        {
            return _context.Condominio.Any(e => e.Id == id);
        }
    }
}
