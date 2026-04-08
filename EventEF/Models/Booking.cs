using System;
using System.Collections.Generic;
using System.Text;

namespace EventEF.Models
{
    internal class Booking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int NumberOfTickets {  get; set; }
        public DateTime BookingDate { get; set; }
    }
}
