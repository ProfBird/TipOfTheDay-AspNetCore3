using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TipOfTheDay_Core3.Models
{
    public class Tip
    {
        private List<Language> languages = new List<Language>();
        private List<Tag> tags = new List<Tag>();
        private List<Comment> comments = new List<Comment>();

        public int TipID { get; set; }
        public AppUser Member { get; set; }
        public List<Language> Languages
        {
            get { return languages; }
        }

        public List<Tag> Tags
        {
            get { return tags; }
        }

        public List<Comment> Comments
        {
            get { return comments; }
        }

        public String TipText { get; set; }

    }
}
