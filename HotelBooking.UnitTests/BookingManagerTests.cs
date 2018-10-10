using System;
using System.Collections.Generic;
using HotelBooking.BusinessLogic;
using HotelBooking.Models;
using HotelBooking.UnitTests.Fakes;
using Moq;
using Xunit;

namespace HotelBooking.UnitTests
{
    public class BookingManagerTests
    {
        private IBookingManager bookingManager;

        public BookingManagerTests(){
            DateTime start = DateTime.Today.AddDays(10);
            DateTime end = DateTime.Today.AddDays(20);
            //IRepository<Booking> bookingRepository = new FakeBookingRepository(start, end);
            //IRepository<Room> roomRepository = new FakeRoomRepository();

            Mock<IRepository<Booking>> bookingRepository = new Mock<IRepository<Booking>>();
            Mock<IRepository<Room>> roomRepository = new Mock<IRepository<Room>>();

            bookingRepository.Setup(x => x.GetAll()).Returns(new FakeBookingRepository(start, end).GetAll());
            roomRepository.Setup(x => x.GetAll()).Returns(new FakeRoomRepository().GetAll());

            bookingRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new FakeBookingRepository(start, end).Get(1));

            bookingManager = new BookingManager(bookingRepository.Object, roomRepository.Object);
        }

        [Fact]
        public void FindAvailableRoom_StartDateNotInTheFuture_ThrowsArgumentException()
        {
            DateTime date = DateTime.Today;
            Assert.Throws<ArgumentException>(() => bookingManager.FindAvailableRoom(date, date));
        }

        [Fact]
        public void FindAvailableRoom_RoomAvailable_RoomIdNotMinusOne()
        {
            // Arrange
            DateTime date = DateTime.Today.AddDays(1);
            // Act
            int roomId = bookingManager.FindAvailableRoom(date, date);
            // Assert
            Assert.NotEqual(-1, roomId);
        }

        [Fact]
        public void CreateBooking_newEmptyBooking_thowsExeption()
        {
            // Arrange
            // Act
            // Assert
            Assert.ThrowsAny<Exception>(() => bookingManager.CreateBooking(new Booking()));
        }

        [Fact]
        public void GetFullyOccupiedDates_getAllOccupied_notNull()
        {
            // Arrange
            DateTime startDate = DateTime.Today.AddDays(1);
            DateTime endDate = DateTime.Today.AddDays(2);
            // Act
            List<DateTime> occupied = bookingManager.GetFullyOccupiedDates(startDate, endDate);
            // Assert
            Assert.NotNull(occupied);
        }

    }
}