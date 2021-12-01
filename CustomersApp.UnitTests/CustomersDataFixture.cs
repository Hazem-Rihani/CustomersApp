using System;
using CustomersApp.Api.DataAccess;
using CustomersApp.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CustomersApp.UnitTests.Fixtures
{
    public class CustomersDataFixture 
    {
        public CustomersDataFixture()
        {
            Context = new CustomerDbContext();
            SeedContext();
        }

        public CustomerDbContext Context { get; }

        private void SeedContext()
        {
            foreach (Customer customer in CustomerSeedData.Get)
            {
                Context.Create(customer);
            }
        }
    }
}

