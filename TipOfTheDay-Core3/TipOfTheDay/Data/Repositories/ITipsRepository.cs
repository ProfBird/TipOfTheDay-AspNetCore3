using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TipOfTheDay.Models;

namespace TipOfTheDay.Data
{
    public interface ITipsRepository
    {
        // Tip methods
        public Task<int> AddTipAsync(Tip tip);
        public Task<Tip> GetTipAsync(int? id);
        public Task<IQueryable<Tip>>GetAllTipsAsync();
        public Task<int> UpdateTipAsync(Tip tip);
        public Task<int> DeleteTipAsync(int? id);
        public bool TipExists(int id);

        // Comment methods
        public Task<int> AddCommentAsync(Comment comment, int TipId);
    }
}

// The int returned by AddTip, UpdateTip, and DeleteTip, will be 0 if
// nothing is done, otherwise a posivive number.