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

        public Task<int> AddTip(Tip tip)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteTip(int? id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Tip> GetAllTips()
        {
            throw new NotImplementedException();
        }

        public Task<Tip> GetTipAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateTip(Tip tip)
        {
            throw new NotImplementedException();
        }

        public bool TipExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
