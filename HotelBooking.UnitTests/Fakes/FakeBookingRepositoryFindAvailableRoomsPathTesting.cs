using System;
using System.Collections.Generic;
using System.Text;
using HotelBooking.Models;

namespace HotelBooking.UnitTests.Fakes
{
    public class FakeBookingRepositoryFindAvailableRoomsPathTesting : IRepository<Booking>
    {
        private DateTime fullyOccupiedStartDate;
        private DateTime fullyOccupiedEndDate;

        public FakeBookingRepositoryFindAvailableRoomsPathTesting(DateTime start, DateTime end)
        {
            fullyOccupiedStartDate = start;
            fullyOccupiedEndDate = end;
        }

        // This field is exposed so that a unit test can validate that the
        // Add method was invoked.
        public bool addWasCalled = false;

        public void Add(Booking entity)
        {
            addWasCalled = true;
        }

        // This field is exposed so that a unit test can validate that the
        // Edit method was invoked.
        public bool editWasCalled = false;

        public void Edit(Booking entity)
        {
            editWasCalled = true;
        }

        public Booking Get(int id)
        {
            return new Booking { Id = 1, StartDate = fullyOccupiedStartDate, EndDate = fullyOccupiedEndDate, IsActive = true, CustomerId = 1, RoomId = 1 };
        }

        public IEnumerable<Booking> GetAll()
        {
            List<Booking> bookings = new List<Booking>
            {
                 
            };
            return bookings;
        }

        public IEnumerable<Booking> GetAll_ReturnEmptyList()
        {
            List<Booking> bookings = new List<Booking>
            {

            };
            return bookings;
        }



        // This field is exposed so that a unit test can validate that the
        // Remove method was invoked.
        public bool removeWasCalled = false;

        public void Remove(int id)
        {
            removeWasCalled = true;
        }
    }
}
