using System.Collections.Generic;

namespace TipOfTheDay.Models
{
    public class TipTagVM
    {
        public Tip Tip { get; set; }
        public TagChoiceVM[] TagSelections { get; set; }
    }
}
