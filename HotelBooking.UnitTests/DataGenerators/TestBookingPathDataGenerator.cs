using HotelBooking.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking.UnitTests.DataGenerators
{
    public class TestBookingPathDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { new List<Booking>{new Booking { Id=1, StartDate=DateTime.Today.AddDays(20), EndDate=DateTime.Today.AddDays(-20), IsActive=false, CustomerId=1, RoomId=1 },
                           new Booking { Id=2, StartDate=DateTime.Today.AddDays(20), EndDate=DateTime.Today.AddDays(-20), IsActive=false, CustomerId=2, RoomId=2 },
            } },
            new object[] { new List<Booking>{new Booking { Id=1, StartDate=DateTime.Now, EndDate=DateTime.Now, IsActive=false, CustomerId=1, RoomId=1 },
                           new Booking { Id=2, StartDate=DateTime.Now, EndDate=DateTime.Now, IsActive=false, CustomerId=2, RoomId=2 },
            } },
            new object[] { new List<Booking>{new Booking { Id=1, StartDate=DateTime.Today.AddDays(20), EndDate=DateTime.Now, IsActive=true, CustomerId=1, RoomId=1 },
                           new Booking { Id=2, StartDate=DateTime.Today.AddDays(20), EndDate=DateTime.Now, IsActive=true, CustomerId=2, RoomId=2 },
            } },
            new object[] { new List<Booking>{new Booking { Id=1, StartDate=DateTime.Now, EndDate=DateTime.Today.AddDays(-20), IsActive=true, CustomerId=1, RoomId=1 },
                           new Booking { Id=2, StartDate=DateTime.Now, EndDate=DateTime.Today.AddDays(-20), IsActive=true, CustomerId=2, RoomId=2 },
            } }
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
