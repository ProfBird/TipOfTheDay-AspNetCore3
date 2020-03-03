using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TipOfTheDay.Data;
using TipOfTheDay.Models;

namespace TipOfTheDay.Controllers
{
    public class TipsController : Controller
    {
        private readonly ITipsRepository _repo;

        public TipsController(ITipsRepository repo)
        {
            _repo = repo;
        }

        // GET: Tips
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAllTips().ToListAsync());
        }

        // GET: Tips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tip = await _repo.GetTipAsync(id);
                
            if (tip == null)
            {
                return NotFound();
            }

            return View(tip);
        }

        // GET: Tips/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipID,TipText")] Tip tip)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTip(tip);
                return RedirectToAction(nameof(Index));
            }
            return View(tip);
        }

        // GET: Tips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tip = await _repo.GetTipAsync(id);
            if (tip == null)
            {
                return NotFound();
            }
            return View(tip);
        }

        // POST: Tips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipID,TipText")] Tip tip)
        {
            if (id != tip.TipID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.UpdateTip(tip);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipExists(tip.TipID))
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
            return View(tip);
        }

        // GET: Tips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tip = await _repo.GetTipAsync(id);
            if (tip == null)
            {
                return NotFound();
            }

            return View(tip);
        }

        // POST: Tips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           await _repo.DeleteTip(id);

            return RedirectToAction(nameof(Index));
        }
        
        private bool TipExists(int id)
        {
            return _repo.TipExists(id);
        }
        
    }
}
