using System;
using System.Collections.Generic;
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
        public List<Tip> Tips { get; }

        public bool AddTip(Tip tip)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTip(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tip>> GetAllTipsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Tip> GetTipAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTip(Tip tip)
        {
            throw new NotImplementedException();
        }

        public bool TipExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
