using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TipOfTheDay.Data;
using TipOfTheDay.Models;

namespace TipOfTheDay.Controllers
{
    public class TipController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tip
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tip.ToListAsync());
        }

        // GET: Tip/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tip = await _context.Tip
                .FirstOrDefaultAsync(m => m.TipID == id);
            if (tip == null)
            {
                return NotFound();
            }

            return View(tip);
        }

        // GET: Tip/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tip/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipID,TipText")] Tip tip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tip);
        }

        // GET: Tip/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tip = await _context.Tip.Include(t => t.Tags)
                .Where(t => t.TipID == id).FirstOrDefaultAsync<Tip>();
            if (tip == null)
            {
                return NotFound();
            }

            // Put all the tags in a list that the user can select from
             var tags = await _context.Tag.ToListAsync();
            var tagChoices = new List<TagChoice>();
            foreach (var tag in tags)
            {
                tagChoices.Add(new TagChoice { Tag = tag });
            }

            var vm = new TipTagVM { TagSelections = tagChoices, Tip = tip };

            return View(vm);
        }

        // POST: Tips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("TipID,TipText")] Tip tip)
        {
            if (ModelState.IsValid)
            {
                try
                {
                     _context.Update(tip);
                    await _context.SaveChangesAsync();
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


        // POST: Tip/Edit/5
        [HttpPost]
        public async Task<IActionResult> EditTags(TipTagVM vm)
        {
            // Get the tip object with the ID in the VM from the database.
            // We need to do our add/remove tag operations on the object from the DB
            var tip = await _context.Tip.Include(t => t.Tags)
                .Where(t => t.TipID == vm.Tip.TipID)
                .FirstOrDefaultAsync();

            if (tip == null)
            {
                return NotFound();
            }

            // Note: vm.TagSelections has all the tags from the Tags table of the DB with some possibly selected

            // Remove unselected tags from the tip, add selected ones
            foreach (var selection in vm.TagSelections)
            {
                // Check the selection tag to see if it's already on the tip's list of tags
                if (tip.Tags
                    .Where(t => t.TagID == selection.Tag.TagID)
                    .Any() )
                {
                    // If the selection tag IS on the tip's list and is NOT selected remove it
                    if (!selection.Selected)
                    {
                        // In order to romove the tag, we need to get the actual tag object from the tip
                        Tag tagToRemove = null;
                        foreach (Tag tag in tip.Tags)
                        {
                            if (selection.Tag.TagID == tag.TagID)
                            {
                                tagToRemove = tag;
                            }
                        }
                        tip.Tags.Remove(tagToRemove);
                    }
                }
                // If the selection tag is NOT on the tip's list and IS selected add it
                else if (selection.Selected)
                {
                    tip.Tags.Add(selection.Tag);
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.SaveChangesAsync();
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
            return View("Edit", tip); // if ModelState not valid
        }

        // GET: Tip/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tip = await _context.Tip
                .FirstOrDefaultAsync(m => m.TipID == id);
            if (tip == null)
            {
                return NotFound();
            }

            return View(tip);
        }

        // POST: Tip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tip = await _context.Tip.FindAsync(id);
            _context.Tip.Remove(tip);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipExists(int id)
        {
            return _context.Tip.Any(e => e.TipID == id);
        }
    }
}
