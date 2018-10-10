using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelBooking.Models;
using HotelBooking.Models.Managers;

namespace HotelBooking.BusinessLogic.Managers
{
    public class CustomerManager : ICostumerManager
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerManager(IRepository<Customer> customerRepository)
        {
            if(customerRepository == null)
                throw new ArgumentNullException(nameof(customerRepository));

            this._customerRepository = customerRepository;
        }

        public List<Customer> GetAllCustomers()
        {
            return this._customerRepository.GetAll().ToList();
        }

        public Customer GetCustomer(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            return this._customerRepository.Get(id);
        }

        public void AddCustomer(Customer customer)
        {
            if(customer == null)
                throw new ArgumentNullException(nameof(customer));

            this._customerRepository.Add(customer);
        }

        public void EditCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            this._customerRepository.Edit(customer);
        }

        public void RemoveCustomer(int id)
        {
            if(id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            this._customerRepository.Remove(id);
        }
    }
}
