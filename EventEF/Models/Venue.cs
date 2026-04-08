using System;
using System.Collections.Generic;
using System.Text;

namespace EventEF.Models
{
    internal class Venue
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public List<Event> Events { get; set; }
    }
}
