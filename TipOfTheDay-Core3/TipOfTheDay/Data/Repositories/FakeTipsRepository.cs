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

        public bool AddTip(Tip tip)
        {
            bool isSuccess = false;
            if (tip != null)
            {
                tips.Add(tip);
                isSuccess = true;
            }

            return isSuccess;
        }

        public bool DeleteTip(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Tip>> GetAllTipsAsync()
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
