using System;
using System.Collections.Generic;
using System.Linq;
using HotelBooking.Models;

namespace HotelBooking.Data.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly HotelBookingContext db;

        public CustomerRepository(HotelBookingContext context)
        {
            db = context;
        }

        public void Add(Customer entity)
        {
            this.db.Customer.Add(entity);
            this.db.SaveChanges();
        }

        public void Edit(Customer entity)
        {
            this.db.Customer.Update(entity);
            this.db.SaveChanges();
        }

        public Customer Get(int id)
        {
            return this.db.Customer.Find(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return db.Customer.ToList();
        }

        public void Remove(int id)
        {            
            this.db.Customer.Remove(this.Get(id));
        }
    }
}
