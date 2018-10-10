using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking.UnitTests.DataGenerators
{
    public class TestBookingDataGenerator : IEnumerable<object[]>
    {

        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { DateTime.Today.AddDays(1), DateTime.Today.AddDays(1) },
            new object[] { DateTime.Today.AddDays(2), DateTime.Today.AddDays(2) },
            new object[] { DateTime.Today.AddDays(5), DateTime.Today.AddDays(5) },
            new object[] { DateTime.Today.AddDays(8), DateTime.Today.AddDays(8) },
            new object[] { DateTime.Today.AddDays(159), DateTime.Today.AddDays(159) }
};

        public IEnumerator<object[]> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
