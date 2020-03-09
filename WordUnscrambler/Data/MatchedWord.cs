using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler.Data
{
    public struct MatchedWord  //change to struct(Look like classes but are value types, categorize variables)
    {
        public string ScrambledWord { get; set; } //can get and set
        public string Word { get; set; }
    }
}
