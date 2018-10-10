using HotelBooking.Models;
using System;
using System.Collections.Generic;

namespace HotelBooking.Models
{
    public interface IBookingManager
    {
        void CreateBooking(Booking booking);
        int FindAvailableRoom(DateTime startDate, DateTime endDate);
        List<DateTime> GetFullyOccupiedDates(DateTime startDate, DateTime endDate);
    }
}
