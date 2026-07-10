using EventHub_MVC.Models;
using EventHub_MVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EventHub_MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IEventRepository _eventRepo;
        private readonly IBookingRepository _bookingRepo;

        public HomeController(IEventRepository eventRepo, IBookingRepository bookingRepo)
        {
            _eventRepo = eventRepo;
            _bookingRepo = bookingRepo;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _eventRepo.GetAllAsync();
            var bookings = await _bookingRepo.GetAllAsync();

            ViewBag.TotalEvents = events.Count;
            ViewBag.TotalBookings = bookings.Count;
            ViewBag.TotalTicketsSold = bookings.Sum(b => b.NumberOfTickets);

            return View();
        }
    }
}