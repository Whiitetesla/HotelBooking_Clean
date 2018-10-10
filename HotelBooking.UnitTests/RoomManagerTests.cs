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
        public void Add()
        {
            Room room = null;

            Assert.Throws<ArgumentNullException>(() => this._roomManager.Add(room));
        }

        [Fact]
        public void Details()
        {
            int id = 0;
            Assert.Throws<ArgumentOutOfRangeException>(() => this._roomManager.Edit(id));

        }

        [Fact]
        public void Edit()
        {
            int id = 0;
            Assert.Throws<ArgumentOutOfRangeException>(() => this._roomManager.Edit(id));
        }
        [Fact]
        public void Edit2()
        {
            int id = 0;
            Room room = null;
            Assert.Throws<ArgumentOutOfRangeException>(() => this._roomManager.Edit(id, room));
        }

        [Fact]
        public void Delete()
        {
            int id = -10;

            Assert.Throws<ArgumentOutOfRangeException>(() => this._roomManager.Delete(id));
        }

        [Fact]
        public void DeleteConfirmed()
        {
            int id = -10;

            Assert.Throws<ArgumentOutOfRangeException>(() => this._roomManager.Delete(id));
        }

    }

}
