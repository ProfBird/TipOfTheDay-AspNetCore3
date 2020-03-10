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
        public Task<IQueryable<Tip>> GetAllTipsAsync();
        public Task<int> UpdateTipAsync(Tip tip);
        public Task<int> DeleteTipAsync(int? id);
        public bool TipExists(int id);

        // Comment methods
        public Task<int> AddCommentAsync(Comment comment, int TipId);
    }
}

// GetAllTips doesn't actually return data, that will happen when
// the controller completes the query.
// See https://stackoverflow.com/questions/26676563/entity-framework-queryable-async


// The int returned by AddTip, UpdateTip, and DeleteTip, will be 0 if
// nothing is done, otherwise a posivive number.