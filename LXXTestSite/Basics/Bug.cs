using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LXXTestSite.Basics
{
    public class Bug
    {
        public string Id { get; set; }

        public string No { get; set; }

        public string Mikomi { get; set; }

        public string Biko { get; set; }

        public string LackDoc { get; set; }

        public string Title { get; set; }

        public Dictionary<string, string> Details { get; set; }
    }
}