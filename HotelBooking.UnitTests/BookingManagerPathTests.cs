using System;
using System.Collections.Generic;
using System.Text;
using HotelBooking.BusinessLogic;
using HotelBooking.Models;
using HotelBooking.UnitTests.Fakes;
using Moq;
using Xunit;

namespace HotelBooking.UnitTests
{
    public class BookingManagerPathTests
    {
        private IBookingManager bookingManager;

        public BookingManagerPathTests()
        {
            DateTime start = DateTime.Today.AddDays(10);
            DateTime end = DateTime.Today.AddDays(20);            

            Mock<IRepository<Booking>> bookingRepository = new Mock<IRepository<Booking>>();
            Mock<IRepository<Room>> roomRepository = new Mock<IRepository<Room>>();

            bookingRepository.Setup(x => x.GetAll()).Returns(new FakeBookingRepository(start, end).GetAll());
            roomRepository.Setup(x => x.GetAll()).Returns(new FakeRoomRepository().GetAll());
            bookingRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new FakeBookingRepository(start, end).Get(1));

            bookingManager = new BookingManager(bookingRepository.Object, roomRepository.Object);
        }


        //Based on the path testing we have derived,
        //that we should have 4 unit tests to fully,
        //cover the methos pathes.

        /// <summary>
        /// This tests equals the first testpath defined from DD path testing.
        /// Test returns -1 when returning in the first if statement. Line 46.
        /// </summary>
        [Fact]
        public void FindAvailableRooms_StartDateBiggerThanEndDate_FirstPath()
        {
            var startdate = DateTime.MaxValue;
            var enddate = DateTime.MinValue;
            
            Assert.Equal(-1, bookingManager.FindAvailableRoom(startdate, enddate));
        }

        /// <summary>
        /// This tests equals the secund testpath defined from DD path testing.
        /// Test returns -1 when exiting the loop because of no rooms on line 58.
        /// </summary>
        [Fact]
        public void FindAvailableRooms_NoActiveRooms_SecundPath()
        {
            DateTime start = DateTime.Today.AddDays(10);
            DateTime end = DateTime.Today.AddDays(20);

            Mock<IRepository<Booking>> bookingRepository = new Mock<IRepository<Booking>>();
            Mock<IRepository<Room>> roomRepository = new Mock<IRepository<Room>>();

            bookingRepository.Setup(x => x.GetAll()).Returns(new FakeBookingRepository(start, end).GetAll());
            roomRepository.Setup(x => x.GetAll()).Returns(new FakeRoomRepositoryFindAvailableRoomsPathTesting().GetAll());
            bookingRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new FakeBookingRepository(start, end).Get(1));


            Assert.Equal(-1, bookingManager.FindAvailableRoom(start, end));
        }

        /// <summary>
        /// This tests equals the third testpath defined from DD path testing.
        /// Test returns -1 when exiting the loop because of no available room in the given period,
        /// on line 58.
        /// </summary>
        [Fact]
        public void FindAvailableRooms_AlreadyBooked_ThirdPath()
        {
            DateTime start = DateTime.Today.AddDays(10);
            DateTime end = DateTime.Today.AddDays(20);

            Mock<IRepository<Booking>> bookingRepository = new Mock<IRepository<Booking>>();
            bookingRepository.Setup(x => x.GetAll()).Returns(
                new FakeBookingRepository(start, end).GetAll());

            Assert.Equal(-1, bookingManager.FindAvailableRoom(start, end));
        }

        /// <summary>
        /// This tests equals the fourth testpath defined from DD path testing.
        /// Test returns aa room ID when finding a room inside of the loop, at line55.
        /// </summary>
        [Fact]
        public void FindAvailableRooms_FoundARoom_FourthPath()
        {            
            DateTime start = DateTime.Today.AddDays(10);
            DateTime end = DateTime.Today.AddDays(20);

            Mock<IRepository<Booking>> bookingRepository = new Mock<IRepository<Booking>>();
            Mock<IRepository<Room>> roomRepository = new Mock<IRepository<Room>>();

            bookingRepository.Setup(x => x.GetAll()).Returns(new FakeBookingRepository(start, end).GetAll());
            roomRepository.Setup(x => x.GetAll()).Returns(new FakeRoomRepository().GetAll());
            bookingRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new FakeBookingRepository(start, end).Get(1));

            bookingManager = new BookingManager(bookingRepository.Object, roomRepository.Object);

            var bookingDateStart = DateTime.Today.AddDays(1);
            var bookingDateEnd = DateTime.Today.AddDays(5);
            
            int roomId = bookingManager.FindAvailableRoom(bookingDateStart, bookingDateEnd);            
            Assert.NotEqual(-1, roomId);           
        }
    }
}
