using EventHub_MVC.Data;
using EventHub_MVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using EventHub_MVC.Models;

namespace EventHub_MVC.Repositories
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(AppDBContext context) : base(context) { }

        public async Task<List<Event>> GetAllWithVenueAsync()
        {
            return await _context.Events.Include(e => e.Venue).ToListAsync();
        }

        public async Task<Event> GetByIdWithVenueAsync(int id)
        {
            return await _context.Events.Include(e => e.Venue)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
