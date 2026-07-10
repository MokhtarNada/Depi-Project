using EventHub_MVC.Models;

namespace EventHub_MVC.Repositories.Interfaces
{
    public interface IEventRepository : IGenericRepository<Event>
    {
        Task<List<Event>> GetAllWithVenueAsync();
        Task<Event> GetByIdWithVenueAsync(int id);
    }
}
