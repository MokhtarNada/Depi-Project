using System;
using System.Collections.Generic;
using System.Text;

namespace EventEF.Models
{
    internal class Ticket
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        public decimal Price { get; set; }
    }
}
