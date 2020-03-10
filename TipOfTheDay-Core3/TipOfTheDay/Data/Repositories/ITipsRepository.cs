using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TipOfTheDay.Models;

namespace TipOfTheDay.Data
{
    public interface ITipsRepository
    {
        public Task<int> AddTipAsync(Tip tip);
        public Task<Tip> GetTipAsync(int? id);
        public Task<IQueryable<Tip>>GetAllTipsAsync();
        public Task<int> UpdateTipAsync(Tip tip);
        public Task<int> DeleteTipAsync(int? id);
        public bool TipExists(int id);
    }
}

// GetAllTips isn't an async method because it returns an IQueryable object.
// There is no data actually being returned, that will happen when
// the controller completes the query, so the correspondingcontroller
// method should be async.
// See https://stackoverflow.com/questions/26676563/entity-framework-queryable-async


// The int returned by AddTip, UpdateTip, and DeleteTip, will be 0 if
// nothing is done, otherwise a posivive number.