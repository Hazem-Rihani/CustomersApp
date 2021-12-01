using CustomersApp.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp.UnitTests
{
    internal static class CustomerSeedData
    {
        public static IEnumerable<Customer> Get => new List<Customer>
        {
            new Customer
            {
                Id = 1,
                FirstName = "Hazem",
                LastName = "Rihani",
                Deleted = false,
                CreatedDate = DateTime.Now
            },
            new Customer
            {
                Id = 2,
                FirstName = "Stephanie",
                LastName = "Hedoux",
                Deleted = false,
                CreatedDate = DateTime.Now
            },
            new Customer
            {
                Id = 3,
                FirstName = "Christophe",
                LastName = "Pillot",
                Deleted = false,
                CreatedDate = DateTime.Now
            }
        };

    }
}
