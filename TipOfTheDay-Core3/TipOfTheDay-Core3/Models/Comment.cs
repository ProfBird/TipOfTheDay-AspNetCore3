using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TipOfTheDay_Core3.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public AppUser Member { get; set; }
        public String CommentText { get; set; }
    }
}
