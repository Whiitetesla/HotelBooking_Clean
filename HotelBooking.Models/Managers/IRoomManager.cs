using HotelBooking.Models;
using System;
using System.Collections.Generic;

namespace HotelBooking.Models
{
    public interface IRoomManager
    {
        IEnumerable<Room> GetAll();
        void Add(Room room);
        int Details(int? id);
        void Edit(int? id);
        void Edit(int id, Room room);
        void Delete(int? id);
        void DeleteConfirmed(int id);
    }
}
