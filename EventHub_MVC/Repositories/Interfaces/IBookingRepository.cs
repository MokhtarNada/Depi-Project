using EventHub_MVC.Models;

namespace EventHub_MVC.Repositories.Interfaces
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        Task<List<Booking>> GetAllWithIncludesAsync();
        Task<int> GetTotalBookedTicketsAsync(int eventId);
    }
}
