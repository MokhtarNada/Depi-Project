using System.Collections.Generic;

namespace EventHub_MVC.Models
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;

        public List<Event> Events { get; set; } = new();
    }
}