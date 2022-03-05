using System.Collections.Generic;

namespace TipOfTheDay.Models
{
    public class TagChoice
    {
        public bool Selected { get; set; }
        public int TagID { get; set; }
        public string Category { get; set; }
    }
    public class TipTagVM
    {
        public Tip Tip { get; set; }
        public List<TagChoice> TagSelections { get; set; }
    }
}
