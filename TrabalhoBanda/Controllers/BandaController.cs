using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoBanda.Data;
using TrabalhoBanda.Models;

namespace TrabalhoBanda.Controllers
{
    public class BandaController : Controller
    {
        private readonly IESContext _context;

        public BandaController(IESContext context)
        {
            _context = context;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bandas.OrderBy(b => b.Nome).ToListAsync()); ;
        }
        #endregion

        #region Create - GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        #endregion

        #region Create - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome, numIntegrantes, Email, CatMusical, numAlbuns")] Banda banda)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(banda);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError(ex.Message, "Falha ao inserir");
            }
            return View(banda);
        }
        #endregion

        #region Edit - GET
        [HttpGet]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var banda = await _context.Bandas.SingleOrDefaultAsync(b => b.BandaID == id);
            if (banda == null)
            {
                return NotFound();
            }
            return View(banda);
        }
        #endregion

        #region Edit - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("BandaID, Nome, numIntegrantes, Email, CatMusical, numAlbuns")]
        Banda banda)
        {
            if (id != banda.BandaID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(banda);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError(ex.Message, "Falha ao atualizar");
                }
            }
            return View(banda);
        }
        #endregion

        #region Details - GET
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var banda = await _context.Bandas.SingleOrDefaultAsync(b => b.BandaID == id);
            if (banda == null)
            {
                return NotFound();
            }
            return View(banda);
        }
        #endregion

        #region Delete - GET
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var banda = await _context.Bandas.SingleOrDefaultAsync(b => b.BandaID == id);
            if (banda == null)
            {
                return NotFound();
            }
            return View(banda);
        }
        #endregion

        #region Delete - POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var banda = await _context.Bandas.SingleOrDefaultAsync(b => b.BandaID == id);
            if (banda == null)
            {
                return NotFound();
            }


            _context.Bandas.Remove(banda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
