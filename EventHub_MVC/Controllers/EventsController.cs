using EventHub_MVC.Models;
using EventHub_MVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventHub_MVC.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private readonly IEventRepository _eventRepo;
        private readonly IGenericRepository<Venue> _venueRepo;
        public EventsController(IEventRepository eventRepo, IGenericRepository<Venue> venueRepo)
        {
            _eventRepo = eventRepo;
            _venueRepo = venueRepo;
        }

        public async Task<IActionResult> Index()
        {
            List<Event> events = await _eventRepo.GetAllWithVenueAsync();
            return View(events);
        }

        public async Task<IActionResult> Details(int id)
        {
            var ev = await _eventRepo.GetByIdWithVenueAsync(id);
            if (ev == null) return NotFound();
            return View(ev);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            var venues = await _venueRepo.GetAllAsync();
            ViewBag.VenueId = new SelectList(venues, "Id", "Name");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Event ev)
        {
            if (ModelState.IsValid)
            {
                await _eventRepo.AddAsync(ev);
                await _eventRepo.SaveAsync();
                return RedirectToAction("Index");
            }
            var venues = await _venueRepo.GetAllAsync();
            ViewBag.VenueId = new SelectList(venues, "Id", "Name", ev.VenueId);
            return View(ev);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var ev = await _eventRepo.GetByIdAsync(id);
            if (ev == null) return NotFound();
            var venues = await _venueRepo.GetAllAsync();
            ViewBag.VenueId = new SelectList(venues, "Id", "Name", ev.VenueId);
            return View(ev);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, Event ev)
        {
            if (id != ev.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                _eventRepo.Update(ev);
                await _eventRepo.SaveAsync();
                return RedirectToAction("Index");
            }
            var venues = await _venueRepo.GetAllAsync();
            ViewBag.VenueId = new SelectList(venues, "Id", "Name", ev.VenueId);
            return View(ev);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var ev = await _eventRepo.GetByIdWithVenueAsync(id);
            if (ev == null) return NotFound();
            return View(ev);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Event ev)
        {
            if (ev != null)
            {
                _eventRepo.Delete(ev);
                await _eventRepo.SaveAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
