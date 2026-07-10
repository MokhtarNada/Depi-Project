using System;
using System.Collections.Generic;

namespace EventHub_MVC.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int Capacity { get; set; }

        public int VenueId { get; set; }
        public Venue? Venue { get; set; }

        public List<Booking> Bookings { get; set; } = new();
    }
}