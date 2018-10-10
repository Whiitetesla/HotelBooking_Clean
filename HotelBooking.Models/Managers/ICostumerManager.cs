using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking.Models.Managers
{
    public interface ICostumerManager
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomer(int id);
        void AddCustomer(Customer customer);
        void EditCustomer(Customer customer);
        void RemoveCustomer(int id);
    }
}
