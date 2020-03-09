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
        private List<Comment> comments = new List<Comment>();

        public List<Tip> Tips { get { return tips; } }
        public List<Comment> Comments { get { return comments; } }

        /********** Tip methods ********************/

        public Task<int> AddTipAsync(Tip tip)
        {
            int success = 0;
            if (tip != null)
            {
                // We won't need to add the ID in the real repo
                tip.TipID = tips.Count + 1;
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

        /************** Comment methods *******************/

        public Task<int> AddCommentAsync(Comment comment, int tipId)
        {
            int success = 0;
            if (comment != null && tipId != 0)
            {
                // We won't need to do this in the real repo
                // because the DbContext will do this check
                // as part of the Add method
                Tip tip = tips.Find(t => t.TipID == tipId);
                if (tip != null)
                {
                    comment.CommentID = comments.Count + 1;
                    comments.Add(comment);
                    tip.Comments.Add(comment);
                    success = 1;
                }
            }
            return Task.FromResult<int>(success);
        }
    }
}
