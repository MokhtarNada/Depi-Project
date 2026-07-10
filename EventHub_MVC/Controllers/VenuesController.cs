using EventHub_MVC.Models;
using EventHub_MVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventHub_MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class VenuesController : Controller
    {
        private readonly IGenericRepository<Venue> _venueRepo;

        public VenuesController(IGenericRepository<Venue> venueRepo)
        {
            _venueRepo = venueRepo;
        }

        public async Task<IActionResult> Index()
        {
            List<Venue> venues = await _venueRepo.GetAllAsync();
            return View(venues);
        }

        public async Task<IActionResult> Details(int id)
        {
            var venue = await _venueRepo.GetByIdAsync(id);
            if (venue == null) return NotFound();
            return View(venue);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Venue venue)
        {
            if (ModelState.IsValid)
            {
                await _venueRepo.AddAsync(venue);
                await _venueRepo.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(venue);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var venue = await _venueRepo.GetByIdAsync(id);
            if (venue == null) return NotFound();
            return View(venue);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Venue venue)
        {
            if (id != venue.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                _venueRepo.Update(venue);
                await _venueRepo.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(venue);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var venue = await _venueRepo.GetByIdAsync(id);
            if (venue == null) return NotFound();
            return View(venue);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Venue venue)
        {
            if (venue != null)
            {
                _venueRepo.Delete(venue);
                await _venueRepo.SaveAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
