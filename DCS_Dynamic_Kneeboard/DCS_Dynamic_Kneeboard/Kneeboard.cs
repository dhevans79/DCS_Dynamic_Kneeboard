using System;
using System.Collections.Generic;
using System.Text;

namespace DCS_Dynamic_Kneeboard
{
    class Kneeboard
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Dictionary<string, Page> Pages { get; set; }
    }
}
