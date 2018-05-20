using System;
using System.Collections.Generic;
using System.Text;

namespace DCS_Dynamic_Kneeboard
{
    class Page
    {
        public string PageName { get; set; }
        public Dictionary<int, MyListItem>  Items { get; set; }

    }
}
