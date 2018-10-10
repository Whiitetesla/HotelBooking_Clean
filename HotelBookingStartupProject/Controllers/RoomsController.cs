using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBooking.Models;
using HotelBooking.BusinessLogic;

namespace HotelBooking.Controllers
{
    public class RoomsController : Controller
    {
        private RoomManager _roomManager;

        public RoomsController(RoomManager roomManager)
        {
            this._roomManager = roomManager;
        }

        // GET: Rooms
        public IActionResult Index()
        {
            var rooms = _roomManager.GetAll();
            return View(rooms);
        }

        // GET: Rooms/Details/5
        public IActionResult Details(int? id)
        {
            var room = _roomManager.Details(id);

            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Description")] Room room)
        {
            if (ModelState.IsValid)
            {
                _roomManager.Add(room);
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Rooms/Edit/5
        public IActionResult Edit(int? id)
        {
            _roomManager.Edit(id);

            return View(id);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Description")] Room room)
        {
            _roomManager.Edit(id, room);
            return RedirectToAction(nameof(Index));
        }

        // GET: Rooms/Delete/5
        public IActionResult Delete(int? id)
        {
            _roomManager.Delete(id);

            return View(id);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _roomManager.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
