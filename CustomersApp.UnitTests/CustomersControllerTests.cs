using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Autofac;
using CustomersApp.Api.DataAccess;
using CustomersApp.Api.Models;
using FluentAssertions;
using Newtonsoft.Json;
using CustomersApp.UnitTests.Fixtures;
using System.Net.Http;
using CustomersApp.Api.Controllers;
using System;

namespace CustomersApp.UnitTests
{
    [TestFixture]
    public class CustomersControllerTests
    {

        private CustomersDataFixture _customersDataFixture;
        private CustomersController _customersController;

        [OneTimeSetUp]
        public void SetUpFixture()
        {
            _customersDataFixture = new CustomersDataFixture();
            _customersController = new CustomersController();
        }

        [Test]
        public void GetById_ShouldReturnCustomer_WithValidId()
        {
            const int customerId = 2;
            var expectedCustomer = CustomerSeedData.Get.Single(c => c.Id == customerId);
            var customer = _customersController.Get(customerId);
            customer.Id.Should().Be(expectedCustomer.Id);
            customer.FirstName.Should().Be(expectedCustomer.FirstName);
        }

        [Test]
        public void GetById_ShouldReturnEmpty_WithInvalidId()
        {
            const int customerId = 99;
            var customer = _customersController.Get(customerId);
            
           (customer == null).Should().Be(true);
        }

        [Test]
        public void Post_ShouldAddCustomer_WithValidInput()
        {
            const string newCustomerFirstName = "Hazem1";
            const string newCustomerLastName = "Rihani1";
            var newCustomer = new Customer {Id=21, FirstName = newCustomerFirstName , LastName = newCustomerLastName, CreatedDate = DateTime.Now, Deleted = false };
           var result = _customersController.Add(newCustomer);
            result.Id.Should().BeGreaterThan(0);
            result.LastName.Should().Be(newCustomerLastName);
            result.FirstName.Should().Be(newCustomerFirstName);
        }

        [Test]
        public void Post_ShouldReturnZeroId_WithInvalidInput()
        {
            const string newCustomerFirstName = "";
            const string newCustomerLastName = "";
            var newCustomer = new Customer { Id=33 ,FirstName = newCustomerFirstName, LastName = newCustomerLastName,CreatedDate=DateTime.Now, Deleted=false};
            var result = _customersController.Add(newCustomer);
            result.Id.Should().Be(0);
            result.LastName.Should().Be(null);
            result.FirstName.Should().Be(null);
        }

        [Test]
        public void Delete_ShouldRemoveCustomer_WithValidId()
        {
            const int customerId = 1;

           _customersController.Delete(customerId);
           var customer = _customersController.Get(customerId);
            (customer == null).Should().Be(true);
        }

        private void BuildTestContainerBuilder(ContainerBuilder builder)
        {
            builder.RegisterInstance(_customersDataFixture.Context).As<CustomerDbContext>();
        }
    }
}