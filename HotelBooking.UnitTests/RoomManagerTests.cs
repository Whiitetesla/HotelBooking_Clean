using System;
using HotelBooking.BusinessLogic;
using HotelBooking.Models;
using HotelBooking.UnitTests.Fakes;
using Moq;
using Xunit;

namespace HotelBooking.UnitTests
{
    public class RoomManagerTests
    {

        private Mock<IRepository<Room>> _roomRepositoryMock;
        private IRoomManager _roomManager;

   
        public RoomManagerTests()
        {
            this._roomRepositoryMock = new Mock<IRepository<Room>>();

            this._roomManager = new RoomManager(this._roomRepositoryMock.Object);
            
        }

        [Fact]
        public void GetAll()
        {
            // Yes
        }

        [Fact]
        public void AddRoom_RoomNull_NullReference()
        {
            Room room = null;

            Assert.Throws<NullReferenceException>(() => this._roomManager.Add(room));
        }

        [Fact]
        public void Details_IdNull_NullReference()
        {
            int? id = null;
            Assert.Throws<NullReferenceException>(() => this._roomManager.Details(id));
        }

        [Fact]
        public void Get_RoomNull_NullReference()
        {
            Room room = null;
            Assert.Throws<NullReferenceException>(() => this._roomManager.Get(room.Id));
        }

        [Fact]
        public void Edit_IdNull_OutOfRange()
        {
            int? id = null;
            Assert.Throws<NullReferenceException>(() => this._roomManager.Edit(id));
        }

        [Fact]
        public void Delete_IdNull_NullReference()
        {
            int? id = null;
            Assert.Throws<NullReferenceException>(() => this._roomManager.Delete(id));
        }

        [Fact]
        public void Edit_IdNotEqualRoomId_OutOfRange()
        {
            int id = 4;
            Room room = new Room();
            room.Id = 2;
            Assert.Throws<ArgumentOutOfRangeException>(() => this._roomManager.Edit(id, room));
        }

    }

}
