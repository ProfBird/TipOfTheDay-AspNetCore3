using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TipOfTheDay.Models
{
    public class Tag
    {
        private List<Tip> tips = new List<Tip>();
        public int TagID { get; set; }
        public String Category { get; set; }

        public List<Tip> Tips 
        {
            get {return tips;}
        }
    }
}
