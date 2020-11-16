using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StoreProject.Library.Customer;
using System.Linq;

namespace StoreProjectDB.DataModel
{
    public class CustomerRepository
    {
        private readonly DbContextOptions<danielGProj0DBContext> _contextOptions;

        public CustomerRepository(DbContextOptions<danielGProj0DBContext> contextOptions)
        {
            _contextOptions = contextOptions;
        }


        public List<CustomerClass> GetAllCustomers()
        {
            // Create Context
            using var context = new danielGProj0DBContext(_contextOptions);
            // Get DB Object list of customers
            var dbCustomers = context.Customers.ToList();
            // Make DB list into Console Customers list
            var appCustomers = dbCustomers.Select(c => new CustomerClass(c.Name, c.Id)).ToList();
            // return customer list
            return appCustomers;
        }


        public void CreateCustomerInDb(CustomerClass customer)
        {
            // Create Context
            using var context = new danielGProj0DBContext(_contextOptions);
            // Create a database customer using info from ConsoleApp Customer
            Customer dbCustomer = new Customer
            {
                Name = customer.Name
            };

            // Add Customer to database and save change
            context.Customers.Add(dbCustomer);
            context.SaveChanges();
        }


        public int GetAmountOfCustomers()
        {
            // Create Context
            using var context = new danielGProj0DBContext(_contextOptions);

            var custCount = context.Customers.Count();

            return custCount;

        }







    }
}
