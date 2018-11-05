using HotelBooking.Models;
using System;
using HotelBooking.BusinessLogic;
using HotelBooking.SpecFlow.Fakes;
using Moq;
using TechTalk.SpecFlow;
using Xunit;

namespace HotelBooking.SpecFlow
{
    [Binding]
    public class CreateBookingExamplesSteps
    {
        private IBookingManager bookingManager;
        private DateTime Start;
        private DateTime End;

        private IRepository<Booking> bookingRepository;
        private IRepository<Room> roomRepository;

        public CreateBookingExamplesSteps()
        {
        }

        [Given(@"I have entered a '(.*)' and '(.*)'")]
        public void GivenIHaveEnteredAAnd(string p0, string p1)
        {
            Start = DateTime.Parse(p0);
            End = DateTime.Parse(p1);
        }

        [Given(@"a room is already booked from '(.*)' to '(.*)'")]
        public void GivenARoomIsAlreadyBookedFromTo(string p0, string p1)
        {
            var start = DateTime.Parse(p0);
            var end = DateTime.Parse(p1);

            Mock<IRepository<Booking>> bookingRepository = new Mock<IRepository<Booking>>();
            Mock<IRepository<Room>> roomRepository = new Mock<IRepository<Room>>();

            bookingRepository.Setup(x => x.GetAll()).Returns(new FakeBookingRepository(start, end).GetAll());
            roomRepository.Setup(x => x.GetAll()).Returns(new FakeRoomRepository().GetAll());
            bookingRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new FakeBookingRepository(start, end).Get(1));

            this.bookingRepository = bookingRepository.Object;
            this.roomRepository = roomRepository.Object;
        }

        [When(@"I press create booking")]
        public void WhenIPressCreateBooking()
        {
            bookingManager = new BookingManager(bookingRepository, roomRepository);
        }
        
        [Then(@"the result should be '(.*)'")]
        public void ThenTheResultShouldBe(string p0)
        {
            var booking = new Booking()
            {
                StartDate = Start,
                EndDate = End
            };

            var result = bookingManager.CreateBooking(booking);

            Assert.Equal(result, bool.Parse(p0));
        }
    }
}
