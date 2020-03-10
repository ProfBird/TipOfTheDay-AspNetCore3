using System;
using System.Collections.Generic;
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

        public Task<int> AddTipAsync(Tip tip)
        {
            _context.Tip.Add(tip);
            return _context.SaveChangesAsync();
        }

        public Task<int> DeleteTipAsync(int? id)
        {
            var tip = _context.Tip.Find(id);
            _context.Tip.Remove(tip);
            return _context.SaveChangesAsync();
        }

        public Task<IQueryable<Tip>> GetAllTipsAsync()
        {
            return Task.FromResult<IQueryable<Tip>>(_context.Tip);
        }

        public Task<Tip> GetTipAsync(int? id)
        {
            return Task.FromResult<Tip>(_context.Tip.Find(id));
        }

        public Task<int> UpdateTipAsync(Tip tip)
        {
            _context.Tip.Update(tip);
            return _context.SaveChangesAsync();
        }

        public bool TipExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddCommentAsync(Comment comment, int TipId)
        {
            throw new NotImplementedException();
        }
    }
}
