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
        /// This tests equals the second testpath defined from DD path testing.
        /// Test returns -1 when exiting the loop because of no rooms on line 58.
        /// </summary>
        [Fact]
        public void FindAvailableRooms_NoActiveRooms_SecondPath()
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


        //Because of miltiple conditions inside the if statement,
        //it is nessary to test every prosible outcome within resonable boundaries,
        //for this case

        /// <summary>
        /// Case 1
        /// This tests equals the fourth testpath defined from DD path testing.
        /// Test returns a room ID when finding a room inside of the loop, at line 55.
        /// </summary>
        [Fact]
        public void FindAvailableRoomsCase1_FoundARoom_FourthPath()
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

        /// <summary>
        /// Case 2
        /// This tests equals the fourth testpath defined from DD path testing.
        /// Test returns a room ID when finding a room inside of the loop, at line 55.
        /// </summary>
        [Fact]
        public void FindAvailableRoomsCase2_FoundARoom_FourthPath()
        {
            DateTime start = DateTime.Today.AddDays(10);
            DateTime end = DateTime.Today.AddDays(20);

            Mock<IRepository<Booking>> bookingRepository = new Mock<IRepository<Booking>>();
            Mock<IRepository<Room>> roomRepository = new Mock<IRepository<Room>>();

            bookingRepository.Setup(x => x.GetAll()).Returns(new FakeBookingRepository(start, end).GetAll());
            roomRepository.Setup(x => x.GetAll()).Returns(new FakeRoomRepository().GetAll());
            bookingRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new FakeBookingRepository(start, end).Get(1));

            bookingManager = new BookingManager(bookingRepository.Object, roomRepository.Object);

            var bookingDateStart = DateTime.Today.AddDays(6);
            var bookingDateEnd = DateTime.Today.AddDays(11);

            int roomId = bookingManager.FindAvailableRoom(bookingDateStart, bookingDateEnd);
            Assert.Equal(-1, roomId);
        }

        /// <summary>
        /// Case 3
        /// This tests equals the fourth testpath defined from DD path testing.
        /// Test returns a room ID when finding a room inside of the loop, at line 55.
        /// </summary>
        [Fact]
        public void FindAvailableRoomsCase3_FoundARoom_FourthPath()
        {
            DateTime start = DateTime.Today.AddDays(10);
            DateTime end = DateTime.Today.AddDays(20);

            Mock<IRepository<Booking>> bookingRepository = new Mock<IRepository<Booking>>();
            Mock<IRepository<Room>> roomRepository = new Mock<IRepository<Room>>();

            bookingRepository.Setup(x => x.GetAll()).Returns(new FakeBookingRepository(start, end).GetAll());
            roomRepository.Setup(x => x.GetAll()).Returns(new FakeRoomRepository().GetAll());
            bookingRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new FakeBookingRepository(start, end).Get(1));

            bookingManager = new BookingManager(bookingRepository.Object, roomRepository.Object);

            var bookingDateStart = DateTime.Today.AddDays(13);
            var bookingDateEnd = DateTime.Today.AddDays(15);

            int roomId = bookingManager.FindAvailableRoom(bookingDateStart, bookingDateEnd);
            Assert.Equal(-1, roomId);
        }

        /// <summary>
        /// Case 4
        /// This tests equals the fourth testpath defined from DD path testing.
        /// Test returns a room ID when finding a room inside of the loop, at line 55.
        /// </summary>
        [Fact]
        public void FindAvailableRoomsCase4_FoundARoom_FourthPath()
        {
            DateTime start = DateTime.Today.AddDays(10);
            DateTime end = DateTime.Today.AddDays(20);

            Mock<IRepository<Booking>> bookingRepository = new Mock<IRepository<Booking>>();
            Mock<IRepository<Room>> roomRepository = new Mock<IRepository<Room>>();

            bookingRepository.Setup(x => x.GetAll()).Returns(new FakeBookingRepository(start, end).GetAll());
            roomRepository.Setup(x => x.GetAll()).Returns(new FakeRoomRepository().GetAll());
            bookingRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new FakeBookingRepository(start, end).Get(1));

            bookingManager = new BookingManager(bookingRepository.Object, roomRepository.Object);

            var bookingDateStart = DateTime.Today.AddDays(17);
            var bookingDateEnd = DateTime.Today.AddDays(13);

            int roomId = bookingManager.FindAvailableRoom(bookingDateStart, bookingDateEnd);
            Assert.Equal(-1, roomId);
        }

        /// <summary>
        /// Case 5
        /// This tests equals the fourth testpath defined from DD path testing.
        /// Test returns a room ID when finding a room inside of the loop, at line 55.
        /// </summary>
        [Fact]
        public void FindAvailableRoomsCase5_FoundARoom_FourthPath()
        {
            DateTime start = DateTime.Today.AddDays(10);
            DateTime end = DateTime.Today.AddDays(20);

            Mock<IRepository<Booking>> bookingRepository = new Mock<IRepository<Booking>>();
            Mock<IRepository<Room>> roomRepository = new Mock<IRepository<Room>>();

            bookingRepository.Setup(x => x.GetAll()).Returns(new FakeBookingRepository(start, end).GetAll());
            roomRepository.Setup(x => x.GetAll()).Returns(new FakeRoomRepository().GetAll());
            bookingRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new FakeBookingRepository(start, end).Get(1));

            bookingManager = new BookingManager(bookingRepository.Object, roomRepository.Object);

            var bookingDateStart = DateTime.Today.AddDays(22);
            var bookingDateEnd = DateTime.Today.AddDays(25);

            int roomId = bookingManager.FindAvailableRoom(bookingDateStart, bookingDateEnd);
            Assert.NotEqual(-1, roomId);
        }

        /// <summary>
        /// This tests equals the first testpath defined from DD path testing.
        /// Test returns a exeption in the first if statement. Line 69.
        /// </summary>
        [Fact]
        public void GetFullyOccupiedDates_StartDateBiggerThanEndDate_FirstPath()
        {
            DateTime start = DateTime.Today.AddDays(20);
            DateTime end = DateTime.Today.AddDays(10);

            Mock<IRepository<Booking>> bookingRepository = new Mock<IRepository<Booking>>();
            Mock<IRepository<Room>> roomRepository = new Mock<IRepository<Room>>();

            bookingRepository.Setup(x => x.GetAll()).Returns(new FakeBookingRepository(start, end).GetAll());
            roomRepository.Setup(x => x.GetAll()).Returns(new FakeRoomRepository().GetAll());
            bookingRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new FakeBookingRepository(start, end).Get(1));

            bookingManager = new BookingManager(bookingRepository.Object, roomRepository.Object);
            
            Assert.ThrowsAny<Exception>(() => bookingManager.GetFullyOccupiedDates(start, end));
        }

        /// <summary>
        /// This tests equals the second testpath defined from DD path testing.
        /// Test returns an empty list in the second if statement. Line 75.
        /// </summary>
        [Fact]
        public void GetFullyOccupiedDates_NoBookings_SecondPath()
        {
            DateTime start = DateTime.Today.AddDays(10);
            DateTime end = DateTime.Today.AddDays(20);

            Mock<IRepository<Booking>> bookingRepository = new Mock<IRepository<Booking>>();
            Mock<IRepository<Room>> roomRepository = new Mock<IRepository<Room>>();

            bookingRepository.Setup(x => x.GetAll()).Returns(new List<Booking>());
            roomRepository.Setup(x => x.GetAll()).Returns(new FakeRoomRepository().GetAll());
            bookingRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new FakeBookingRepository(start, end).Get(1));

            bookingManager = new BookingManager(bookingRepository.Object, roomRepository.Object);

            Assert.Equal(new List<DateTime>(), bookingManager.GetFullyOccupiedDates(start, end));
        }

        /// <summary>
        /// This tests equals the third testpath defined from DD path testing.
        /// Test returns an empty list in the first if statement. in the loop
        /// Line 77.
        /// </summary>
        [Fact]
        public void GetFullyOccupiedDates_NoOccupiedDates_ThirdPath()
        {
            DateTime start = DateTime.Today.AddDays(10);
            DateTime end = DateTime.Today.AddDays(11);

            Mock<IRepository<Booking>> bookingRepository = new Mock<IRepository<Booking>>();
            Mock<IRepository<Room>> roomRepository = new Mock<IRepository<Room>>();

            bookingRepository.Setup(x => x.GetAll()).Returns(new List<Booking>()
                                                        { new FakeBookingRepository(start, end).Get(1) });
            roomRepository.Setup(x => x.GetAll()).Returns(new FakeRoomRepository().GetAll());
            bookingRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new FakeBookingRepository(start, end).Get(1));

            bookingManager = new BookingManager(bookingRepository.Object, roomRepository.Object);

            Assert.Equal(new List<DateTime>(), bookingManager.GetFullyOccupiedDates(start, end));
        }

        /// <summary>
        /// This tests equals the third testpath defined from DD path testing.
        /// Test returns a list with some elements in the first if statement. in the loop
        /// Line 77.
        /// </summary>
        [Fact]
        public void GetFullyOccupiedDates_FoundOccupiedDates_FourthPath()
        {
            DateTime start = DateTime.Today.AddDays(10);
            DateTime end = DateTime.Today.AddDays(20);

            Mock<IRepository<Booking>> bookingRepository = new Mock<IRepository<Booking>>();
            Mock<IRepository<Room>> roomRepository = new Mock<IRepository<Room>>();

            bookingRepository.Setup(x => x.GetAll()).Returns(new FakeBookingRepository(start,end).GetAll());
            roomRepository.Setup(x => x.GetAll()).Returns(new FakeRoomRepository().GetAll());
            bookingRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new FakeBookingRepository(start, end).Get(1));

            bookingManager = new BookingManager(bookingRepository.Object, roomRepository.Object);

            Assert.NotEqual(new List<DateTime>(), bookingManager.GetFullyOccupiedDates(start, end));
        }
    }
}
