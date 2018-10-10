using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelBooking.Models;
using HotelBookingStartupProject.Models;
using HotelBooking.Models.Managers;

namespace HotelBooking.Controllers
{
    public class BookingsController : Controller
    {
        private IRepository<Room> roomRepository;
        private ICostumerManager customerManager;
        private IBookingManager bookingManager;
        private IBookingViewModel bookingViewModel;

        public BookingsController(IRepository<Booking> bookingRepos, IRepository<Room> roomRepos,
            ICostumerManager costManager ,IBookingManager manager, IBookingViewModel viewModel)
        {
            this.roomRepository = roomRepos;
            this.customerManager = costManager;
            this.bookingManager = manager;
            this.bookingViewModel = viewModel;
        }

        // GET: Bookings
        public IActionResult Index(int? id)
        {
            bookingViewModel.YearToDisplay = (id == null) ? DateTime.Today.Year : id.Value;
            return View(bookingViewModel);
        }

        // GET: Bookings/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Booking booking = bookingManager.GetBooking(id.Value);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(customerManager.GetAllCustomers(), "Id", "Name");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("StartDate,EndDate,CustomerId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                bookingManager.CreateBooking(booking);

                return RedirectToAction(nameof(Index));
            }

            ViewData["CustomerId"] = new SelectList(customerManager.GetAllCustomers(), "Id", "Name", booking.CustomerId);
            ViewBag.Status = "The booking could not be created. There were no available room.";
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Booking booking = bookingManager.GetBooking(id.Value);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(customerManager.GetAllCustomers(), "Id", "Name", booking.CustomerId);
            ViewData["RoomId"] = new SelectList(roomRepository.GetAll(), "Id", "Description", booking.RoomId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("StartDate,EndDate,IsActive,CustomerId,RoomId")] Booking booking)
        {
            if (id != booking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bookingManager.EditBooking(booking);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (bookingManager.GetBooking(booking.Id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(customerManager.GetAllCustomers(), "Id", "Name", booking.CustomerId);
            ViewData["RoomId"] = new SelectList(roomRepository.GetAll(), "Id", "Description", booking.RoomId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Booking booking = bookingManager.GetBooking(id.Value);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            bookingManager.RemoveBooking(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
