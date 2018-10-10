
using System;
using System.Linq;
using System.Collections.Generic;
using HotelBooking.Models;

namespace HotelBooking.BusinessLogic
{
    public class RoomManager : IRoomManager
    {
        private IRepository<Room> _repository;

        public IEnumerable<Room> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public RoomManager(IRepository<Room> repository)
        {
            this._repository = repository;
        }

        public int Details(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }

            Room room = _repository.Get(id.Value);

            if (room == null)
            {
                throw new NullReferenceException();
            }

            return id.GetValueOrDefault();
        }

        public void Edit(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }

            Room room = _repository.Get(id.Value);

            if (room == null)
            {
                throw new NullReferenceException();
            }
        }

        public void Add(Room room)
        {
            if (room == null)
            {
                throw new NullReferenceException();
            }
            _repository.Add(room);
        }

        public void Delete(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }

            var room = _repository.Get(id.Value);
            if (room == null)
            {
                throw new NullReferenceException();
            }
        }

        public void DeleteConfirmed(int id)
        {
            if (id > 0)
                _repository.Remove(id);
        }

        public void Edit(int id, Room room)
        {
            if (id != room.Id)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (_repository.Get(room.Id) == null)
            {
                throw new NullReferenceException();
            }
            _repository.Edit(room);
        }

        public Room Get(int id)
        {
            return _repository.Get(id);
        }
    }
}

