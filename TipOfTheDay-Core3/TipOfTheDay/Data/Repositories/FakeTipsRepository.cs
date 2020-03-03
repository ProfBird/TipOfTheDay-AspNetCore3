using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TipOfTheDay.Models;

namespace TipOfTheDay.Data.Repositories
{
    public class FakeTipsRepository : ITipsRepository
    {
        public FakeTipsRepository()
        {
        }

        private List<Tip> tips = new List<Tip>();
        public List<Tip> Tips { get { return tips; } }

        public Task<int> AddTipAsync(Tip tip)
        {
            int success = 0;
            if (tip != null)
            {
                tips.Add(tip);
                success = 1;
            }

            return Task.FromResult<int>(success);
        }

        public Task<int> DeleteTipAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Tip>> GetAllTipsAsync()
        {
            return Task.FromResult<IQueryable< Tip>>(tips.AsQueryable<Tip>());
        }

        public Task<Tip> GetTipAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateTipAsync(Tip tip)
        {
            throw new NotImplementedException();
        }

        public bool TipExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
