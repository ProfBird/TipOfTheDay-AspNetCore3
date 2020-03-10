using System;
using System.Linq;
using System.Threading.Tasks;
using TipOfTheDay.Models;

namespace TipOfTheDay.Data.Repositories
{
    public class TipsRepository : ITipsRepository
    {
        ApplicationDbContext _context;

        public TipsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddTipAsync(Tip tip)
        {
            _context.Tip.Add(tip);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteTipAsync(int? id)
        {
            var tip = _context.Tip.Find(id);
            _context.Tip.Remove(tip);
            return await _context.SaveChangesAsync();
        }

        public async Task<IQueryable<Tip>> GetAllTipsAsync()
        {
            return await Task.FromResult<IQueryable<Tip>>(_context.Tip);
        }

        public async Task<Tip> GetTipAsync(int? id)
        {
            return await Task.FromResult<Tip>(_context.Tip.Find(id));
        }

        public async Task<int> UpdateTipAsync(Tip tip)
        {
            _context.Tip.Update(tip);
            return await _context.SaveChangesAsync();
        }

        public bool TipExists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddCommentAsync(Comment comment, int TipId)
        {
            throw new NotImplementedException();
        }
    }
}