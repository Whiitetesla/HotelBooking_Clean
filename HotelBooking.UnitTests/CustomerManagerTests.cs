using System;
using System.Collections.Generic;
using System.Text;
using HotelBooking.BusinessLogic.Managers;
using HotelBooking.Models;
using HotelBooking.Models.Managers;
using Moq;
using Xunit;

namespace HotelBooking.UnitTests
{
    public class CustomerManagerTests
    {
        private Mock<IRepository<Customer>> _customerRepositoryMock;
        private ICostumerManager _costumerManager;


        public CustomerManagerTests()
        {            
            this._customerRepositoryMock = new Mock<IRepository<Customer>>();  
            
            this._costumerManager = new CustomerManager(this._customerRepositoryMock.Object);
        }

        [Fact]
        public void GetCustomer_ZeroId_ThrowsArgument()
        {
            int id = 0;

            Assert.Throws<ArgumentOutOfRangeException>(() => this._costumerManager.GetCustomer(id));
        }

        [Fact]
        public void GetCustomer_NegativeId_ThrowsArgument()
        {
            int id = -10;

            Assert.Throws<ArgumentOutOfRangeException>(() => this._costumerManager.GetCustomer(id));
        }

        [Fact]
        public void AddCustomer_NullCustomer_ThrowsArgument()
        {
            Customer customer = null;

            Assert.Throws<ArgumentNullException>(() => this._costumerManager.AddCustomer(customer));
        }

        [Fact]
        public void EditCustomer_NullCustomer_ThrowsArgument()
        {
            Customer customer = null;

            Assert.Throws<ArgumentNullException>(() => this._costumerManager.EditCustomer(customer));
        }

        [Fact]
        public void RemoveCustomer_ZeroId_ThrowsArgument()
        {
            int id = 0;

            Assert.Throws<ArgumentOutOfRangeException>(() => this._costumerManager.RemoveCustomer(id));
        }

        [Fact]
        public void RemoveCustomer_NegativeId_ThrowsArgument()
        {
            int id = -10;

            Assert.Throws<ArgumentOutOfRangeException>(() => this._costumerManager.RemoveCustomer(id));
        }

    }
}
