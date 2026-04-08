using System;
using System.Collections.Generic;
using System.Text;

namespace EventEF.Models
{
    internal class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int VenueId { get; set; }
        public Venue Venue { get; set; }
        public int Capacity { get; set; }
        public List<Booking> Bookings { get; set; }

    }
}
