using EventHub_MVC.Data;
using EventHub_MVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using EventHub_MVC.Models;

namespace EventHub_MVC.Repositories
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(AppDBContext context) : base(context) { }

        public async Task<List<Booking>> GetAllWithIncludesAsync()
        {
            return await _context.Bookings
                .Include(b => b.User)
                .Include(b => b.Event)
                .ToListAsync();
        }

        public async Task<int> GetTotalBookedTicketsAsync(int eventId)
        {
            return await _context.Bookings
                .Where(b => b.EventId == eventId)
                .SumAsync(b => b.NumberOfTickets);
        }
    }
}