using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TipOfTheDay.Models;

namespace TipOfTheDay.Data
{
    public interface ITipsRepository
    {
        public bool AddTip(Tip tip);
        public Task<Tip> GetTipAsync(int? id);
        public Task<List<Tip>> GetAllTipsAsync();
        public bool UpdateTip(Tip tip);
        public bool DeleteTip(int? id);
        public bool TipExists(int id);
    }
}
