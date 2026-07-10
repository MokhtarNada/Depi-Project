using Microsoft.AspNetCore.Identity;

namespace EventHub_MVC.Models
{
    public class AppUser : IdentityUser
    {
        public List<Booking> Bookings { get; set; }
    }
}
