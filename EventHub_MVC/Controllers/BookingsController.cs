using EventHub_MVC.Models;
using EventHub_MVC.Repositories;
using EventHub_MVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace EventHub_MVC.Controllers
{
    [Authorize]
    public class BookingsController : Controller
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly IEventRepository _eventRepo;

        public BookingsController(IBookingRepository bookingRepo, IEventRepository eventRepo)
        {
            _bookingRepo = bookingRepo;
            _eventRepo = eventRepo;
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            List<Booking> bookings = await _bookingRepo.GetAllWithIncludesAsync();
            return View(bookings);
        }
        public async Task<IActionResult> Create(int? eventId)
        {
            var events = await _eventRepo.GetAllAsync();
            ViewBag.EventId = new SelectList(events, "Id", "Name", eventId);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Booking booking)
        {
            var events = await _eventRepo.GetAllAsync();
            if (ModelState.IsValid)
            {
                var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (string.IsNullOrEmpty(currentUserId))
                {
                    return BadRequest();
                }

                booking.UserId = currentUserId;

                var ev = await _eventRepo.GetByIdAsync(booking.EventId);
                if (ev == null) return NotFound("Event not found");

                var alreadyBooked = await _bookingRepo.GetTotalBookedTicketsAsync(booking.EventId);

                if (alreadyBooked + booking.NumberOfTickets > ev.Capacity)
                {
                    ModelState.AddModelError("", "Not enough capacity available");
                    ViewBag.EventId = new SelectList(events, "Id", "Name", booking.EventId);
                    return View(booking);
                }

                booking.BookingDate = DateTime.Now;
                await _bookingRepo.AddAsync(booking);
                await _bookingRepo.SaveAsync();

                return RedirectToAction("Index", "Home");
            }
            ViewBag.EventId = new SelectList(events, "Id", "Name", booking.EventId);

            return View(booking);
        }
    }
}
