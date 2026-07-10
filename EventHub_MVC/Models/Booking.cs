using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace EventHub_MVC.Models
{
    public class Booking
    {
        public int Id { get; set; }
        [Range(1, int.MaxValue)]
        public int NumberOfTickets { get; set; }
        public DateTime BookingDate { get; set; }

        public string UserId { get; set; } = String.Empty;
        public AppUser? User { get; set; }

        public int EventId { get; set; }
        public Event? Event { get; set; }
    }
}